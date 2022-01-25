using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_QuanLyCuaHang.Data {
    public class User {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("SDT")]
        public string Sdt { get; set; }

        [JsonProperty("HoTen")]
        public string HoTen { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("GioiTinh")]
        public string GioiTinh { get; set; }

        [JsonProperty("NgaySinh")]
        public string NgaySinh { get; set; }

        [JsonProperty("AvatarId")]
        public int? AvatarId { get; set; }

        [JsonProperty("DiaChiId")]
        public int? DiaChiId { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("role")]
        public string[] Role { get; set; }

        [JsonProperty("expires")]
        public int Expires { get; set; }
    }
}
