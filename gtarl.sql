-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 19. Mrz 2018 um 17:27
-- Server-Version: 10.1.29-MariaDB
-- PHP-Version: 7.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `gtarl`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `eggs`
--

CREATE TABLE `eggs` (
  `id` int(11) NOT NULL,
  `posx` float NOT NULL,
  `posy` float NOT NULL,
  `posz` float NOT NULL,
  `rotx` float NOT NULL,
  `roty` float NOT NULL,
  `rotz` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `eggsfound`
--

CREATE TABLE `eggsfound` (
  `id` int(11) NOT NULL,
  `EggID` int(11) NOT NULL,
  `user` char(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `__migrationhistory`
--

CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 NOT NULL,
  `ContextKey` varchar(300) CHARACTER SET utf8 NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `__migrationhistory`
--

INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
('201803191555065_init', 'GTRL.Migrations.Configuration', 0x1f8b0800000000000400ed58db6ee336107d2fd07f10f89c3573418036907791b59320689c045176b1bb6fb434768852a42a5281bdbfd6877e527fa143dd2f7664c56951144580c02267ce5c39c3e19fbfffe17e5885c27986587325c7e46874481c90be0ab85c8e496216ef7e221fdefff8837b11842be773417762e99053ea317932263aa354fb4f10323d0ab91f2bad1666e4ab90b240d1e3c3c39fe9d11105842088e538ee43220d0f21fdc0cf89923e44266162a602103a5fc71d2f45756e59083a623e8cc9d5e3c3cd284cc988732e3843153c100be23029956106153cfba4c133b1924b2fc205261ed71120dd82090db9e26715f9ae361c1e5b1b68c55840f989362a1c087874923b85b6d95fe55a523a0ddd7681ee356b6b75eaba31b9582e2f552283d4bfc4694b3c9b88d85237dc3b6a301d3876eba0cc014c15fb77e04c12619218c612121333a4bb4fe682fbbfc0fa51fd0a722c1321eacaa17ab8d758c0a5fb5845109bf5032c2a95af03e2d0262b6df3969c4db6cc9a6b694e8e89738b2ab0b98032036a967b46c5700512626620b867c6408c01bc0e20f56147810de2a67de25e86b0ff0b04cc5a3c79c499b1d50dc8a5791a93e3d353e25cf21504c54a8efa49723ca8c864e2047aa4bab44a89be44199a23ffa7c77671f74a738bf3a50c308657f4456b3bced737c2f9b627ce43ee9f7ded2a70f6b5abc01966d7cba702bb92611c239fcbb87a3c7f10d3f9869381ed263f1c3a3f8d4d65333c0f4cab1a13a7929f75b151ab50d35e20bd1964037f616d6957d56669d6678b7e4cb7346477c6a2081d5b6bd0f98ae365dd79f2ce1bdebdc20c83fa7a43132bb52d25e189644b68eda268d4f492c7da4c99617366633d09c20e5911c52d8e2da4b402d5ae4795cb0b06fbbbc8932d2db48d52b9ef122d0ab1a2a4c641a94cbb6f77f8d31b12132cde5ce5264a24a1cc9678a758f6014c9b00f9d2ee18595fab43241ae24d082e6df9a1ed6edaf177abecb7e3b76b74f53e91dd23a8ff743c6b7da80e1229bd7a0dccd70e4ca713ee02f3ad03f37d084cad09d5616265061955eb412d984146d55a500b66a3517f6bce774a7d9ba4945e96fc566977f332db3f9075ea6e46421cf4cf330f6ccd9dadbddfc4c8ee8fd29f13c1d1e08a62c6245f8036d98d909c8e4e5ba3ddbf67cca25a0762c8acf58aab6df768f7df6b7979a9e5d6b3bdd7d681f7abc698934a18089095fe8cdf7f627177c479e3f9e5bfe1f7ac4067021642b1e18ecf6af39e08dff743c82af29e087b5a91d5e1dd1186cd06ddcbe76e13407e4def1b03b2923a26c15ca10d99cef6f6924f11fd53c20b727a44bc7a86e8361097d6dffddc2968beac20ec2ba004df56e60ab4a0b9960b5504140dab6b5490b4e23d03c3020cc6796cf882f906b77dd03a7d5df9cc4462cd0be7105ccbbbc4448939d71ac2b968b47c97be2c3f1d949a3abb7791fdd26f6102aac9d104b8931f132e8252efcb0dd9ba05c2e6655e8e502bcfd8b2b45c9748b74aee0894bb6f0a11485bcc1e218c0482e93be9b167788d6e3835dfc092f9ebe21ab01da43f104db7bb53ce96310b758e51f1dbb76c6a1fb3dfff0583737ca1fe160000, '6.2.0-61023');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `eggs`
--
ALTER TABLE `eggs`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `eggsfound`
--
ALTER TABLE `eggsfound`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `__migrationhistory`
--
ALTER TABLE `__migrationhistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `eggs`
--
ALTER TABLE `eggs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `eggsfound`
--
ALTER TABLE `eggsfound`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
