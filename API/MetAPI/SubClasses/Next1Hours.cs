﻿using System.Text.Json.Serialization;

namespace Backend.API.MetAPI.SubClasses
{
    public class Next1Hours
    {
        [JsonPropertyName("details")] public Details Details { get; set; }

        [JsonPropertyName("summary")] public Summary Summary { get; set; }
    }
}