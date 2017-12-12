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

        public SuiteService(DALFacade facade)
        {
            this.facade = facade;
        }

        public SuiteBO Create(SuiteBO suiteBO)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newSuite = uow.SuiteRepository.Create(suiteConv.Convert(suiteBO));
                uow.Complete();
                return suiteConv.Convert(newSuite);
            }
        }

        public SuiteBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var removeSuite = uow.SuiteRepository.Delete(Id);
                uow.Complete();
                return suiteConv.Convert(removeSuite);
            }
        }

        public SuiteBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var getSuite = uow.SuiteRepository.Get(Id);
                getSuite.User = uow.UserRepository.Get(getSuite.UserId);
                return suiteConv.Convert(getSuite);
            }
        }

        public List<SuiteBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.SuiteRepository.GetAll().Select(suiteConv.Convert).ToList();
            }
        }

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
                updateSuite.UserId = suiteBO.UserId;
                uow.Complete();
                return suiteConv.Convert(updateSuite);
            }
;
        }
    }
}