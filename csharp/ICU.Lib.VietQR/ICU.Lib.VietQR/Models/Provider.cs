using ICU.Lib.VietQR.Enums;

namespace ICU.Lib.VietQR.Models
{
    public class Provider
    {
        /// <summary>Mã field ID của provider (26 - VNPay, 38 - VietQR)</summary>
        public string? FieldId { get; set; }

        /// <summary>Tên nhà cung cấp (VIETQR / VNPAY)</summary>
        public QRProvider? Name { get; set; }

        /// <summary>Mã định danh toàn cầu (GUID)</summary>
        public string? Guid { get; set; }

        /// <summary>Mã dịch vụ</summary>
        public string? Service { get; set; }

        /// <summary>Dữ liệu provider (raw)</summary>
        public string? Data { get; set; }
    }
}