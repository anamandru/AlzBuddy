using AlzBuddy.Receivers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class RequestService : BackgroundService
{
    private readonly ILogger<RequestService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public RequestService(ILogger<RequestService> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try 
            {
                string serverUri = "http://172.20.10.2:5000/get_data";
                HttpClient httpClient = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await httpClient.GetAsync(serverUri, stoppingToken);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ReceiveMessage rm = new ReceiveMessage();

                    rm.AddReceivedData(content);

                    _logger.LogInformation("Temp: " + Globals.currentTemperature);

                    _logger.LogInformation($"Received from server: {content}");
                    
                    //OnDataReceived(new DataReceivedEventArgs(di));
                }
                else
                {
                    _logger.LogError($"Failed to receive data. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
