using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Services {
    public interface ISanPhamService {
        Task<List<SanPham>> GetSanPhamCuaHang(string requestUri);
    }
}
