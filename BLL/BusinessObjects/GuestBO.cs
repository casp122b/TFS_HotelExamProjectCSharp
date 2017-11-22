using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class GuestBO : IBusinessObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
