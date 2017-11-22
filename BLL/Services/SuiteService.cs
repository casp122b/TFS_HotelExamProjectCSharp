using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SuiteService : IService<SuiteBO>
    {
        SuiteConverter suiteConv = new SuiteConverter();
        DALFacade _facade = new DALFacade();

        public SuiteService(DALFacade facade)
        {
            _facade = facade;
        }

        public SuiteBO Create(SuiteBO suiteBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newSuite = uow.SuiteRepository.Create(suiteConv.Convert(suiteBO));
                uow.Complete();
                return suiteConv.Convert(newSuite);
            }
        }

        public SuiteBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var removeSuite = uow.SuiteRepository.Delete(Id);
                uow.Complete();
                return suiteConv.Convert(removeSuite);
            }
        }

        public SuiteBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var getSuite = uow.SuiteRepository.Get(Id);
                return suiteConv.Convert(getSuite);
            }
        }

        public List<SuiteBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.SuiteRepository.GetAll().Select(suiteConv.Convert).ToList();
            }
        }

        public SuiteBO Update(SuiteBO suiteBO)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var updateSuite = uow.SuiteRepository.Get(suiteBO.Id);
                if (updateSuite == null)
                {
                    throw new InvalidOperationException("guest not found");
                }
                updateSuite.Price = suiteBO.Price;
                updateSuite.Available = suiteBO.Available;
                uow.Complete();
                return suiteConv.Convert(updateSuite);
            };
        }
    }
}
