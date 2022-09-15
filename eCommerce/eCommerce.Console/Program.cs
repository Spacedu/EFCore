using eCommerce.Console.Database;

var db = new eCommerceContext();
foreach(var usuario in db.Usuarios)
{
    Console.WriteLine(usuario.Nome); 
}

Console.WriteLine("Hello, World!");
