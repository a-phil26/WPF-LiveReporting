-- File: GetLineDataProc.sql
-- Project: BI-A02
-- Programmer: Addison Phillips
-- Description: This procedure calculates the required data needed in the live reporting and returns it as a table.

CREATE PROCEDURE GetLineData
@Product_id int
AS
BEGIN

	Create TABLE #Temp (
		total_mold DECIMAL(10,2),
		success_mold DECIMAL(10,2),
		yeild_mold DECIMAL(10,2),
		success_paint DECIMAL(10,2),
		yeild_paint DECIMAL(10,2),
		success_assembled DECIMAL(10,2),
		yeild_assembly DECIMAL(10,2),
		total_package DECIMAL(10,2),
		yeild_total DECIMAL(10,2)
	);

	DECLARE
		@Total_mold DECIMAL(10,2),
		@Success_mold DECIMAL(10,2),
		@Yeild_mold DECIMAL(10,2),
		@Success_paint DECIMAL(10,2),
		@Yeild_paint DECIMAL(10,2),
		@Success_assembled DECIMAL(10,2),
		@Yeild_assembly DECIMAL(10,2),
		@Total_package DECIMAL(10,2),
		@Yeild_total DECIMAL(10,2)

	--All molded
	SELECT @Total_mold = COUNT(CASE WHEN current_state = 'MOLD' AND (@Product_id > 0 AND product_id = @Product_id OR @Product_id <= 0) THEN 1 ELSE NULL END)
	FROM YoYoData;
	
	--Successfully molded
	SELECT @Success_mold = COUNT(CASE WHEN current_state = 'QUEUE_PAINT' AND (@Product_id > 0 AND product_id = @Product_id OR @Product_id <= 0) THEN 1 ELSE NULL END)
	FROM YoYoData

	--Yeild Molded
	SET @Yeild_mold = @Success_mold / NULLIF (@Total_mold, 0);

	--Successfully Painted
	SELECT @Success_paint =  COUNT(CASE WHEN current_state = 'QUEUE_ASSEMBLY' AND (@Product_id > 0 AND product_id = @Product_id OR @Product_id <= 0) THEN 1 ELSE NULL END)
	FROM YoYoData
	 
	--Yeild @ paint
	SET @Yeild_paint =  @Success_paint/ NULLIF(@Success_mold, 0); 

	--Successfully Assembled (It went to packaging)
	SELECT @Success_assembled =  COUNT(CASE WHEN current_state = 'PACKAGE' AND (@Product_id > 0 AND product_id = @Product_id OR @Product_id <= 0) THEN 1 ELSE NULL END)
	FROM YoYoData

	SET @Yeild_assembly = @Success_assembled/@Success_paint;
	SET @Total_package = @Success_assembled;
	SET @Yeild_total = @Total_package/ NULLIF(@Total_mold, 0)


	INSERT INTO #Temp
	Values (@Total_mold, @Success_mold,	@Yeild_mold,@Success_paint,	@Yeild_paint,@Success_assembled,@Yeild_assembly,@Total_package,@Yeild_total)

	SELECT * FROM #Temp;

	DROP TABLE #Temp;
END;
