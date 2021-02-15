using GraphQL.Language.AST;
using GraphQL.Types;

namespace Backend.API.Data.GeographicalModels
{
    public sealed class MetApiCompactType : ObjectGraphType<MetApiCompact.Root>
    {
        public MetApiCompactType()
        {
            Field(x => x.Type);
            Field<GeometryType>(nameof(MetApiCompact.Geometry));
            Field<PropertiesType>(nameof(MetApiCompact.Properties));
        }

        private sealed class GeometryType : ObjectGraphType<MetApiCompact.Geometry>
        {
            public GeometryType()
            {
                Field(x => x.Type);
                Field(x => x.Coordinates);
            }
        }

        private sealed class PropertiesType : ObjectGraphType<MetApiCompact.Properties>
        {
            public PropertiesType()
            {
                Field<MetaType>(nameof(MetApiCompact.Meta));
                Field<ListGraphType<TimeSeriesType>>(nameof(MetApiCompact.Timeseries));
            }
        }

        private sealed class TimeSeriesType : ObjectGraphType<MetApiCompact.Timeseries>
        {
            public TimeSeriesType()
            {
                Field<DataType>(nameof(MetApiCompact.Data));
                Field(x => x.Time);
            }
        }

        private sealed class DataType : ObjectGraphType<MetApiCompact.Data>
        {
            public DataType()
            {
                Field<InstantType>(nameof(MetApiCompact.Instant));
                Field<Next1HoursType>(nameof(MetApiCompact.Next1Hours));
                Field<Next6HoursType>(nameof(MetApiCompact.Next6Hours));
                Field<Next12HoursType>(nameof(MetApiCompact.Next12Hours));
            }
        }

        private sealed class InstantType : ObjectGraphType<MetApiCompact.Instant>
        {
            public InstantType()
            {
                Field<DetailsType>(nameof(MetApiCompact.Details));
            }
        }

        private sealed class Next1HoursType : ObjectGraphType<MetApiCompact.Next1Hours>
        {
            public Next1HoursType()
            {
                Field<SummaryType>(nameof(MetApiCompact.Summary));
                Field<DetailsType>(nameof(MetApiCompact.Details));
            }
        }

        private sealed class Next6HoursType : ObjectGraphType<MetApiCompact.Next6Hours>
        {
            public Next6HoursType()
            {
                Field<SummaryType>(nameof(MetApiCompact.Summary));
                Field<DetailsType>(nameof(MetApiCompact.Details));
            }
        }

        private sealed class Next12HoursType : ObjectGraphType<MetApiCompact.Next12Hours>
        {
            public Next12HoursType()
            {
                Field<SummaryType>(nameof(MetApiCompact.Summary));
            }
        }

        private sealed class SummaryType : ObjectGraphType<MetApiCompact.Summary>
        {
            public SummaryType()
            {
                Field(x => x.SymbolCode);
            }
        }

        private sealed class DetailsType : ObjectGraphType<MetApiCompact.Details>
        {
            public DetailsType()
            {
                Field(x => x.AirTemperature);
                Field(x => x.PrecipitationAmount);
                Field(x => x.RelativeHumidity);
                Field(x => x.WindSpeed);
                Field(x => x.CloudAreaFraction);
                Field(x => x.WindFromDirection);
                Field(x => x.AirPressureAtSeaLevel);
            }
        }


        private sealed class MetaType : ObjectGraphType<MetApiCompact.Meta>
        {
            public MetaType()
            {
                Field<UnitsType>(nameof(MetApiCompact.Units));
                Field(x => x.UpdatedAt);
            }
        }

        private sealed class UnitsType : ObjectGraphType<MetApiCompact.Units>
        {
            public UnitsType()
            {
                Field(x => x.AirTemperature);
                Field(x => x.PrecipitationAmount);
                Field(x => x.RelativeHumidity);
                Field(x => x.WindSpeed);
                Field(x => x.CloudAreaFraction);
                Field(x => x.WindFromDirection);
                Field(x => x.AirPressureAtSeaLevel);
            }
        }
    }
}