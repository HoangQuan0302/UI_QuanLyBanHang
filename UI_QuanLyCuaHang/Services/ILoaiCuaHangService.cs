using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_QuanLyCuaHang.Services {
    public interface ILoaiCuaHangService<T> {
        Task<List<T>> GetAllAsync(string requestUri);
    }
}
