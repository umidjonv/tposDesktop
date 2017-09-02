
CREATE DEFINER=`root`@`localhost` PROCEDURE `BackTrigger`(IN `id` INT)
    COMMENT 'Процедура при возврате счета'
BEGIN

	DECLARE done INT DEFAULT 0;
	DECLARE bCount float;
	DECLARE orderCount float;
	DECLARE prodsID int;
	DECLARE cur1 CURSOR FOR SELECT o.prodId,o.packCount FROM orders o where o.expenseId = id;
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
	
	OPEN cur1;
	
	REPEAT
		FETCH cur1 INTO prodsID, orderCount;
		IF NOT done THEN
			SET bCount = prodBalance(prodsID);
			UPDATE balance	SET endCount = (bCount + orderCount) where balanceDate=date(now()) and prodId = prodsID;
		END IF;
	UNTIL done END REPEAT;
	
	CLOSE cur1;

END