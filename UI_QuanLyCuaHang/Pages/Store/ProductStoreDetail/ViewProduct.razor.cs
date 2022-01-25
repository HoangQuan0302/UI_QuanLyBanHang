using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Blazor;
using Microsoft.AspNetCore.WebUtilities;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Pages.Store.ProductStoreDetail {
    public partial class ViewProduct {

        bool ShowFilterRow = false;
        public List<SanPham> _listsanpham;
        System.Uri uri;
        int userId;
        protected override void OnInitialized() {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync() {
            _listsanpham = new List<SanPham>();
            uri = navigation.ToAbsoluteUri(navigation.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("userId", out var _userId)) {
                userId = int.Parse(_userId);
            }
            await base.OnInitializedAsync();
            await LoadCuaHangSanPham(userId);
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

        private async Task LoadCuaHangSanPham(int userId) {
            _listsanpham = await sanphamservice.GetSanPhamCuaHang($"SanPham/cuahang-sanpham?userId={userId}");
            StateHasChanged();
        }

        DataGridColumnResizeMode CurrentMode { get; set; } = DataGridColumnResizeMode.NextColumn;
        DataGridColumnResizeMode[] Modes { get; } = new DataGridColumnResizeMode[] {
            DataGridColumnResizeMode.NextColumn,
            DataGridColumnResizeMode.Component
        };
        void OnShowFilterRow(ToolbarItemClickEventArgs e) {
            ShowFilterRow = !ShowFilterRow;
        }
    }
}
