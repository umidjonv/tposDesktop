-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.45 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL Version:             9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table stock.user
CREATE TABLE IF NOT EXISTS `user` (
  `IDUser` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(25) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(25) NOT NULL,
  `IDUserType` int(11) NOT NULL,
  `phone` varchar(15) DEFAULT NULL,
  `ban` tinyint(4) NOT NULL DEFAULT '0',
  `role` varchar(255) NOT NULL,
  `IsActive` tinyint(4) NOT NULL,
  PRIMARY KEY (`IDUser`),
  KEY `usertype` (`IDUserType`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Dumping data for table stock.user: ~3 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`IDUser`, `username`, `password`, `email`, `IDUserType`, `phone`, `ban`, `role`, `IsActive`) VALUES
	(1, 'admin', 'd9b1d7db4cd6e70935368a1efb10e377', 'admin@admin.ru', 0, NULL, 0, 'admin', 0),
	(6, 'user', '820526b77f0ca1bfcdafb92a7bf1e998', 'asd@asde.ru', 0, NULL, 0, 'user', 0),
	(7, '123', 'd9b1d7db4cd6e70935368a1efb10e377', '', 0, NULL, 0, 'user', 0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
