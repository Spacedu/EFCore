// See https://aka.ms/new-console-template for more information
using eCommerce.API.Database;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();

/*
 * var usuario01 = db.Usuarios.FirstOrDefault(a=>a.Id == 1);
usuario01!.Nome = "José Ribeiro da Silva Costa";

db.SaveChanges();
*/

var usuario01 = db.Usuarios.AsNoTracking().FirstOrDefault(a => a.Id == 1);
usuario01!.Nome = "José Ribeiro da Silva Costa";

db.Update(usuario01);
db.SaveChanges();


