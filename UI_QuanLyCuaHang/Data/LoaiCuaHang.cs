using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_QuanLyCuaHang.Data {
    public partial class LoaiCuaHang {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Ten")]
        public string Ten { get; set; }

        [JsonProperty("DienGiai")]
        public string DienGiai { get; set; }

        [JsonProperty("HinhAnhId")]
        public long HinhAnhId { get; set; }

        [JsonProperty("HinhAnh")]
        public HinhAnh HinhAnh { get; set; }

        [JsonProperty("CreatedAt")]
        public object CreatedAt { get; set; }

        [JsonProperty("UpdatedAt")]
        public object UpdatedAt { get; set; }
    }

    public partial class HinhAnh {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Ten")]
        public string Ten { get; set; }

        [JsonProperty("Url")]
        public Uri Url { get; set; }

        [JsonProperty("CreatedAt")]
        public object CreatedAt { get; set; }

        [JsonProperty("UpdatedAt")]
        public object UpdatedAt { get; set; }
    }
}
