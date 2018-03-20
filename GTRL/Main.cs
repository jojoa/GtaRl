using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;
using GTARL.models;
using System;
using System.Collections.Generic;
using System.Linq;


public class Main : Script
{
    String ConnectionString = "server=localhost;database=GTARL;uid=root;password=test1234";
    List<ColShape> eggs = new List<ColShape>();
    Dictionary<int,ColShape> dic = new Dictionary<int,ColShape>();
    List<GrandTheftMultiplayer.Server.Elements.Object> eggs2 = new List<GrandTheftMultiplayer.Server.Elements.Object>();
    public Main()
    {

        API.onEntityEnterColShape += API_onEntityEnterColShape;
        API.onEntityExitColShape += API_onEntityExitColShape;

        loadEggs();

    }

    private void API_onEntityExitColShape(ColShape colshape, GrandTheftMultiplayer.Shared.NetHandle entity)
    {
        if (eggs.Contains(colshape))
        {
            try
            {

                Client p = API.getPlayerFromHandle(entity);
                int id = getEggID(colshape);
                //abfrage ob schon gefunden

                p.resetData("EGG");
               


            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    private void loadEggs()
    {
        using (var db = new GTARlDb(ConnectionString))
        {
            List<EggModel> leggs = db.Eggs.ToList<EggModel>();
            foreach (EggModel egg in leggs)
            {
                Vector3 pos = new Vector3();
                pos.X = egg.PositionX;
                pos.Y = egg.PositionY;
                pos.Z = egg.PositionZ;
                Vector3 rot = new Vector3();
                rot.X = egg.RotationX;
                rot.Y = egg.RotationY;
                rot.Z = egg.RotationZ;
                ColShape cs = API.createCylinderColShape(pos, 1.2f, 1);
                cs.setData("ID", egg.EggId);
                dic.Add(egg.EggId, cs);
                eggs.Add(cs);
                eggs2.Add(API.createObject(1803116220, pos, rot));
            }
        }
    }



    private int getEggID(ColShape cs)
    {
        return cs.getData("ID");

    }

    private Boolean hasFound(int id, Client player)
    {
        Boolean result = false;
        using (var db = new GTARlDb(ConnectionString))
        {
            result = db.Eggs.AsNoTracking().Where(p => p.EggId == id && p.User != "dummy").Count() > 0;
        }

        return result;
    }

    private void API_onEntityEnterColShape(ColShape colshape, GrandTheftMultiplayer.Shared.NetHandle entity)
    {
        if (eggs.Contains(colshape))
        {
            try
            {

                Client p = API.getPlayerFromHandle(entity);
                if (p.hasData("EDIT_EGG"))
                {
                    return;
                }
                int id = getEggID(colshape);
                //abfrage ob schon gefunden
                Boolean found = hasFound(id, p);
                p.setData("EGG", id);
                if (found == false)
                {

                    p.sendChatMessage("Du hast ein Ei gefunden!");

                    List<Client> players = API.getAllPlayers();
                    API.sendChatMessageToAll(p.name  + " hat ein Ei gefunden!");

                    setFound(id, p);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }


    private void reload()
    {
        foreach (GrandTheftMultiplayer.Server.Elements.Object o in eggs2)
        {
            API.deleteEntity(o);
        }

        foreach (ColShape cs in eggs)
        {
            API.deleteColShape(cs);
        }

        loadEggs();

    }


    private void setFound(int id, Client player)
    {
        ColShape cs = dic[id];
        GrandTheftMultiplayer.Server.Elements.Object o = eggs2[eggs.IndexOf(cs)];
        Vector3 pos = o.position;
        Vector3 rot = new Vector3(0, 0, pos.Z);
        o.rotation = rot;

        using (var db = new GTARlDb(ConnectionString))
        {
            EggModel e = db.Eggs.Single(p => p.EggId == id);
            e.User = player.socialClubName.ToLower();
            e.RotationX = 0;
            e.RotationY = 0;
            e.RotationZ = pos.Z;
            db.SaveChanges();
        }
       
    }

    [Command("createegg")]
    public void createegg(Client sender)
    {
        Vector3 pos = sender.position;
        pos.Add(new Vector3(0, 0, -0.7));
        Vector3 rot = sender.rotation;
        sender.setData("EDIT_EGG", true);
        ColShape cs = API.createCylinderColShape(pos, 1.2f, 1);
        eggs.Add(cs);
        eggs2.Add(API.createObject(1803116220, pos, rot));
        EggModel e = new EggModel();
        e.PositionX = pos.X;
        e.PositionY = pos.Y;
        e.PositionZ = pos.Z;
        e.RotationX = rot.X;
        e.RotationY = rot.Y;
        e.RotationZ = rot.Z;
        e.User = "dummy";
        using (var db = new GTARlDb(ConnectionString))
        {
            db.Eggs.Add(e);
            db.SaveChanges();

            int id = e.EggId;
            API.sendChatMessageToPlayer(sender, "ID: " + id);
            cs.setData("ID", id);
            dic.Add(id, cs);
            sender.sendChatMessage("Du hast ein Ei versteckt!");
        }
    }

    [Command("getEggID")]
    public void getID(Client sender)
    {
        if (sender.hasData("Egg"))
        {
            sender.sendChatMessage(sender.getData("EGG"));
        } else
        {
            sender.sendChatMessage("Du stehtst bei keinem Ei");
        }
    }

    [Command("removeEgg")]
    public void removeEgg(Client sender, int id)
    {
        using (var db = new GTARlDb(ConnectionString))
        {
            EggModel e = db.Eggs.Single(p => p.EggId == id);
            if(e == null)
            {
                sender.sendChatMessage("Ei nicht gefunden");
                return;
            }
            db.Eggs.Remove(e);
            db.SaveChanges();
        }

        reload();

    }

    [Command("EggEdit")]
    public void switchEdit(Client client)
    {
        if (client.hasData("EDIT_EGG"))
        {
            client.resetData("EDIT_EGG");
            client.sendChatMessage("EditMode deaktiviert");
        } else
        {
            client.setData("EDIT_EGG", true);
            client.sendChatMessage("EditMode aktiviert!");
        }
    }

    [Command("unfindegg")]
    public void unfind(Client sender, int id)
    {
       

        using (var db = new GTARlDb(ConnectionString))
        {
            EggModel e = db.Eggs.Single(p => p.EggId == id);
            if(e == null)
            {
                sender.sendChatMessage("Ei nicht gefunden!");
                return;
            }
            e.User = "dummy";
            db.SaveChanges();
        }
    }

    [Command("rotateEgg")]
    public void rotate(Client sender,int id,  float x, float y, float z)
    {
        

        using (var db = new GTARlDb(ConnectionString))
        {
            EggModel e = db.Eggs.Single(p => p.EggId == id);
            if (e == null)
            {
                sender.sendChatMessage("Ei nicht gefunden!");
                return;
            }
            e.RotationX = x;
            e.RotationY = y;
            e.RotationZ = z;
            db.SaveChanges();
        }

        ColShape cs = dic[id];
        GrandTheftMultiplayer.Server.Elements.Object o = eggs2[eggs.IndexOf(cs)];
        Vector3 pos = o.position;
        Vector3 rot = new Vector3(x, y, z);
        o.rotation = rot;
        sender.sendChatMessage("Ei rotiert!");
    }
    
    [Command("getEggPos")]
    public void getEggPos(Client sender, int id)
    {
        using (var db = new GTARlDb(ConnectionString))
        {
            EggModel e = db.Eggs.Single(p => p.EggId == id);
            if (e == null)
            {
                sender.sendChatMessage("Ei nicht gefunden!");
                return;
            }
            sender.sendChatMessage("Position");
            sender.sendChatMessage(e.PositionX.ToString());
            sender.sendChatMessage(e.PositionY.ToString());
            sender.sendChatMessage(e.PositionZ.ToString());
            sender.sendChatMessage("Rotation");
            sender.sendChatMessage(e.RotationX.ToString());
            sender.sendChatMessage(e.RotationY.ToString());
            sender.sendChatMessage(e.RotationZ.ToString());
            
        }
    }
}
