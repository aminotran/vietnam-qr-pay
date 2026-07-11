namespace ICU.Lib.VietQR.Models
{
    /// <summary>Thông tin bổ sung trong mã QR</summary>
    public class AdditionalData
    {
        /// <summary>Số hóa đơn</summary>
        public string? BillNumber { get; set; }

        /// <summary>Số điện thoại di động</summary>
        public string? MobileNumber { get; set; }

        /// <summary>Tên cửa hàng</summary>
        public string? Store { get; set; }

        /// <summary>Mã khách hàng thân thiết</summary>
        public string? LoyaltyNumber { get; set; }

        /// <summary>Mã Tham chiếu</summary>
        public string? Reference { get; set; }

        /// <summary>Mã khách hàng</summary>
        public string? CustomerLabel { get; set; }

        /// <summary>Tên điểm bán</summary>
        public string? Terminal { get; set; }

        /// <summary>Nội dung giao dịch</summary>
        public string? Purpose { get; set; }

        /// <summary>Yêu cầu dữ liệu KH bổ sung</summary>
        public string? DataRequest { get; set; }
    }
}