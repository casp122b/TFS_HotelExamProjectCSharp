﻿using DAL.UOW;

namespace DAL
{
    public class DALFacade
    {
        DbOptions opt;
        public DALFacade(DbOptions opt)
        {
            this.opt = opt;
        }

        public IUnitOfWork UnitOfWork => new UnitOfWork(opt);
    }
}