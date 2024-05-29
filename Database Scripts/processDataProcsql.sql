-- File: processDataProc.sql
-- Project: BI-A02
-- Programmer: Addison Phillips
-- Description: This stored proc is used by a trigger. It reads every line of unprocessed data 
--				and then extracts the data from the strings in the raw data table, inserting them into the YoYoData table

CREATE PROCEDURE ProcessData  
AS
BEGIN
    --delcare the variables i will use
	DECLARE 
		@NewData nvarchar(max),
	
		@WorkArea nvarchar(60), 
		@SerialNumber nvarchar(60), 
		@ProductionLine nvarchar(60), 
		@CurrentState nvarchar(60), 
		@DefectReason nvarchar(60), 
		@DateTimestamp nvarchar(60), 
		@ProductID nvarchar(10);

		--Only get the unprocessed data
	DECLARE cursorUpdate CURSOR FOR
	SELECT data_string
    FROM RawDataDump
	WHERE processed =0;
	
	OPEN cursorUpdate
	FETCH NEXT FROM cursorUpdate INTO @NewData;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @SplitValues TABLE (Value nvarchar(max));

		INSERT INTO @SplitValues (Value)
		SELECT value 
		FROM string_split(@NewData, ',');

		SELECT
			@WorkArea = (SELECT Value FROM @SplitValues ORDER BY (SELECT NULL) OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY),
			@SerialNumber = (SELECT Value FROM @SplitValues ORDER BY (SELECT NULL) OFFSET 1 ROWS FETCH NEXT 1 ROW ONLY),
			@ProductionLine = (SELECT Value FROM @SplitValues ORDER BY (SELECT NULL) OFFSET 2 ROWS FETCH NEXT 1 ROW ONLY),
			@CurrentState = (SELECT Value FROM @SplitValues ORDER BY (SELECT NULL) OFFSET 3 ROWS FETCH NEXT 1 ROW ONLY),
			@DefectReason = (SELECT Value FROM @SplitValues ORDER BY (SELECT NULL) OFFSET 4 ROWS FETCH NEXT 1 ROW ONLY),
			@DateTimestamp = (SELECT Value FROM @SplitValues ORDER BY (SELECT NULL) OFFSET 5 ROWS FETCH NEXT 1 ROW ONLY),
			@ProductID = (SELECT Value FROM @SplitValues ORDER BY (SELECT NULL) OFFSET 6 ROWS FETCH NEXT 1 ROW ONLY);

			INSERT INTO YoYoData
			Values (@WorkArea, @SerialNumber, @ProductionLine, @CurrentState, @DefectReason, @DateTimestamp, @ProductID)
			
			--set a flag to say its been processed. 
			UPDATE RawDataDump
			SET processed = 1
			WHERE CURRENT OF cursorUpdate

		FETCH NEXT FROM cursorUpdate INTO @NewData;
	END
	CLOSE cursorUpdate;
    DEALLOCATE cursorUpdate;
END;


