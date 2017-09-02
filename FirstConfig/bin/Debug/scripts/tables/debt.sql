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

-- Dumping structure for table stock.debt
CREATE TABLE IF NOT EXISTS `debt` (
  `debtId` int(11) NOT NULL AUTO_INCREMENT,
  `expenseId` int(11) DEFAULT NULL,
  `payDate` date DEFAULT NULL,
  `terminal` int(11) DEFAULT NULL,
  PRIMARY KEY (`debtId`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;

-- Dumping data for table stock.debt: ~49 rows (approximately)
/*!40000 ALTER TABLE `debt` DISABLE KEYS */;
INSERT INTO `debt` (`debtId`, `expenseId`, `payDate`, `terminal`) VALUES
	(2, 213, '2017-03-13', 0),
	(3, 279, '2017-03-15', 0),
	(4, 110, '2017-03-15', 0),
	(5, 277, '2017-03-21', 0),
	(6, 415, '2017-03-21', 0),
	(7, 5, '2017-04-01', 0),
	(8, 7, '2017-04-01', 0),
	(9, 9, '2017-04-01', 0),
	(10, 10, '2017-04-01', 0),
	(11, 11, '2017-04-01', 0),
	(12, 11, '2017-04-01', 0),
	(13, 11, '2017-04-01', 0),
	(14, 11, '2017-04-01', 0),
	(15, 11, '2017-04-01', 0),
	(16, 11, '2017-04-01', 0),
	(17, 11, '2017-04-01', 0),
	(18, 11, '2017-04-01', 0),
	(19, 11, '2017-04-01', 0),
	(20, 11, '2017-04-01', 0),
	(21, 11, '2017-04-01', 0),
	(22, 11, '2017-04-01', 0),
	(23, 11, '2017-04-01', 0),
	(24, 11, '2017-04-01', 0),
	(25, 11, '2017-04-01', 0),
	(26, 11, '2017-04-01', 0),
	(27, 11, '2017-04-01', 0),
	(28, 11, '2017-04-01', 0),
	(29, 11, '2017-04-01', 0),
	(30, 11, '2017-04-01', 0),
	(31, 11, '2017-04-01', 0),
	(32, 11, '2017-04-01', 0),
	(33, 11, '2017-04-01', 0),
	(34, 11, '2017-04-01', 0),
	(35, 11, '2017-04-01', 0),
	(36, 11, '2017-04-01', 0),
	(37, 11, '2017-04-01', 0),
	(38, 11, '2017-04-01', 0),
	(39, 11, '2017-04-01', 0),
	(40, 12, '2017-04-01', 0),
	(41, 12, '2017-04-01', 0),
	(42, 12, '2017-04-01', 0),
	(43, 13, '2017-04-01', 0),
	(44, 13, '2017-04-01', 0),
	(45, 13, '2017-04-01', 0),
	(46, 13, '2017-04-01', 0),
	(47, 14, '2017-04-01', 0),
	(48, 14, '2017-04-01', 0),
	(49, 15, '2017-04-01', 0),
	(50, 16, '2017-04-01', 0);
/*!40000 ALTER TABLE `debt` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
