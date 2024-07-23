﻿using System.Text.Json.Serialization;

namespace SomoSSolar.Core.Responses;

public class Response<TData>
{
    private readonly int _code;
    [JsonConstructor]
    public Response() => _code = 200;

    public Response(TData? data, int code = 200, string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;

    }
    public TData? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}
