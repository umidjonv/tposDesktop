
CREATE FUNCTION `prodBalance`(`id` INT) RETURNS float
    DETERMINISTIC
    COMMENT 'Высчитывание текущего остатка продукта'
BEGIN
	DECLARE prodID INT;
	DECLARE eCount INT;
	DECLARE cEndCount INT;
	DECLARE realizes INT;
	DECLARE i INT;
	DECLARE LastDate date;
	DECLARE back INT;
	DECLARE result float DEFAULT(0);
	DECLARE cDate date DEFAULT(date(now()));
	
	
	SET i = (select productId from product order by productId DESC limit 1);
	SET LastDate = (select balanceDate from balance order by balanceDate DESC limit 1);
	IF (LastDate is not null) THEN
		IF (LastDate != cDAte) THEN
			WHILE i > 0 DO
			
				SET prodID = (select productId from product where productId = i);
				IF(prodID is not NULL) THEN
					
					# Начальный остаток продукта
					SET cEndCount = (select b.curEndCount from balance b where b.prodId = prodID and b.balanceDate = LastDate order by balanceDate DESC limit 1);
					IF(cEndCount is NULL) THEN		
						SET eCount = (select b.endCount from balance b where b.prodId = i and b.balanceDate = LastDate limit 1);
					ELSE		
						SET eCount = cEndCount;
					END IF;
					
					# Insert в таблицу баланс
					insert into balance (`balanceDate`,`prodId`,`endCount`) values(date(now()),prodID,eCount);
				END IF;
				
				SET i=i-1;
		   END WHILE;
		END IF;
	ELSE
			WHILE i > 0 DO
			
				SET prodID = (select productId from product where productId = i);
				IF(prodID is not NULL) THEN
				
					#Приход продукта
					SET eCount = (select sum(r.count) from faktura f join realize r on r.fakturaId = f.fakturaId where r.prodId = prodID and date(f.fakturaDate) = date(now()) limit 1);
					IF (eCOunt is null) THEN 
						SET eCount = 0;
					END IF;
					
				
					# Insert в таблицу баланс
					insert into balance (`balanceDate`,`prodId`,`endCount`) values(date(now()),prodID,eCount);
				END IF;
				
				SET i=i-1;
		   END WHILE;			
	END IF;	
	SET result = (select b.endCount from balance b where b.balanceDate = date(now()) and b.prodId = id limit 1);
	return result;
		
END