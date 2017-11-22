using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class DoubleRoomBO : IBusinessObject
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
    }
}
