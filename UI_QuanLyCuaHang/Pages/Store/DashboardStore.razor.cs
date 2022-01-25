using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Pages.Store {
    public partial class DashboardStore {

        System.Uri uri;
        int userId;

        public CuaHang _cuahang { get; set; }

        protected override void OnInitialized() {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync() {
            uri = navigation.ToAbsoluteUri(navigation.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("userId", out var _userId)) {
                userId = int.Parse(_userId);
            }
            var checkstore = await checkexiststore(userId);
            if (checkstore == true) {
                //_cuahang = new CuaHang();
                //await GetCuaHangByUserId(userId);
            }
            else {
                _cuahang = new CuaHang();
                navigation.NavigateTo("store/register-store");
            }
            await base.OnInitializedAsync();

        }

        protected override void OnParametersSet() {
            base.OnParametersSet();
        }

        protected override async Task OnParametersSetAsync() {
            await base.OnParametersSetAsync();
        }

        protected override bool ShouldRender() {
            base.ShouldRender();

            return true;
        }
        protected override void OnAfterRender(bool firstRender) {
            base.OnAfterRender(firstRender);
        }

        private async Task<Boolean> checkexiststore(int userId) {
            Boolean checkstore;
            checkstore = await cuahangservice.CheckExistStore($"CuaHang/checkexiststore?userId={userId}");
            return checkstore;
        }

        //private async Task GetCuaHangByUserId(int userId) {
        //    _cuahang = await cuahangservice.GetCuaHangByUserId($"CuaHang/getstorebyuserId?userId={userId}");
        //    StateHasChanged();
        //}
    }
}
