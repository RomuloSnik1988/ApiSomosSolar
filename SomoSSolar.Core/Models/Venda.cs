namespace SomoSSolar.Core.Models;

public class Venda
{
    public int Id { get; set; }
    public int EquipamentoId { get; set; }
    public int Quantidade { get; set; }

    public Equipamento? Equipamento { get; set; }
}
