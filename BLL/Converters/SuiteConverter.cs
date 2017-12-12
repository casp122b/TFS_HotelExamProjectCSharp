using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class SuiteConverter: IConverter<Suite, SuiteBO>
    {
        public Suite Convert(SuiteBO suiteBO)
        {
            if (suiteBO == null)
            {
                return null;
            }

            return new Suite()
            {
                Id = suiteBO.Id,
                Price = suiteBO.Price,
                Available = suiteBO.Available,
                UserId = suiteBO.UserId
            };
        }

        public SuiteBO Convert(Suite suite)
        {
            if (suite == null)
            {
                return null;
            }

            return new SuiteBO()
            {
                Id = suite.Id,
                Price = suite.Price,
                Available = suite.Available,
                User = new UserConverter().Convert(suite.User),
                UserId = suite.UserId
            };
        }
    }
}