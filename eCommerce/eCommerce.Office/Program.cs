using eCommerce.Office;
using eCommerce.Office.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceOfficeContext();

#region Many-To-Many for EF Core <= 3.1
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

#region Many-To-Many for EF Core 5.0+
Console.WriteLine("----------------------------");
var resultadoTurma = db.Colaboradores!.Include(a => a.Turmas);
foreach(var colab in resultadoTurma)
{
    Console.WriteLine(colab.Nome);
    foreach(var turma in colab.Turmas)
    {
        Console.WriteLine("- " + turma.Nome);
    }
}
#endregion