
CREATE DEFINER=`root`@`localhost` FUNCTION `checkRealize`(`id` INT, `bCount` FLOAT) RETURNS int(11)
    DETERMINISTIC
    COMMENT 'Проверка цены продукта по фактурам'
BEGIN

	DECLARE rCount INT DEFAULT(0);
	DECLARE i Int;
	DECLARE price Int;
	DECLARE facId Int DEFAULT(0);
	
	SET i = (select count(*) from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = id);
	
	myloop: WHILE i > 0 DO
		IF(facId = 0) THEN 
			SET rCount = rCount + (select r.count from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = id order by f.fakturaDate DESC limit 1);
			SET facId = (select f.fakturaId from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = id order by f.fakturaDate DESC limit 1);
			SET price = (select r.soldPrice from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = id order by f.fakturaDate DESC limit 1);
		ELSE
			SET rCount = rCount + (select r.count from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = id AND f.fakturaId < facId order by f.fakturaDate DESC limit 1);
			SET price = (select r.soldPrice from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = id AND f.fakturaId < facId order by f.fakturaDate DESC limit 1);
			SET facId = (select f.fakturaId from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = id AND f.fakturaId < facId order by f.fakturaDate DESC limit 1);
		END IF;
		
		IF(bCount <= rCount) THEN 
			LEAVE myloop;
		END IF; 
		SET i=i-1;
   END WHILE;
	RETURN price;
END