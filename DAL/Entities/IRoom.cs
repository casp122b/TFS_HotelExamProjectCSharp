using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public interface IRoom
    {
        int Id { get; set; }
        double Price { get; set; }
        int Available { get; set; }
    }
}
