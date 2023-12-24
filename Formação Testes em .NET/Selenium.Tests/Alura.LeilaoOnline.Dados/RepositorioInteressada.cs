using Alura.LeilaoOnline.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class RepositorioInteressada : RepositorioBase<Interessada>
    {
        public RepositorioInteressada(LeiloesContext ctx) : base(ctx)
        {

        }

        public override Interessada BuscarPorId(int id)
        {
            return _ctx.Interessada
                .Where(i => i.Id == id)
                .Include(i => i.Favoritos)
                .ThenInclude(f => f.LeilaoFavorito)
                .Include(i => i.Lances)
                .ThenInclude(l => l.Leilao)
                .FirstOrDefault();
        }
    }
}
