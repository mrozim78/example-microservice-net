namespace Example.MicroService.WebApi;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

public class WeatherForecastHeader
{
    public IEnumerable<WeatherForecast> Forecasts {get;set;}

    public string MachineName {get;set;}

    public string HostName {get;set;}

    public string Ip {get;set;}

    public string Architecture {get;set;}
}