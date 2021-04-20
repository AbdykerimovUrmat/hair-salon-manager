using System;

namespace HairSalon.Data.Entities
{
    public class Session
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
    }
}
