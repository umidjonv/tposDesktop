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

-- Dumping structure for table stock.orders
CREATE TABLE IF NOT EXISTS `orders` (
  `orderId` int(11) NOT NULL AUTO_INCREMENT,
  `expenseId` int(11) NOT NULL,
  `prodId` int(11) NOT NULL,
  `count` float NOT NULL,
  `packCount` float DEFAULT NULL,
  PRIMARY KEY (`orderId`)
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8;

-- Dumping data for table stock.orders: ~68 rows (approximately)
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` (`orderId`, `expenseId`, `prodId`, `count`, `packCount`) VALUES
	(1, 1, 5833, 0, 10),
	(2, 1, 2957, 0, 1),
	(3, 2, 5833, 0, 10),
	(4, 3, 2139, 0, 10),
	(5, 3, 2148, 0, 16),
	(6, 3, 2155, 0, 16),
	(7, 3, 5020, 0, 1),
	(8, 3, 6127, 0, 1),
	(9, 4, 3421, 0, 83),
	(10, 5, 2957, 0, 1),
	(11, 6, 5833, 0, 10),
	(12, 7, 2957, 0, 1),
	(13, 8, 2139, 0, 16),
	(14, 9, 2148, 0, 16),
	(15, 10, 2139, 0, 16),
	(16, 11, 2148, 0, 16),
	(17, 12, 5833, 0, 10),
	(18, 13, 2139, 0, 16),
	(19, 14, 2139, 0, 16),
	(20, 15, 5833, 0, 10),
	(21, 16, 3421, 0, 84),
	(22, 17, 2957, 0, 1),
	(23, 18, 2957, 0, 1),
	(24, 18, 6006, 0, 1),
	(25, 19, 2204, 0, 29),
	(26, 20, 832, 0, 29),
	(27, 21, 832, 0, 29),
	(28, 22, 832, 0, 29),
	(29, 22, 3062, 0, 29),
	(30, 22, 2204, 0, 29),
	(31, 23, 832, 0, 29),
	(32, 23, 2204, 0, 29),
	(33, 24, 832, 0, 29),
	(34, 24, 2204, 0, 29),
	(35, 25, 832, 0, 29),
	(36, 25, 2204, 0, 29),
	(37, 26, 3062, 0, 29),
	(38, 26, 832, 0, 29),
	(39, 27, 832, 0, 29),
	(40, 27, 3062, 0, 29),
	(41, 28, 832, 0, 29),
	(42, 28, 2204, 0, 29),
	(43, 29, 2139, 0, 16),
	(44, 30, 832, 0, 29),
	(45, 30, 2204, 0, 29),
	(46, 31, 832, 0, 120),
	(47, 32, 832, 0, 30),
	(48, 33, 10, 0, 1),
	(49, 34, 10, 0, 3),
	(50, 35, 10, 0, 1),
	(51, 1, 7, 0, 30),
	(52, 2, 7, 0, 30),
	(53, 3, 2, 0, 60),
	(54, 4, 2, 0, 180),
	(55, 5, 2, 0, 20),
	(56, 6, 2, 0, 60),
	(57, 7, 2, 0, 5),
	(58, 8, 10, 0, 0.2),
	(59, 9, 1207, 0, 0.532),
	(60, 10, 1207, 0, 0.266),
	(61, 11, 1207, 0, 40),
	(62, 12, 1291, 0, 1.082),
	(63, 13, 1291, 0, 1),
	(64, 14, 1291, 0, 1),
	(65, 15, 10, 0, 1),
	(66, 16, 10, 0, 1),
	(67, 17, 832, 0, 30),
	(68, 18, 832, 0, 2);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
