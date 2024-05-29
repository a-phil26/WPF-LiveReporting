-- File: DefectView.sql
-- Project: BI-A02
-- Programmer: Addison Phillips
-- Description: This stored procedure will show the reasons for defect. If '0' is passed to it, 
--				then it shows all the product's defect reasons, other wise it shows it only the product_id's defect reasons.

CREATE PROCEDURE DefectReasons
@Product_id int
AS
BEGIN
	if (@Product_id = 0)
		SELECT defect_reason AS 'REASON', COUNT(*) as 'Count'
		FROM YoYoData WHERE defect_reason !=''
		Group By  defect_reason;
	else
		SELECT product_id, defect_reason AS 'REASON', COUNT(*) as 'Count'
		FROM YoYoData 
		WHERE defect_reason !=''
		AND product_id = @Product_id
		Group By product_id, defect_reason;
END
