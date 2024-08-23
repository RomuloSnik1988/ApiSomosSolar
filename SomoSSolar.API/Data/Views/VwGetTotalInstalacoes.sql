CREATE OR ALTER VIEW [VwGetTotalInstalacoes] AS
SELECT 
    COUNT(*) AS [TotalDeInstalacoes]
FROM
    [Instalacao]