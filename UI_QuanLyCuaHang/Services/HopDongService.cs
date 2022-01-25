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
    public class HopDongService:IHopDongService {
        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }
        public ILocalStorageService _localStorageService { get; }

        public HopDongService(HttpClient httpClient
            , IOptions<AppSettings> appSettings
            , ILocalStorageService localStorageService) {
            _appSettings = appSettings.Value;
            _localStorageService = localStorageService;

            httpClient.BaseAddress = new Uri(_appSettings.DiChoThueBaseAddress);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "UI_QuanLyCuaHang");

            _httpClient = httpClient;
        }

        public async Task<ResponseMessageModel> TaoHopDong(HopDong hopdong) {
            string serializedHD = JsonConvert.SerializeObject(hopdong);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "UploadFile");
            requestMessage.Content = new StringContent(serializedHD);
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
