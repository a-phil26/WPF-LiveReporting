-- File: ProcessDataTrigger.sql
-- Project: BI-A02
-- Programmer: Addison Phillips
-- Description: this file contains the ProcessOnInsert trigger. Every time something is inserted into the
--				raw data table, it executes the processing stored procedure

CREATE TRIGGER ProcessOnInsert
ON RawDataDump
AFTER INSERT
AS
BEGIN
EXEC ProcessData;
END;
