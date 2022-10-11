using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();

#region Global Filter
Console.WriteLine("GLOBAL FILTER (FILTROS GLOBAIS)");
/*
 * Ignorar o Global Filter em uma consulta
 * var usuarios = db.Usuarios!.IgnoreQueryFilters().ToList();
 */
var usuarios = db.Usuarios!.ToList();

foreach (var usuario in usuarios)
{
    Console.WriteLine($" - {usuario.Nome}");
}
#endregion

/*
 * TemporalAll
 * Console.WriteLine("DADOS TEMPORAIS(HISTÓRICOS)");
var usuarioTemp = db.Usuarios!.TemporalAll().Where(a => a.Id == 2).OrderBy(a=> EF.Property<DateTime>(a, "PeriodoInicial")).ToList();
 */
Console.WriteLine("DADOS TEMPORAIS(HISTÓRICOS)");

var AsOf = new DateTime(2022, 10, 11, 21, 21, 00);
var usuarioTemp = db.Usuarios!.TemporalAsOf(AsOf).Where(a => a.Id == 2).OrderBy(a => EF.Property<DateTime>(a, "PeriodoInicial")).ToList();
foreach (var usuario in usuarioTemp)
{
    Console.WriteLine($" - {usuario.Nome} Mãe: {usuario.Mae}");
}