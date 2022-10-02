using eCommerce.API.Database;
using Microsoft.EntityFrameworkCore;

/*
 * EF Core > Support LINQ > SQL - EFCore > SGDB
 * To*, Find, First*, Single*,Last*, Count, Max, Min... Executa o Código SQL -> App -> C# (Memory)
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
//var usuario01 = db.Usuarios!.FirstOrDefault(a => a.Id == 2);
var usuario01 = db.Usuarios!.Single(a=>a.Email == "filipe.ribeiro@gmail.com");
//var usuario01 = db.Usuarios!.SingleOrDefault(a=>a.Nome.Contains("a"));

if (usuario01 == null)
    Console.WriteLine("Usuário não encontrado!");
else
    Console.WriteLine($" COD: {usuario01!.Id} - NOME: {usuario01!.Nome}");

var count = db.Usuarios!.Where(a => a.Nome.Contains("a")).Count();
Console.WriteLine($"NÚMERO DE USUÁRIOS QUE CONTÉM A LETRA 'A' EM SEU NOME: {count}");


var min = db.Usuarios!.Min(a => a.Nome);
Console.WriteLine($"VALOR MIN(ID):{min}");

var max = db.Usuarios!.Max(a => a.Nome);
Console.WriteLine($"VALOR MAX(ID):{max}");

/*
 * WHERE
 */
Console.WriteLine("LISTA DE USUÁRIOS (WHERE)");
var usuariosList = db.Usuarios!.Where(a=>a.Nome.Contains("a") || a.Nome.Contains("j")).ToList(); //LIKE 
foreach(var usuario in usuariosList)
{
    Console.WriteLine($" - {usuario.Nome}");
}

/*
 * OrderBy, OrderByDescending, ThenBy, ThenByDesceding
 */

Console.WriteLine("LISTA DE USUÁRIOS (ORDER)");
var usuariosListOrder = db.Usuarios!.OrderBy(a=>a.Sexo).ThenBy(a=>a.Nome).ToList();
foreach (var usuario in usuariosListOrder)
{
    Console.WriteLine($" - {usuario.Nome}");
}

/*
 * Include, ThenInclude
 * Include (Nível 1)
 * ThenInclude (Nível 2)
 */
Console.WriteLine("LISTA DE USUÁRIOS (INCLUDE)");
var usuariosListInclude = db.Usuarios!.Include(a=>a.Contato).Include(a=>a.EnderecosEntrega!.Where(e=>e.Estado == "SP")).Include(a=>a.Departamentos).ToList();
foreach (var usuario in usuariosListInclude)
{
    Console.WriteLine($" - {usuario.Nome} - TEL: {usuario.Contato!.Telefone} - QT END: {usuario.EnderecosEntrega!.Count} - QT DEP: {usuario.Departamentos.Count}");

    foreach(var endereco in usuario.EnderecosEntrega)
    {
        Console.WriteLine($" -- {endereco.NomeEndereco}: {endereco.CEP} - {endereco.Estado} - {endereco.Bairro} - {endereco.Endereco}");
    }
}

Console.WriteLine("LISTA DE TELEFONE (THENINCLUDE)");
var contatos = db.Contatos!.Include(a=>a.Usuario).ThenInclude(u=>u!.EnderecosEntrega).Include(a=>a.Usuario).ThenInclude(a=>a!.Departamentos).ToList();
foreach(var contato in contatos)
{
    Console.WriteLine($" - {contato.Telefone} -> {contato.Usuario!.Nome} - QT END: {contato.Usuario!.EnderecosEntrega!.Count} - QT DEP: {contato.Usuario!.Departamentos!.Count}");
}

db.ChangeTracker.Clear();
Console.WriteLine("LISTA DE USUARIOS (AUTOINCLUDE)");
var usuariosAutoInclude = db.Usuarios!.IgnoreAutoIncludes().ToList();
foreach(var usuario in usuariosAutoInclude)
{
    Console.WriteLine($"NOME: {usuario.Nome} - TEL: {usuario.Contato?.Telefone}");
}
