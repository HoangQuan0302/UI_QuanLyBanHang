using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Pages.Store {
    public partial class RegisterStore {

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
            _cuahang = new CuaHang();
            await GetCuaHangByUserId(userId);
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

        private async Task GetCuaHangByUserId(int userId) {
            _cuahang = await cuahangservice.GetCuaHangByUserId($"CuaHang/getstorebyuserId?userId={userId}");
            StateHasChanged();
        }
        private async Task<bool> CategoryStore_Fun() {
            navigation.NavigateTo("/store/category-store");
            return await Task.FromResult(true);
        }
    }
}



