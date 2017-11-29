﻿using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class SuiteConverter : IConverter<Suite, SuiteBO>
    {
        public Suite Convert(SuiteBO suiteBO)
        {
            if (suiteBO == null) { return null; }
            return new Suite()
            {
                Id = suiteBO.Id,
                Price = suiteBO.Price,
                Available = suiteBO.Available,
                GuestId = suiteBO.GuestId
            };
        }

        public SuiteBO Convert(Suite suite)
        {
            if (suite == null) { return null; }
            return new SuiteBO()
            {
                Id = suite.Id,
                Price = suite.Price,
                Available = suite.Available,
                Guest = new GuestConverter().Convert(suite.Guest),
                GuestId = suite.GuestId
            };
        }
    }
}