namespace BLL.BusinessObjects
{
    public class SuiteBO : IBusinessObject
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
    }
}
