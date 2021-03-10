using System.Collections.Generic;
using System.Collections.ObjectModel;
using Backend.Models.Base.Metadata.POCO;
using Bogus;

namespace Backend.Mocks.Metadata
{
    public static class MockMetadata
    {
        public static Faker<StoredMetadata> GenerateStoredMetadata()
        {
            var axis = new Faker<Axis>()
                .RuleFor(o => o.Limit, f => new Collection<int> {f.Random.Int(0, 10), f.Random.Int(20, 50)})
                .RuleFor(o => o.Name, f => f.Commerce.Product())
                .RuleFor(o => o.Type, f => f.PickRandom("date", "years", "moneys"));

            var axes = new Faker<Axes>()
                .RuleFor(o => o.X, _ => axis.Generate())
                .RuleFor(o => o.Y, _ => axis.Generate());

            var segment = new Faker<Segment>()
                .RuleFor(o => o.Name, f => f.Hacker.Noun())
                .RuleFor(o => o.Value,
                    f => new Collection<int>(new List<int>(new[] {f.Random.Int(0, 10), f.Random.Int(10, 100)})));

            var visualisation = new Faker<Visualisation>()
                .RuleFor(o => o.Axes, _ => axes.Generate())
                .RuleFor(o => o.Segments, _ => new Collection<Segment>(segment.Generate(3)))
                .RuleFor(o => o.Threshold, f => f.Random.Int(0, 200))
                .RuleFor(o => o.Type, f => f.Hacker.Noun());

            var storedMetadata = new Faker<StoredMetadata>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => f.Random.Uuid().ToString())
                .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
                .RuleFor(o => o.Name, f => f.Name.JobArea())
                .RuleFor(o => o.Published, f => f.Date.Recent().ToLongDateString())
                .RuleFor(o => o.Updated, f => f.Date.Recent().ToLongDateString())
                .RuleFor(o => o.Source, f => f.Internet.Url())
                .RuleFor(o => o.Tags, f => new Collection<string>(f.Make(3, () => f.System.CommonFileName())))
                .RuleFor(o => o.Visualisations, _ => new Collection<Visualisation>(visualisation.Generate(3)));

            return storedMetadata;
        }

        public static Collection<StoredMetadata> GenerateMultipleStoredMetadata()
        {
            return new(GenerateStoredMetadata().Generate(10));
        }
    }
}