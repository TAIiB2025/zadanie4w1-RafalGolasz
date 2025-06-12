using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IKsiazkiService
    {
        IEnumerable<Ksiazka> GetAll();
        Ksiazka? GetById(int id);
        void Add(KsiazkaBody body);
        void Update(int id, KsiazkaBody body);
        void Delete(int id);
    }
}
