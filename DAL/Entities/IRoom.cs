using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public interface IRoom : IEntity
    {
        double Price { get; set; }
        int Available { get; set; }
    }
}
