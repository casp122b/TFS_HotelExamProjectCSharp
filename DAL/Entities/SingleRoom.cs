using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class SingleRoom : IRoom
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
    }
}
