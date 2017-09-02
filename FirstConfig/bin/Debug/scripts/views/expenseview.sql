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

-- Dumping structure for view stock.expenseview
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `expenseview`;
CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` VIEW `expenseview` AS SELECT date(e.expenseDate) as expenseDate, sum(o.packCount) as `count`, p.name, p.pack from expense e
join orders o
on o.expenseId = e.expenseId
join product p
on p.productId = o.prodId
where e.`debt` != 1 and e.`status` != 1 and e.expType != 1
group by e.expenseDate ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
