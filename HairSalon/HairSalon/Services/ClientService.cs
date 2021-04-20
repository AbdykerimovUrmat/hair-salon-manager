using HairSalon.Data;
using HairSalon.Data.Entities;

namespace HairSalon.Services
{
    public class ClientService : EntityService<Client, int>
    {
        public ClientService(AppDbContext context)
            :base(context)
        { }
    }
}
