
using DevExpress.Blazor;
using DevExpress.Entity.Model.Metadata;
using DevExpress.Utils.CommonDialogs;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Pages.Store.ProductStoreDetail {
    public partial class ImportProduct {

        System.Uri uri;
        int userId;
        public List<SanPham> _listsanpham;
        IBrowserFile file;
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

        private void LoadFiles(InputFileChangeEventArgs e) {
            file= e.File;
            ImportSanPham(file);
        }

        private async Task ImportSanPham(IBrowserFile file) {
            var filePath = Path.GetFullPath(file.Name);
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(fileInfo)) {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                var totalColumn = worksheet.Dimension.End.Column;
                var totalRow = worksheet.Dimension.End.Row;
                for (int row = 1; row <= totalRow; row++) {
                    SanPham sp = new SanPham();
                    for (int col = 1; col <= totalColumn; col++) {
                        if (col == 1) sp.Ten = worksheet.Cells[row, 1].Value.ToString().Trim();
                        if (col == 2) sp.GiaSp = long.Parse(worksheet.Cells[row, 2].Value.ToString());
                        if (col == 3) sp.MoTa = worksheet.Cells[row, 3].Value.ToString().Trim();
                        if (col == 4) sp.HinhSanPhamId = long.Parse(worksheet.Cells[row, 4].ToString());
                        if (col == 5) sp.LoaiSpId = long.Parse(worksheet.Cells[row, 5].ToString());
                        if (col == 6) sp.NsxId = long.Parse(worksheet.Cells[row, 6].ToString());
                        if (col == 7) sp.SoLuong = long.Parse(worksheet.Cells[row, 7].ToString());
                    }
                    _listsanpham.Add(sp);
                }
            }
        }


        bool ShowFilterRow = false;
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
