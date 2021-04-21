using HairSalon.Data;
using HairSalon.Data.Entities;

namespace HairSalon.Services
{
    public class ServiceService : EntityService<Service, int>
    {
        public ServiceService(AppDbContext context)
            :base(context)
        { }
    }
}
