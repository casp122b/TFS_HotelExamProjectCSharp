﻿using System;

namespace DAL.Entities
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
    }
}
