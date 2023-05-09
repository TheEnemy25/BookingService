using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services
{
    public class RouteApiService : IRouteApiService
    {
        private readonly HttpClient _httpClient;
        public RouteApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RouteDto>> GetAvailableRoutesAsync(RouteSearchParamsDto routeSearchParams)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("GetAvailableRoutes", routeSearchParams);

            if (response.IsSuccessStatusCode)
            {

                return await response.Content.ReadFromJsonAsync<IEnumerable<RouteDto>>();
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }
        }

        public async Task<RideConfirmationDto> BookRideAsync(BookRideParamsDto bookRideParams)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("BookRide", bookRideParams);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RideConfirmationDto>();
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }
        }
        public async Task<RouteDto> GetRouteByIdAsync(int routeId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"GetRouteById/{routeId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RouteDto>();
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }
        }
    }
}
