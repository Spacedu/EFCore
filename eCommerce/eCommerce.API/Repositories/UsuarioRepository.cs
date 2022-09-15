using eCommerce.API.Database;
using eCommerce.Models;

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
            return _db.Usuarios.OrderBy(a => a.Id).ToList();
        }
        public Usuario Get(int id)
        {
            return _db.Usuarios.Find(id)!;
        }
        public void Add(Usuario usuario)
        {
            /*
             * Unit of Works
             */
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
