using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLLTest.Mockdata
{
    public class SuiteTestMock : ISuitTestService
    {
        List<SuiteBO> suites = new List<SuiteBO>();

        public SuiteBO Create(SuiteBO s)
        {
            s.Id = suites.Count + 1;
            suites.Add(s);
            return s;
        }

        public List<SuiteBO> GetAll()
        {
            return suites;
        }

        public SuiteBO GetById(int Id)
        {
            {
                foreach (SuiteBO s in suites)
                {
                    if (s.Id == Id)
                    {
                        return s;
                    }
                }
                return null;
            }
        }

        public SuiteBO Update(SuiteBO s)
        {
            var x = Delete(s.Id);
            Create(s);
            return s;
        }

        public SuiteBO Delete(int Id)
        {
            var x = GetById(Id);
            suites.Remove(x);
            return x;
        }
    }
}
