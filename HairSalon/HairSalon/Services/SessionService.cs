using HairSalon.Data;
using HairSalon.Data.Entities;

namespace HairSalon.Services
{
    public class SessionService : EntityService<Session, int>
    {
        public SessionService(AppDbContext context)
            :base(context)
        { }
    }
}
