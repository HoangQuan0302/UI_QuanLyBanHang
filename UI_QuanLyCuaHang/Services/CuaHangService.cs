using Blazored.LocalStorage;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Services {
    public class CuaHangService : ICuaHangService {
        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }
        public ILocalStorageService _localStorageService { get; }

        public CuaHangService(HttpClient httpClient
            , IOptions<AppSettings> appSettings
            , ILocalStorageService localStorageService) {
            _appSettings = appSettings.Value;
            _localStorageService = localStorageService;

            httpClient.BaseAddress = new Uri(_appSettings.DiChoThueBaseAddress);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "UI_QuanLyCuaHang");

            _httpClient = httpClient;
        }

        public async Task<Boolean> CheckExistStore(string requestUri) {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var currentUser = await _localStorageService.GetItemAsync<User>("currentUser");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", currentUser.Token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK") {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Boolean.Parse(responseBody);
            }
            return true;
        }

        public async Task<CuaHang> GetCuaHangByUserId(string requestUri) {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var currentUser = await _localStorageService.GetItemAsync<User>("currentUser");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", currentUser.Token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK") {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<CuaHang>(responseBody));
            }
            else {
                return default;
            }
        }
        public async Task<ResponseMessageModel> TaoCuaHang(CuaHang cuahang) {
            string serializedUser = JsonConvert.SerializeObject(cuahang);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "CuaHang/create-store");
            requestMessage.Content = new StringContent(serializedUser);
            var currentUser = await _localStorageService.GetItemAsync<User>("currentUser");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", currentUser.Token);
            requestMessage.Content.Headers.ContentType
            = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            if (responseStatusCode.ToString() == "OK") {
                var responseBody = await response.Content.ReadAsStringAsync();
                var returnedResponse = JsonConvert.DeserializeObject<ResponseMessageModel>(responseBody);
                return returnedResponse;
            }
            else {
                return default;
            }
        }
    }
}
