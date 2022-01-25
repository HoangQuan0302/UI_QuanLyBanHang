using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_QuanLyCuaHang.Pages.Store {
    public partial class ProductStore {
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



        //Handle UI
        Dictionary<int, bool> _dic = new Dictionary<int, bool>() {
            {1,true },
            {2,false },
            {3,false },
        };
        private void ActiveMenu(int k) {
            _dic = new Dictionary<int, bool>();
            for(int i=1;i<=3;i++) {
                if(i==k) {
                    _dic.Add(i, true);
                }
                else {
                    _dic.Add(i, false);
                }
            }
        }
    }
}
