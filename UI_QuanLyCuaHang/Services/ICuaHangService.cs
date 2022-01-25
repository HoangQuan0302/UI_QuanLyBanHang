using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Services {
    public interface ICuaHangService {
        Task<Boolean> CheckExistStore(string requestUri);
        Task<CuaHang> GetCuaHangByUserId(string requestUri);

        Task<ResponseMessageModel> TaoCuaHang(CuaHang cuahang);
    }
}
