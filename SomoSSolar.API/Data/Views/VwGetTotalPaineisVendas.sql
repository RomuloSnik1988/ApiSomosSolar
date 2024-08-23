CREATE OR ALTER VIEW [VwGetTotalPaineisVendas] AS
SELECT
    SUM(CAST(v.[Quantidade] AS INT)) AS [TotalDePaineis]
FROM
    [Venda] v
INNER JOIN
    [Equipamento] e ON v.[EquipamentoId] = e.[Id]
WHERE
    e.[Tipo] = 2 -- Tipo 2 representa 'painéis'