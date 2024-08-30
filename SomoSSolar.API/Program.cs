using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.FileProviders;
using SomoSSolar.API;
using SomoSSolar.API.Common;
using SomoSSolar.API.Common.Api;
using SomoSSolar.API.EndPoints;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecurity();

builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();
builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.ConfigureDevEnviroment();
app.UseStaticFiles();
app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();

app.MapEndpoints();

app.Run();
