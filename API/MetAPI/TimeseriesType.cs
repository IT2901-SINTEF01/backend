using System.Collections.Generic;
using Backend.API.Data;
using GraphQL.Language.AST;
using GraphQL.Types;
using Newtonsoft.Json;

namespace Backend.API.MetAPI
{
    public class TimeseriesType : ObjectGraphType<Forecast.Timeseries>
    {
        public TimeseriesType()
        {
            Field(timeseries => timeseries.Data, false, typeof(DataType));
            Field(timeseries => timeseries.Time);
        }
    }
}