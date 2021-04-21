
using Common.Interfaces;

namespace HairSalon.Data.Entities
{
    public class Service : IIdHasInt
    {
        /// <summary>
        /// Код услуги
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена услуги
        /// </summary>
        public int Price { get; set; }
    }
}
