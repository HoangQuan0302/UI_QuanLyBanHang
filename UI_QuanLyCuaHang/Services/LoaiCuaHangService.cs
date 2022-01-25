using Blazored.LocalStorage;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Services {
    public class LoaiCuaHangService<T>:ILoaiCuaHangService<T> {
        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }
        public ILocalStorageService _localStorageService { get; }

        public LoaiCuaHangService(HttpClient httpClient
            , IOptions<AppSettings> appSettings
            , ILocalStorageService localStorageService) {
            _appSettings = appSettings.Value;
            _localStorageService = localStorageService;

            httpClient.BaseAddress = new Uri(_appSettings.DiChoThueBaseAddress);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "UI_QuanLyCuaHang");

            _httpClient = httpClient;
        }

        public async Task<List<T>> GetAllAsync(string requestUri) {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK") {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<T>>(responseBody));
            }
            else
                return null;
        }
    }
}
