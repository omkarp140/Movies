﻿namespace Movies.Models.Generic.Settings
{
    public class CorsSettings
    {
        public string[] AllowedOrigins { get; set; }

        public string[] AllowedHeaders { get; set; }

        public string[] AllowedMethods { get; set; }
    }
}
