CREATE OR ALTER VIEW [VwGetTotalClientes] AS
SELECT 
    COUNT(*) AS [TotalDeClientes]
FROM
    [Cliente]