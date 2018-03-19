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
        public Main()
        {
            
            API.onEntityEnterColShape += API_onEntityEnterColShape;
   
            loadEggs();

        }


        private void loadEggs()
        {
            using (var db = new GTARlDb(ConnectionString))
            {
                List<EggModel> leggs = db.Eggs.ToList<EggModel>();
                foreach(EggModel egg in leggs)
                {
                    Vector3 pos = new Vector3();
                    pos.X = egg.PositionX;
                    pos.Y = egg.PositionY;
                    pos.Z = egg.PositionZ;
                    Vector3 rot = new Vector3();
                    rot.X = egg.RotationX;
                    rot.Y = egg.RotationY;
                    rot.Z = egg.RotationZ;
                    ColShape cs = API.createCylinderColShape(pos, 1, 1);
                    eggs.Add(cs);
                    API.createObject(1803116220, pos, rot);
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
                result = db.EggFound.AsNoTracking().Where(p => p.EggID == id && p.Name == player.socialClubName.ToLower()).Count() > 0;
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
                    int id = getEggID(colshape);
                    //abfrage ob schon gefunden
                    Boolean found = hasFound(id, p);
                    if (found == false)
                    {
                       
                        p.sendChatMessage("Du hast ein Ei gefunden!");
                        setFound(id, p);
                }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

      

        private void setFound(int id, Client player)
        {
            using (var db = new GTARlDb(ConnectionString))
            {
                EggFoundModel m = new EggFoundModel();
                m.EggID = id;
                m.Name = player.socialClubName.ToLower();
                db.EggFound.Add(m);
                db.SaveChanges();
            }
        }

        [Command("createegg")]
        public void createegg(Client sender)
        {
            Vector3 pos = sender.position;
            Vector3 rot = sender.rotation;
           ColShape cs = API.createCylinderColShape(pos, 1, 1);
            eggs.Add(cs);
            API.createObject(1803116220, pos, rot);
            EggModel e = new EggModel();
            e.PositionX = pos.X;
            e.PositionY = pos.Y;
            e.PositionZ = pos.Z;
            e.RotationX = rot.X;
            e.RotationY = rot.Y;
            e.RotationZ = rot.Z;
            using (var db = new GTARlDb(ConnectionString))
            {
                db.Eggs.Add(e);
                db.SaveChanges();

                int id = e.EggId;
                API.sendChatMessageToPlayer(sender, "ID: " + id);
                cs.setData("ID", id);
                sender.sendChatMessage("Du hast ein Ei versteckt!");
            }
        }

    }
