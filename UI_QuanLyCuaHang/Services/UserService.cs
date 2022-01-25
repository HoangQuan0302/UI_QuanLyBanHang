using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Services {
    public class UserService : IUserService {
        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }

        public UserService(HttpClient httpClient, IOptions<AppSettings> appSettings) {
            _appSettings = appSettings.Value;

            httpClient.BaseAddress = new Uri(_appSettings.DiChoThueBaseAddress);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "UI_QuanLyCuaHang");

            _httpClient = httpClient;
        }

        public async Task<User> LoginAsync(User user) {
            var loginmodel = new LoginModel() { username = user.username, password = user.password };
            string serializedUser = JsonConvert.SerializeObject(loginmodel);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Authenticate/Login");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

            return await Task.FromResult(returnedUser);

        }

        public async Task<ResponseMessageModel> RegisterStoreAsync(User user) {
            var registermodel = new RegisterModel() { username = user.username, password = user.password, email = user.Email };
            string serializedUser = JsonConvert.SerializeObject(registermodel);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Authenticate/RegisterStore");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedResponse = JsonConvert.DeserializeObject<ResponseMessageModel>(responseBody);

            return await Task.FromResult(returnedResponse);
        }

        public async Task<User> RefreshTokenAsync(RefreshRequest refreshRequest) {
            string serializedUser = JsonConvert.SerializeObject(refreshRequest);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Users/RefreshToken");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

            return await Task.FromResult(returnedUser);
        }

        public async Task<User> GetUserByAccessTokenAsync(string accessToken) {
            string serializedRefreshRequest = JsonConvert.SerializeObject(accessToken);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Authenticate/LoginAccessToken");
            requestMessage.Content = new StringContent(serializedRefreshRequest);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

            return await Task.FromResult(returnedUser);
        }
    }
}
