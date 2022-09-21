using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Repositories
{
    /*
     * Controller > UsuarioRepository
     * Controller > IUsuarioRepository(abstrai) > UsuarioMemoryRepository (Implement IUsuarioRepository)
     * Controller > IUsuarioRepository > UsuarioEFRepository (EF Core)
     * Controller > IUsuarioRepository > UsuarioMockRepository (Testes)
     */
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly eCommerceContext _db;
        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }

        public List<Usuario> Get()
        {
            return _db.Usuarios.Include(a=>a.Contato).OrderBy(a => a.Id).ToList();
        }
        public Usuario Get(int id)
        {
            //EFCore = 1; Dapper = +20; ADO.NET = +40;
            return _db.Usuarios.Include(a=>a.Contato).Include(a=>a.EnderecosEntrega).Include(a=>a.Departamentos).FirstOrDefault(a=>a.Id == id)!;
        }
        public void Add(Usuario usuario)
        {
            /*
             * Unit of Works
             */
            if(usuario.Departamentos != null)
            {
                var departamentos = usuario.Departamentos;

                usuario.Departamentos = new List<Departamento>();

                foreach(var departamento in departamentos)
                {
                    if(departamento.Id > 0)
                    {
                        //Ref. Registro do Banco de dados
                        usuario.Departamentos.Add(_db.Departamentos.Find(departamento.Id)!);
                    }
                    else
                    {
                        //Ref. Objeto novo, que não existe no SGDB. (Novo registro de Departamento)
                        usuario.Departamentos.Add(departamento);
                    }
                }
            }


            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }
        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id));
            _db.SaveChanges();
        }
    }
}
