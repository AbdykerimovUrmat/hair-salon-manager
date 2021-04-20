using HairSalon.Data;
using System.Threading.Tasks;

namespace HairSalon.Services
{
    public class ContextHasService
    {
        protected AppDbContext Context { get; }

        public ContextHasService(AppDbContext context)
        {
            Context = context;
        }

        protected async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
