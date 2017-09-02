
CREATE DEFINER=`root`@`localhost` PROCEDURE `FakturaTrigger`(IN `id` INT)
    COMMENT 'Процедура при оплате счета'
BEGIN

	DECLARE done INT DEFAULT 0;
	DECLARE bCount float;
	DECLARE realizeCount float;
	DECLARE prodsID int;
	DECLARE cur1 CURSOR FOR SELECT r.prodId,r.count FROM realize r where r.fakturaId = id;
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
	
	OPEN cur1;
	
	REPEAT
		FETCH cur1 INTO prodsID, realizeCount;
		IF NOT done THEN
			SET bCount = prodBalance(prodsID);
			UPDATE balance	SET endCount = (bCount + realizeCount) where balanceDate=date(now()) and prodId = prodsID;
		END IF;
	UNTIL done END REPEAT;
	
	CLOSE cur1;

END