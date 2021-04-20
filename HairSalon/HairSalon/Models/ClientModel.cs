using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common.Interfaces;

namespace HairSalon.Models
{
    public static class ClientModel
    {

        public class Base : IIdHasInt
        {
            /// <summary>
            /// Код клиента
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            [DisplayName("Имя")]
            [Required]
            public string FirstName { get; set; }

            /// <summary>
            /// Фамилия
            /// </summary>
            [DisplayName("Фамилия")]
            [Required]
            public string LastName { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            [DisplayName("Отчество")]
            public string Surname { get; set; }

            /// <summary>
            /// Код на карте клиента
            /// </summary>
            [DisplayName("Код карты")]
            public int CardCode { get; set; }

            /// <summary>
            /// Телефона клиента
            /// </summary>
            [Required]
            [DataType(DataType.PhoneNumber)]
            [DisplayName("Телефон")]
            public string Phone { get; set; }
        }
    }
}
