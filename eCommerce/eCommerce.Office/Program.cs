using eCommerce.Office;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceOfficeContext();

#region Many-To-Many > 2x One-To-Many = EF Core < 5.0 (3.1....1.0)
//Setor > ColaboradoresSetores > Colaborador
var resultado = db.Setores!.Include(a=>a.ColaboradoresSetores).ThenInclude(a=>a.Colaborador);
foreach (var setor in resultado)
{
    Console.WriteLine(setor.Nome);
    foreach(var colabSetor in setor.ColaboradoresSetores)
    {
        Console.WriteLine(" - " + colabSetor.Colaborador.Nome);
    }
}
#endregion