using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_QuanLyCuaHang.Shared {
    public partial class NavBar {
        protected async Task ShowMenu() {
            await JSRuntime.InvokeVoidAsync(identifier: "toggle");
        }
    }
}
