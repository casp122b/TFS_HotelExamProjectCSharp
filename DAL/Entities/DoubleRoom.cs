﻿namespace DAL.Entities
{
    public class DoubleRoom : IRoom
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}