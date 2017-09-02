
CREATE DEFINER=`root`@`localhost` FUNCTION `getPrice`(`id` INT) RETURNS float
    DETERMINISTIC
    COMMENT 'Получение цены продукта на основе остатка продукта'
BEGIN
	
	DECLARE lastDate Date;
	DECLARE prodPrice Float;
	#SET LastDate = (select balanceDate from balance order by balanceDate DESC limit 1);
	SET lastDate = (select balanceDate from balance where prodId = id group by balanceDate order by balanceDate desc limit 1);
	IF lastDate is not null THEN 
		SET prodPrice = checkRealize(id, prodBalance(id));
	ELSE 
		SET prodPrice = (select price from product where productId = id limit 1);
	END IF;
	return prodPrice;
END