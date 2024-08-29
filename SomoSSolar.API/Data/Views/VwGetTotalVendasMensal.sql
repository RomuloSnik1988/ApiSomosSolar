CREATE OR ALTER VIEW [VwGetTotalVendasMensal] AS
SELECT 
	MONTH ([Instalacao].[DataInstalacao]) AS [Month],
	YEAR ([Instalacao].[DataInstalacao]) AS [Year],
    COUNT(*) AS [TotalDeVendasMensal]
FROM
    [Instalacao]
WHERE 
	[Instalacao].[DataInstalacao] >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
	AND [Instalacao].[DataInstalacao] < DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
GROUP BY
MONTH ([Instalacao].[DataInstalacao]),
YEAR ([Instalacao].[DataInstalacao])