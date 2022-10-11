using eCommerce.API.Database;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("GLOBAL FILTER (FILTROS GLOBAIS)");
var db = new eCommerceContext();
/*
 * Ignorar o Global Filter em uma consulta
 * var usuarios = db.Usuarios!.IgnoreQueryFilters().ToList();
 */
var usuarios = db.Usuarios!.ToList();

foreach (var usuario in usuarios)
{
    Console.WriteLine($" - {usuario.Nome}");
}