-- File: storedProc.sql
-- Project: BI-A02
-- Programmer: Addison Phillips
-- Description: This file contains the RawDataDumpProcedure procedure that is executed by a program. 
--				It inserts into a table the string passed to it.

CREATE PROCEDURE RawDataDumpProcedure
@NewData nvarchar(max)
AS
BEGIN
	INSERT INTO RawDataDump (data_string)
	Values (@NewData);
END;

