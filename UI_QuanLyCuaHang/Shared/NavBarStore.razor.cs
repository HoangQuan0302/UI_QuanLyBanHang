using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Shared {
    public partial class NavBarStore {
        private async Task Logout() {
            await ((AuthenticationStateUser)AuthenticationStateProvider).MarkUserAsLoggedOut();
            NavigationManager.NavigateTo("");
        }
    }
}
