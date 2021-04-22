using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Interfaces;

namespace HairSalon.Data.Entities
{
    public class Session : IIdHasInt
    {
        /// <summary>
        /// Код сеанса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// время создания сеанса
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Запланированное время сеанса
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Комментарий к сеансу
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Итого за весь сеанс
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// Код клиента
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// Клиент сеанса
        /// </summary>
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        /// <summary>
        /// Код услуги
        /// </summary>
        public int? ServiceId { get; set; }

        /// <summary>
        /// Услуги в сеансе
        /// </summary>
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}
