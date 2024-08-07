SELECT 
    c.Id AS ClienteId,
    c.Nome AS NomeCliente,
    c.Documento,
    c.Celular,
    c.Email,
    c.DataCadastro,
    e.Id AS EnderecoId,
    i.Id AS InstalacaoId,
    i.TipoInstalacao,
    i.DataInstalacao,
    i.Valor,
    i.Status,
    i.Despesas,
    i.AmpliacaoInstalacao
FROM 
    Cliente c
LEFT JOIN 
    Endereco e ON c.Id = e.ClienteId
LEFT JOIN 
    Instalacao i ON c.Id = i.ClienteId;