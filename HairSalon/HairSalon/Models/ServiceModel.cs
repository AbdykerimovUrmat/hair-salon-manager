using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common.Interfaces;

namespace HairSalon.Models
{
    public static class ServiceModel
    {
        public class Base : IIdHasInt
        {
            /// <summary>
            /// Код услуги
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Название
            /// </summary>
            [Required]
            [DisplayName("Название")]
            public string Name { get; set; }

            /// <summary>
            /// Цена услуги
            /// </summary>
            [Required]
            [DisplayName("Цена")]
            public int Price { get; set; }
        }
    }
}
