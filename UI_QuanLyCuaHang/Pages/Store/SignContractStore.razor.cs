using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Pages.Store {
    public partial class SignContractStore {

        public HopDong _hopdong = new HopDong();
        protected override void OnInitialized() {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync() {

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
        private async Task<bool> CategoryStore_Fun() {
            NavigationManager.NavigateTo("/store/category-store");
            return await Task.FromResult(true);
        }

        private async Task<bool> RegisterStoreBasicInfo() {
            var currentUser = await _localStorageService.GetItemAsync<User>("currentUser");
            _hopdong.userName = currentUser.username;
            await SaveBackFile();
            NavigationManager.NavigateTo(" /store/register-store-basic-info");
            return await Task.FromResult(true);
        }


        private async Task SaveBackFile() {
            byte[] data = await viewer.GetDocument();
            //PDF document file stream
            Stream stream = new MemoryStream(data);
            using (var fileStream = new FileStream(@"wwwroot\Data\contract_bi_signed.pdf", FileMode.Create, FileAccess.Write)) {
                //Saving the new file in root path of application
                stream.CopyTo(fileStream);
                fileStream.Close();
            }
            stream.Close();
        }
    }
}
