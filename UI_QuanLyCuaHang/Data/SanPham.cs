using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_QuanLyCuaHang.Data {
    public partial class SanPham {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ten")]
        public string Ten { get; set; }

        [JsonProperty("giaSP")]
        public long GiaSp { get; set; }

        [JsonProperty("ngaySanXuat")]
        public string NgaySanXuat { get; set; }

        [JsonProperty("moTa")]
        public string MoTa { get; set; }

        [JsonProperty("hinhSanPhamId")]
        public long HinhSanPhamId { get; set; }

        [JsonProperty("hinhSanPham")]
        public HinhSanPham HinhSanPham { get; set; }

        [JsonProperty("loaiSPId")]
        public long LoaiSpId { get; set; }

        [JsonProperty("loaiSP")]
        public HinhSanPham LoaiSp { get; set; }

        [JsonProperty("nsxId")]
        public long NsxId { get; set; }

        [JsonProperty("nsx")]
        public Nsx Nsx { get; set; }

        [JsonProperty("cuaHangSanPham")]
        public CuaHangSanPham[] CuaHangSanPham { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("soLuong")]
        public long SoLuong { get; set; }
    }

    public partial class CuaHangSanPham {
        [JsonProperty("cuaHangId")]
        public long CuaHangId { get; set; }

        [JsonProperty("sanPhamId")]
        public long SanPhamId { get; set; }

        [JsonProperty("soLuong")]
        public long SoLuong { get; set; }

        [JsonProperty("cuaHang")]
        public CuaHang CuaHang { get; set; }

        [JsonProperty("sanPham")]
        public string SanPham { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public partial class HinhSanPham {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ten")]
        public string Ten { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
    public partial class UserSP {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("normalizedUserName")]
        public string NormalizedUserName { get; set; }

        [JsonProperty("normalizedEmail")]
        public string NormalizedEmail { get; set; }

        [JsonProperty("emailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty("securityStamp")]
        public string SecurityStamp { get; set; }

        [JsonProperty("concurrencyStamp")]
        public string ConcurrencyStamp { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [JsonProperty("twoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [JsonProperty("lockoutEnd")]
        public string LockoutEnd { get; set; }

        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [JsonProperty("accessFailedCount")]
        public long AccessFailedCount { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sdt")]
        public string Sdt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("hoTen")]
        public string HoTen { get; set; }

        [JsonProperty("gioiTinh")]
        public string GioiTinh { get; set; }

        [JsonProperty("ngaySinh")]
        public string NgaySinh { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }

        [JsonProperty("avatar")]
        public HinhSanPham Avatar { get; set; }

        [JsonProperty("diaChiId")]
        public long UserDiaChiId { get; set; }

        [JsonProperty("diaChi")]
        public DiaChi DiaChi { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public partial class Nsx {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ten")]
        public string Ten { get; set; }

        [JsonProperty("diaChiId")]
        public long DiaChiId { get; set; }

        [JsonProperty("diaChi")]
        public DiaChi DiaChi { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
