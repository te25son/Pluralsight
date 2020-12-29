using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext context;

        public PieRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public IEnumerable<Pie> Pies => context.Pies.Include(p => p.Category);

        public IEnumerable<Pie> PiesOfTheWeek => Pies.Where(p => p.IsPieOfTheWeek);

        public Pie GetPieById(int id) => context.Pies.FirstOrDefault(p => p.Id.Equals(id));
    }
}
