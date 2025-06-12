using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class KsiazkiService : IKsiazkiService
    {
        private static int IdCounter = 1;

        private static List<Ksiazka> ksiazki = new()
        {
            new Ksiazka { Id = IdCounter++, Tytul = "Zbrodnia i kara", Autor = "Fiodor Dostojewski", Gatunek = "Powieść psychologiczna", Rok = 1866 },
            new Ksiazka { Id = IdCounter++, Tytul = "Pan Tadeusz", Autor = "Adam Mickiewicz", Gatunek = "Epopeja narodowa", Rok = 1834 },
            new Ksiazka { Id = IdCounter++, Tytul = "Rok 1984", Autor = "George Orwell", Gatunek = "Dystopia", Rok = 1949 },
            new Ksiazka { Id = IdCounter++, Tytul = "Wiedźmin: Ostatnie życzenie", Autor = "Andrzej Sapkowski", Gatunek = "Fantasy", Rok = 1993 },
            new Ksiazka { Id = IdCounter++, Tytul = "Duma i uprzedzenie", Autor = "Jane Austen", Gatunek = "Romans", Rok = 1813 }
        };

        public IEnumerable<Ksiazka> GetAll() => ksiazki;

        public Ksiazka? GetById(int id) =>
            ksiazki.FirstOrDefault(k => k.Id == id);

        public void Add(KsiazkaBody body)
        {
            var nowa = new Ksiazka
            {
                Id = IdCounter++,
                Tytul = body.Tytul,
                Autor = body.Autor,
                Rok = body.Rok,
                Gatunek = body.Gatunek
            };

            ksiazki.Add(nowa);
        }

        public void Update(int id, KsiazkaBody body)
        {
            var ksiazka = ksiazki.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null) return;

            ksiazka.Tytul = body.Tytul;
            ksiazka.Autor = body.Autor;
            ksiazka.Rok = body.Rok;
            ksiazka.Gatunek = body.Gatunek;
        }

        public void Delete(int id)
        {
            var ksiazka = ksiazki.FirstOrDefault(k => k.Id == id);
            if (ksiazka != null)
                ksiazki.Remove(ksiazka);
        }
    }
}
