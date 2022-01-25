using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;
using UI_QuanLyCuaHang.Data.Default_Enum;

namespace UI_QuanLyCuaHang.Pages.Authentication {
    public partial class Login {
        private User userlogin;

        private User userRegister;

        Boolean checkRegister = false;

        public string LoginMesssage { get; set; }
        ClaimsPrincipal claimsPrincipal;

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        protected async override Task OnInitializedAsync() {
            userlogin = new User();
            userRegister = new User();
            claimsPrincipal = (await authenticationStateTask).User;

            if (claimsPrincipal.Identity.IsAuthenticated) {
                if(claimsPrincipal.IsInRole(RoleName.Admin)) {
                    NavigationManager.NavigateTo($"/admin/dashboard?userId={claimsPrincipal.Claims.LastOrDefault().Value}");
                }
                else if(claimsPrincipal.IsInRole(RoleName.Store))
                    {
                    NavigationManager.NavigateTo($"/store/dashboard?userId={claimsPrincipal.Claims.LastOrDefault().Value}");
                }
            }
            {
                userlogin.username = "";
                userlogin.password = "";
            }

        }

        private async Task<bool> ValidateUser() {
            //assume that user is valid
            //call an API

            var returnedUser = await userService.LoginAsync(userlogin);

            if (returnedUser.username != null) {
                await ((AuthenticationStateUser)AuthenticationStateProvider).MarkUserAsAuthenticated(returnedUser);
                switch(returnedUser.Role.FirstOrDefault()) {
                    case RoleName.Admin:
                        NavigationManager.NavigateTo($"/admin/dashboard?userId={returnedUser.Id}");
                        break;
                    case RoleName.Store:
                        NavigationManager.NavigateTo($"/store/dashboard?userId={returnedUser.Id}");
                        break;
                }
            }
            else {
                LoginMesssage = "Invalid username or password";
            }

            return await Task.FromResult(true);
        }


        private async Task<bool> RegisterUser() {
            var returnedResponse = await userService.RegisterStoreAsync(userRegister);

            if (returnedResponse.status == "Success") {
                userlogin.username = userRegister.username;
                userlogin.password = "";
                CheckLogin();
                NavigationManager.NavigateTo("/");
            }
            else {
                LoginMesssage = returnedResponse.message;
            }

            return await Task.FromResult(true);
        }

        private void CheckRegister() {
            checkRegister = true;
        }

        private void CheckLogin() {
            checkRegister = false;
        }

    }
}
