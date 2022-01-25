using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Pages.Store {
    public partial class CategoryStore {
        public LoaiCuaHang _loaicuahang { get; set; }
        public List<LoaiCuaHang> _listLoaiCuaHang { get; set; }
        public CuaHang _cuahang = new CuaHang();

        protected override void OnInitialized() {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync() {
            _loaicuahang = new LoaiCuaHang();
            _listLoaiCuaHang = new List<LoaiCuaHang>();

            await base.OnInitializedAsync();
            await LoadCategoryStore();
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

        private async Task LoadCategoryStore() {
            _listLoaiCuaHang = await  loaicuahangservice.GetAllAsync("LoaiCuaHang/getall-category-store");

            StateHasChanged();
        }

        private async Task<bool> SignContract() {
            var currentUser = await _localStorageService.GetItemAsync<User>("currentUser");
            _cuahang.UserId = currentUser.Id;
           var initStore= await InitCategoryStore();
            if(initStore.status=="Success") {
                NavigationManager.NavigateTo("/store/sign-contract-store");
                return await Task.FromResult(true);
            }
            else {
                return await Task.FromResult(false);
            }
        }

        private async Task<ResponseMessageModel> InitCategoryStore() {
            var response=await cuahangservice.TaoCuaHang(_cuahang);
            StateHasChanged();
            return response;
        }

        private async Task<bool> RegisterStore_Fun() {
            NavigationManager.NavigateTo("/store/register-store");
            return await Task.FromResult(true);
        }





        // Handling UI

        public string activeCurrentCategory = string.Empty;

        public Dictionary<int, Boolean> _dic = new Dictionary<int, bool>();
        private void SelectCategory(int cateId) {
            _dic = new Dictionary<int, bool>();
            foreach (var item in _listLoaiCuaHang) {
                if(cateId==item.Id) {
                    _dic.Add(item.Id, true);
                    _cuahang.LoaiChId = item.Id;
                }
                else {
                    _dic.Add(item.Id, false);
                }
            }
        }

    }
}
