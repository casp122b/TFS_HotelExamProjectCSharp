namespace DAL.Entities
{
    public class Suite : IRoom
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
    }
}
