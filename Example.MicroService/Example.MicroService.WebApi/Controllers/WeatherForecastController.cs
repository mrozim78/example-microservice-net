using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace Example.MicroService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public WeatherForecastHeader Get()
    {
        WeatherForecastHeader header = new WeatherForecastHeader();
        

        header.Forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        header.MachineName = Environment.MachineName;

        header.HostName= Dns.GetHostName(); // Retrive the Name of HOST
            
            // Get the IP
        header.Ip = Dns.GetHostByName(header.HostName).AddressList[0].ToString();
        header.Architecture =  System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();
        return header;

    }
}