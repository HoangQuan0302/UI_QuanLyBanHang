using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_QuanLyCuaHang.Data {
    public partial class CuaHang {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("chiTietCuaHangId")]
        public int? ChiTietCuaHangId { get; set; }

        [JsonProperty("chiTietCuaHang")]
        public ChiTietCuaHang ChiTietCuaHang { get; set; }

        [JsonProperty("trangThaiKichHoat")]
        public bool TrangThaiKichHoat { get; set; }

        [JsonProperty("tenCuaHang")]
        public string TenCuaHang { get; set; }

        [JsonProperty("soDienThoaiLienHe")]
        public string SoDienThoaiLienHe { get; set; }

        [JsonProperty("loaiHinhDangKy")]
        public string LoaiHinhDangKy { get; set; }

        [JsonProperty("tenNguoiDaiDien")]
        public string TenNguoiDaiDien { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("soDienThoaiNguoiDaiDien")]
        public string SoDienThoaiNguoiDaiDien { get; set; }

        [JsonProperty("hinhChungMinhNhanDanMatTruocId")]
        public int? HinhChungMinhNhanDanMatTruocId { get; set; }

        [JsonProperty("hinhChungMinhNhanDanMatSauId")]
        public int? HinhChungMinhNhanDanMatSauId { get; set; }

        [JsonProperty("hinhChungMinhNhanDan")]
        public HinhChungMinhNhanDan[] HinhChungMinhNhanDan { get; set; }

        [JsonProperty("maSoThue")]
        public string MaSoThue { get; set; }

        [JsonProperty("diaChiCuaHangId")]
        public int? DiaChiCuaHangId { get; set; }

        [JsonProperty("diaChiCuaHang")]
        public DiaChi DiaChiCuaHang { get; set; }

        [JsonProperty("loaiCHId")]
        public int LoaiChId { get; set; }

        [JsonProperty("loaiCH")]
        public LoaiCh LoaiCh { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("user")]
        public UserCuaHang User { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public partial class ChiTietCuaHang {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cuaHangId")]
        public int CuaHangId { get; set; }

        [JsonProperty("thoiGianId")]
        public int ThoiGianId { get; set; }

        [JsonProperty("thoiGian")]
        public ThoiGian ThoiGian { get; set; }

        [JsonProperty("tuKhoaTimKiem")]
        public string TuKhoaTimKiem { get; set; }

        [JsonProperty("mieuTaQuan")]
        public string MieuTaQuan { get; set; }

        [JsonProperty("anhDaiDienId")]
        public int AnhDaiDienId { get; set; }

        [JsonProperty("anhBiaId")]
        public int AnhBiaId { get; set; }

        [JsonProperty("anhQuan")]
        public HinhChungMinhNhanDan[] AnhQuan { get; set; }
    }

    public partial class HinhChungMinhNhanDan {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ten")]
        public string Ten { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public partial class ThoiGian {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cuaHangId")]
        public int CuaHangId { get; set; }

        [JsonProperty("chuNhat")]
        public bool ChuNhat { get; set; }

        [JsonProperty("gioMoCuaCN")]
        public TimeSpan GioMoCuaCn { get; set; }

        [JsonProperty("gioDongCuaCN")]
        public TimeSpan GioDongCuaCn { get; set; }

        [JsonProperty("thuHai")]
        public bool ThuHai { get; set; }

        [JsonProperty("gioMoCuaT2")]
        public TimeSpan GioMoCuaT2 { get; set; }

        [JsonProperty("gioDongCuaT2")]
        public TimeSpan GioDongCuaT2 { get; set; }

        [JsonProperty("thuBa")]
        public bool ThuBa { get; set; }

        [JsonProperty("gioMoCuaT3")]
        public TimeSpan GioMoCuaT3 { get; set; }

        [JsonProperty("gioDongCuaT3")]
        public TimeSpan GioDongCuaT3 { get; set; }

        [JsonProperty("thuTu")]
        public bool ThuTu { get; set; }

        [JsonProperty("gioMoCuaT4")]
        public TimeSpan GioMoCuaT4 { get; set; }

        [JsonProperty("gioDongCuaT4")]
        public TimeSpan GioDongCuaT4 { get; set; }

        [JsonProperty("thuNam")]
        public bool ThuNam { get; set; }

        [JsonProperty("gioMoCuaT5")]
        public TimeSpan GioMoCuaT5 { get; set; }

        [JsonProperty("gioDongCuaT5")]
        public TimeSpan GioDongCuaT5 { get; set; }

        [JsonProperty("thuSau")]
        public bool ThuSau { get; set; }

        [JsonProperty("gioMoCuaT6")]
        public TimeSpan GioMoCuaT6 { get; set; }

        [JsonProperty("gioDongCuaT6")]
        public TimeSpan GioDongCuaT6 { get; set; }

        [JsonProperty("thuBay")]
        public bool ThuBay { get; set; }

        [JsonProperty("gioMoCuaT7")]
        public TimeSpan GioMoCuaT7 { get; set; }

        [JsonProperty("gioDongCuaT7")]
        public TimeSpan GioDongCuaT7 { get; set; }
    }

    public partial class DiaChi {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("soNhaTo")]
        public string SoNhaTo { get; set; }

        [JsonProperty("duong")]
        public string Duong { get; set; }

        [JsonProperty("xaPhuong")]
        public string XaPhuong { get; set; }

        [JsonProperty("quanHuyen")]
        public string QuanHuyen { get; set; }

        [JsonProperty("tinhTP")]
        public string TinhTp { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public partial class LoaiCh {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ten")]
        public string Ten { get; set; }

        [JsonProperty("dienGiai")]
        public string DienGiai { get; set; }

        [JsonProperty("hinhAnhId")]
        public int HinhAnhId { get; set; }

        [JsonProperty("hinhAnh")]
        public HinhChungMinhNhanDan HinhAnh { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public partial class UserCuaHang {
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
        public DateTimeOffset LockoutEnd { get; set; }

        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [JsonProperty("accessFailedCount")]
        public int AccessFailedCount { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sdt")]
        public string Sdt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("hoTen")]
        public string HoTen { get; set; }

        [JsonProperty("gioiTinh")]
        public string GioiTinh { get; set; }

        [JsonProperty("ngaySinh")]
        public DateTimeOffset NgaySinh { get; set; }

        [JsonProperty("avatarId")]
        public int AvatarId { get; set; }

        [JsonProperty("avatar")]
        public HinhChungMinhNhanDan Avatar { get; set; }

        [JsonProperty("diaChiId")]
        public int? DiaChiId { get; set; }

        [JsonProperty("diaChi")]
        public DiaChi DiaChi { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
