using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using UI_QuanLyCuaHang.Services;
using Newtonsoft.Json;

namespace UI_QuanLyCuaHang.Data {
    public class AuthenticationStateUser:AuthenticationStateProvider {
        public ILocalStorageService _localStorageService { get; }
        public IUserService _userService { get; set; }
        private readonly HttpClient _httpClient;

        public AuthenticationStateUser(ILocalStorageService localStorageService, IUserService userService, HttpClient httpClient)
         {
            _localStorageService = localStorageService;
            _userService = userService;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
            var currentUser = await _localStorageService.GetItemAsync<User>("currentUser");
            ClaimsIdentity identity;

            if (currentUser != null) {
                User user = await _userService.GetUserByAccessTokenAsync(currentUser.Token);
                identity = GetClaimsIdentity(user);
            }
            else {
                identity = new ClaimsIdentity();
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        public async Task MarkUserAsAuthenticated(User user) {

            await _localStorageService.SetItemAsync("currentUser", user);

            var identity = GetClaimsIdentity(user);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut() {
            await _localStorageService.RemoveItemAsync("refreshToken");
            await _localStorageService.RemoveItemAsync("currentUser");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetClaimsIdentity(User user) {
            var claimsIdentity = new ClaimsIdentity();

            if (user.username != null) {
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, user.username),
                                    new Claim(ClaimTypes.Role, user.Role.FirstOrDefault()),
                                    new Claim(ClaimTypes.PrimarySid,user.Id.ToString())
                                }, "Admin");
            }

            return claimsIdentity;
        }
    }
}
