using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SuiteService: IService<SuiteBO>
    {
        SuiteConverter suiteConv = new SuiteConverter();
        DALFacade facade;

        //Makes the facade available in the class
        public SuiteService(DALFacade facade)
        {
            this.facade = facade;
        }

        //Converts suite and goes through the facade to create and save it, then returns the suite converted back
        public SuiteBO Create(SuiteBO suiteBO)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newSuite = uow.SuiteRepository.Create(suiteConv.Convert(suiteBO));
                uow.Complete();
                return suiteConv.Convert(newSuite);
            }
        }

        //Goes through the facade to delete suite by it's id and save the change, then returns the suite converted back, the id must already exsist
        public SuiteBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeSuite = uow.SuiteRepository.Delete(Id);
                if (removeSuite == null)
                {
                    throw new InvalidOperationException("Suite not found");
                }

                uow.Complete();
                return suiteConv.Convert(removeSuite);
            }
        }

        //Goes through the facade to get a suite by it's id, it returns a converted suite, the id must already exsist
        public SuiteBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getSuite = uow.SuiteRepository.Get(Id);
                if (getSuite == null)
                {
                    throw new InvalidOperationException("Suite not found");
                }
                return suiteConv.Convert(getSuite);
            }
        }

        //Goes through the facade  to get a list of suites and return them converted
        public List<SuiteBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.SuiteRepository.GetAll().Select(suiteConv.Convert).ToList();
            }
        }

        //Goes through the facade to get suite by it's id and changes it's values, it returns a converted suite, the id must already exsist
        public SuiteBO Update(SuiteBO suiteBO)
        {
            using (var uow = facade.UnitOfWork)
            {
                var updateSuite = uow.SuiteRepository.Get(suiteBO.Id);
                if (updateSuite == null)
                {
                    throw new InvalidOperationException("Suite not found");
                }

                updateSuite.Price = suiteBO.Price;
                updateSuite.Available = suiteBO.Available;
                updateSuite.Name = suiteBO.Name;
                updateSuite.GuestId = suiteBO.GuestId;
                uow.Complete();
                return suiteConv.Convert(updateSuite);
            }
;
        }
    }
}