using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class SuiteConverter: IConverter<Suite, SuiteBO>
    {
        GuestConverter gconv;
        public SuiteConverter()
        {
            gconv = new GuestConverter();
        }

        // Converts suiteBO to suite
        public Suite Convert(SuiteBO suiteBO)
        {
            if (suiteBO == null)
            {
                return null;
            }

            return new Suite()
            {
                Id = suiteBO.Id,
                Name = suiteBO.Name,
                Price = suiteBO.Price,
                Available = suiteBO.Available,
                GuestId = suiteBO.GuestId
            };
        }

        // Converts suite to suiteBO
        public SuiteBO Convert(Suite suite)
        {
            if (suite == null)
            {
                return null;
            }

            return new SuiteBO()
            {
                Id = suite.Id,
                Name = suite.Name,
                Price = suite.Price,
                Available = suite.Available,
                Guest = gconv.Convert(suite.Guest),
                GuestId = suite.GuestId
            };
        }
    }
}