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

-- Dumping structure for view stock.balanceview
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `balanceview`;
CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` VIEW `balanceview` AS SELECT balanceId, balanceDate, prodId, Round(endCount*(select CASE WHEN p.pack != 0 THEN Round(p.price/p.pack, 2) ELSE p.price END as price from product p where p.productId = b.prodId limit 1)) as
curEndCount,
CASE WHEN pack != 0 THEN  CONCAT(FLOOR(endCount/pack) ,'/',Round(endCount - Floor(endCount/pack)*pack, 3) )
else endCount END as endCount, productId, name, measureId, `barcode`, `status`, price, pack from balance b
join product p
on p.productId = b.prodId 
order by b.prodId ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
