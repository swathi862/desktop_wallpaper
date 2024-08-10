using System;
using System.Text.Json.Serialization;

namespace Desktop_Wallpaper
{
    public record APOD(
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("date")] string Date,
        [property: JsonPropertyName("media_type")] string MediaType,
        [property: JsonPropertyName("url")] Uri Url)
    {﻿
    }
}
