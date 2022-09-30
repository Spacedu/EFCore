using eCommerce.API.Database;

/*
 * EF Core > Support LINQ > SQL - EFCore > SGDB
 * To*, Find, First*, Single*,Last*, Count... Executa o Código SQL -> App -> C# (Memory)
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

Console.WriteLine("BUSCAR 1 USUÁRIO");
//var usuario01 = db.Usuarios!.Find(2);
//var usuario01 = db.Usuarios!.Where(a=>a.Email == "elias.ribeiro.s@gmail.com").First();
//var usuario01 = db.Usuarios!.Where(a => a.Email == "filipe.ribeiro@gmail.com").FirstOrDefault();
//var usuario01 = db.Usuarios!.OrderBy(a=>a.Id).Last();
//var usuario01 = db.Usuarios!.OrderBy(a=>a.Id).Where(a => a.Email == "elias.ribeiro.s@gmail.com").LastOrDefault();
var usuario01 = db.Usuarios!.FirstOrDefault(a => a.Id == 2);

if (usuario01 == null)
    Console.WriteLine("Usuário não encontrado!");
else
    Console.WriteLine($" COD: {usuario01!.Id} - NOME: {usuario01!.Nome}");