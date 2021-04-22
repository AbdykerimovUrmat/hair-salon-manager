using HairSalon.Data;
using HairSalon.Data.Entities;
using Mapster;

using System.Threading.Tasks;

namespace HairSalon.Services
{
    public class SessionService : EntityService<Session, int>
    {
        public SessionService(AppDbContext context)
            :base(context)
        { }

        public async Task<Session> Add<T>(T model, string serviceId)
        {
            var entity = await base.Add<T>(model);
            entity.ServiceId = int.Parse(serviceId);
            await SaveChanges();

            return entity;
        }
    }
}
