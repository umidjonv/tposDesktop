
CREATE DEFINER=`root`@`localhost` PROCEDURE `balanceCalc`()
    COMMENT 'Высчитывание остатка для текущего дня'
BEGIN
	DECLARE i INT;
	DECLARE prodID INT;
	DECLARE eCount INT;
	DECLARE cEndCount INT;
	DECLARE realizes INT;
	DECLARE LastDate date;
	DECLARE expenses INT;
	DECLARE back INT;
	DECLARE cDate date DEFAULT(date(now()));
	DECLARE result FLOAT;
	
	
	SET i = (select productId from product order by productId DESC limit 1);
	SET LastDate = (select balanceDate from balance order by balanceDate DESC limit 1);
	
	IF (LastDate = cDAte) THEN
		delete from balance where balanceDate = cDAte;
	END IF;		
			
	WHILE i > 0 DO
		SET prodID = (select productId from product where productId = i);
		IF(prodID is not NULL) THEN
			SET result = prodBalance(prodID,LastDate);
			# Insert в таблицу баланс
			insert into balance (`balanceDate`,`prodId`,`endCount`) values(date(now()),prodID,result);
			
		END IF;
		
		SET i=i-1;
   END WHILE;

END