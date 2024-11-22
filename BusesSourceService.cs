using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace BusStopAPI
{
    public class BusesSourceService
    {
        private readonly HttpClient httpClient;
        private string APIKey = "c0a2f304-551a-4d08-b8df-2c53ecd57f9f";
        public string APIPath_busStopsAll = "https://transit.ttc.com.ge/pis-gateway/api/v2/stops?locale=ka";

        // Constructor
        public BusesSourceService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        // methods
        private string APIPath_busStopByNumber(string busStopNumber) // this was given as a string
        {
            return $"https://transit.ttc.com.ge/pis-gateway/api/v2/stops/1:{busStopNumber}/arrival-times?locale=ka&ignoreScheduledArrivalTimes=false";
        }

        public async Task<string> GetBusStopsAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, APIPath_busStopsAll);
            request.Headers.Add("x-api-key", APIKey);
            request.Headers.Add("Accept", "application/json"); // Ensure the response is JSON

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> GetBusStopByCodeAsync(string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, APIPath_busStopByNumber(code));
            request.Headers.Add("x-api-key", APIKey);
            request.Headers.Add("Accept", "application/json"); // Ensure the response is JSON

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
