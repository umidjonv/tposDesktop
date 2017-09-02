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

-- Dumping structure for view stock.realizeview
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `realizeview`;
CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` VIEW `realizeview` AS SELECT r.realizeId, f.fakturaId,p.name,date(f.fakturaDate) as fakturaDate,
(Round(r.count*(select CASE WHEN p.pack != 0 THEN Round(r.price/p.pack, 2) ELSE r.price END as price from product p where p.productId = r.prodId limit 1))) as
price,
CASE WHEN p.pack != 0 THEN  CONCAT(FLOOR(r.count/p.pack) ,'/',(r.count - FLOOR(r.count/p.pack)*p.pack) ) else r.count END as `count`
,p.productId from faktura f
join realize r
on r.fakturaId = f.fakturaId
join product p
on p.productId = r.prodId ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
