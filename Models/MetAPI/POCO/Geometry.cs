﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Geometry
    {
        public Geometry()
        {
        }

        public Geometry(Collection<float> coordinates)
        {
            Coordinates = coordinates;
        }

        [JsonPropertyName("coordinates")] public Collection<float> Coordinates { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }
    }
}