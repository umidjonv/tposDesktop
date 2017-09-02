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

-- Dumping structure for view stock.info
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `info`;
CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` VIEW `info` AS SELECT
	date(ex.expenseDate) as Dates,
	(select sum(expSum) from expense exp where date(exp.expenseDate) = date(ex.expenseDate) AND debt != 1 AND expType != 1) as proceed,
	(select (sum(expSum)-sum(terminal)) from expense exp where date(exp.expenseDate) = date(ex.expenseDate) AND debt != 1 AND expType != 1) as nal,
	(select sum(expSum) from expense exp where date(exp.expenseDate) = date(ex.expenseDate) AND expType = 1) as back,
	(select sum(terminal) from expense exp where date(exp.expenseDate) = date(ex.expenseDate) AND debt != 1 AND expType != 1) as terminal
FROM expense ex
group by date(ex.expenseDate) 
order by ex.expenseDate desc
limit 30 ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
