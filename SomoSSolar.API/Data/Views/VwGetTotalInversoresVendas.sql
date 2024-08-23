CREATE OR ALTER VIEW [VwGetTotalInversoresVendas] AS
SELECT
    SUM(CAST(v.[Quantidade] AS INT)) AS [TotalDeInversores]
FROM
    [Venda] v
INNER JOIN
    [Equipamento] e ON v.[EquipamentoId] = e.[Id]
WHERE
    e.[Tipo] = 1 -- Tipo 2 representa 'invesores'