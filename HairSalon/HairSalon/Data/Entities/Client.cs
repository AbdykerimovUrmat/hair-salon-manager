
namespace HairSalon.Data.Entities
{
    public class Client
    {
        /// <summary>
        /// Код клиента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Код на карте клиента
        /// </summary>
        public int CardCode { get; set; }

        /// <summary>
        /// Телефона клиента
        /// </summary>
        public string Phone { get; set; }
    }
}
