using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class BookingBO : IBusinessObject
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
