using DAL.Entities;

namespace BLL.BusinessObjects
{
    public class SuiteBO : IBusinessObject
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
        public int GuestId { get; set; }
        public GuestBO Guest { get; set; }
    }
}
