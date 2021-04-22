using System;
using System.Collections.Generic;
using System.ComponentModel;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Models
{
    public static class SessionModel
    {
        
        public class Base : IIdHasInt
        {
            /// <summary>
            /// Код сеанса
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// время создания сеанса
            /// </summary>
            [DisplayName("Дата создания")]
            public DateTime CreatedTime { get; set; }

            /// <summary>
            /// Запланированное время сеанса
            /// </summary>
            [DisplayName("Начало сеанса")]
            public DateTime StartTime { get; set; }

            /// <summary>
            /// Комментарий к сеансу
            /// </summary>
            [DisplayName("Комментарий")]
            public string Comment { get; set; }

            /// <summary>
            /// Итого за весь сеанс
            /// </summary>
            [DisplayName("Сумма оплаты")]
            public int Sum { get; set; }

            /// <summary>
            /// Код клиента
            /// </summary>
            [DisplayName("Клиент")]
            public int? ClientId { get; set; }

            /// <summary>
            /// Клиент сеанса
            /// </summary>
            public ClientModel.Base Client { get; set; }

            /// <summary>
            /// Услуга
            /// </summary>
            [DisplayName("Услуга")]
            public string ServiceId { get; set; }
        }

        public class Create : Base
        {
            /// <summary>
            /// Выбран
            /// </summary>
            public IEnumerable<SelectListItem> SelectListServiceItems { get; set; }
        }
    }
}
