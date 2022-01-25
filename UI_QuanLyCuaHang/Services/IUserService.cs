using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_QuanLyCuaHang.Data;

namespace UI_QuanLyCuaHang.Services {
    public interface IUserService {
        public Task<User> LoginAsync(User user);
        public Task<ResponseMessageModel> RegisterStoreAsync(User user);
        public Task<User> GetUserByAccessTokenAsync(string accessToken);
        public Task<User> RefreshTokenAsync(RefreshRequest refreshRequest);
    }
}
