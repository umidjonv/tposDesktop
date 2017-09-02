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

-- Dumping structure for table stock.faktura
CREATE TABLE IF NOT EXISTS `faktura` (
  `fakturaId` int(11) NOT NULL AUTO_INCREMENT,
  `fakturaDate` datetime DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `providerId` int(11) DEFAULT NULL,
  PRIMARY KEY (`fakturaId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- Dumping data for table stock.faktura: ~12 rows (approximately)
/*!40000 ALTER TABLE `faktura` DISABLE KEYS */;
INSERT INTO `faktura` (`fakturaId`, `fakturaDate`, `userId`, `providerId`) VALUES
	(1, '2017-04-20 14:49:21', NULL, 2),
	(2, '2017-04-20 15:35:51', NULL, 5),
	(3, '2017-04-20 15:40:06', NULL, 1),
	(4, '2017-04-20 16:04:43', NULL, 5),
	(5, '2017-04-20 16:11:27', NULL, 5),
	(6, '2017-04-21 17:48:23', NULL, 4),
	(7, '2017-04-21 17:59:10', NULL, 1),
	(8, '2017-04-25 15:07:58', NULL, 1),
	(9, '2017-04-25 15:23:35', NULL, 1),
	(10, '2017-04-25 16:24:18', NULL, 5),
	(11, '2017-05-04 13:24:48', NULL, 1),
	(12, '2017-05-04 15:22:46', NULL, 1);
/*!40000 ALTER TABLE `faktura` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
