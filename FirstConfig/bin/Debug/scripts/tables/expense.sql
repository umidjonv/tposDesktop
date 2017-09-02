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

-- Dumping structure for table stock.expense
CREATE TABLE IF NOT EXISTS `expense` (
  `expenseId` int(11) NOT NULL AUTO_INCREMENT,
  `expenseDate` datetime DEFAULT NULL,
  `debt` int(11) NOT NULL,
  `comment` varchar(100) NOT NULL,
  `off` int(11) NOT NULL,
  `expType` int(11) DEFAULT NULL,
  `terminal` int(11) DEFAULT NULL,
  `expSum` int(11) DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`expenseId`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- Dumping data for table stock.expense: ~18 rows (approximately)
/*!40000 ALTER TABLE `expense` DISABLE KEYS */;
INSERT INTO `expense` (`expenseId`, `expenseDate`, `debt`, `comment`, `off`, `expType`, `terminal`, `expSum`, `status`) VALUES
	(1, '2017-04-20 18:26:42', 0, '', 0, 0, 0, 62500, 0),
	(2, '2017-04-21 16:41:20', 0, '', 0, 0, 0, 62500, 0),
	(3, '2017-04-21 18:00:14', 0, '', 0, 0, 0, 7800, 0),
	(4, '2017-04-21 18:00:50', 0, '', 0, 0, 0, 23400, 0),
	(5, '2017-04-21 18:01:03', 0, '', 0, 0, 0, 5667, 0),
	(6, '2017-04-21 18:01:14', 0, '', 0, 0, 0, 17000, 0),
	(7, '2017-04-21 18:01:27', 0, '', 0, 0, 0, 1417, 0),
	(8, '2017-04-24 12:07:23', 0, '', 0, 0, 0, 1360, 0),
	(9, '2017-04-25 15:49:48', 0, '', 0, 0, 0, 16758, 0),
	(10, '2017-04-25 16:13:34', 0, '', 0, 0, 0, 8379, 0),
	(11, '2017-04-25 16:14:20', 0, '', 0, 0, 0, 1260000, 0),
	(12, '2017-04-25 16:31:59', 0, '', 0, 0, 0, 6492, 0),
	(13, '2017-05-04 13:13:43', 0, '', 0, 0, 0, 6000, 0),
	(14, '2017-05-04 13:14:07', 0, '', 0, 0, 0, 6000, 0),
	(15, '2017-05-04 13:14:19', 0, '', 0, 0, 0, 6800, 0),
	(16, '2017-05-04 13:14:41', 0, '', 0, 0, 0, 6800, 0),
	(17, '2017-05-04 15:23:44', 0, '', 0, 0, 0, 15600, 0),
	(18, '2017-05-04 15:23:54', 0, '', 0, 0, 0, 1040, 0);
/*!40000 ALTER TABLE `expense` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
