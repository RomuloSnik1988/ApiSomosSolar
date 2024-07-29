﻿namespace SomoSSolar.Core;

public class Configuration
{
    public const int DefaultPageSize = 25;
    public static string ConnectionString { get; set; } = string.Empty;
    public static string BackendUrl { get; set; } = string.Empty;
    public static string FrontendUrl { get; set; } = string.Empty;
}
