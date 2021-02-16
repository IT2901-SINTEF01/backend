﻿using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class Next6HoursType : ObjectGraphType<Next6Hours>
    {
        public Next6HoursType()
        {
            Field(next => next.Details, false, typeof(DetailsType));
            Field(next => next.Summary.SymbolCode);
        }
    }
}