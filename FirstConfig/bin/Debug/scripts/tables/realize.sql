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

-- Dumping structure for table stock.realize
CREATE TABLE IF NOT EXISTS `realize` (
  `realizeId` int(11) NOT NULL AUTO_INCREMENT,
  `fakturaId` int(11) DEFAULT NULL,
  `prodId` int(11) DEFAULT NULL,
  `count` float DEFAULT NULL,
  `price` float DEFAULT NULL,
  `soldPrice` int(11) DEFAULT NULL,
  `expiryDate` date DEFAULT NULL,
  PRIMARY KEY (`realizeId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- Dumping data for table stock.realize: ~16 rows (approximately)
/*!40000 ALTER TABLE `realize` DISABLE KEYS */;
INSERT INTO `realize` (`realizeId`, `fakturaId`, `prodId`, `count`, `price`, `soldPrice`, `expiryDate`) VALUES
	(1, 1, 7, 30, 61000, 62000, NULL),
	(2, 1, 8, 30, 121500, 122220, NULL),
	(3, 2, 6, 1, 1200, 1200, NULL),
	(4, 2, 14, 50, 18000, 19000, NULL),
	(5, 3, 10, 1, 6700, 6800, NULL),
	(6, 3, 17, 1, 7000, 7000, NULL),
	(7, 4, 7, 60, 61000, 62500, NULL),
	(8, 5, 441, 300, 3500, 3600, NULL),
	(9, 5, 1413, 100, 8000, 8500, NULL),
	(10, 6, 6, 1, 15000, 15500, NULL),
	(11, 6, 2, 180, 7800, 7800, NULL),
	(12, 7, 2, 180, 16000, 17000, NULL),
	(13, 8, 1207, 2.33, 30000, 31500, NULL),
	(14, 9, 1207, 40, 30000, 31500, NULL),
	(15, 10, 1291, 4, 5800, 6000, NULL),
	(16, 12, 832, 150, 15000, 15600, NULL);
/*!40000 ALTER TABLE `realize` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
