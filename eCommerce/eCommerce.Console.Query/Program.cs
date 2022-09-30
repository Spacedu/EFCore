using eCommerce.API.Database;

/*
 * EF Core > Support LINQ > SQL - EFCore > SGDB
 * To*, First*, Single*,Last*, Count... Executa o Código SQL -> App -> C# (Memory)
 * 
 * db.Usuario!.{Methods > LINQ > EF > SQL > SGDB}.ToList().{Methods > LINQ > C# > Processador+Memory}; 
 */

var db = new eCommerceContext();
var usuarios = db.Usuarios!.ToList();

Console.WriteLine("LISTA DE USUÁRIOS");
foreach (var usuario in usuarios)
{
    Console.WriteLine($" - {usuario.Nome}");
}
