namespace ICU.Lib.VietQR.Models
{
    /// <summary>Thông tin merchant (Đơn vị chấp nhận thanh toán)</summary>
    public class Merchant
    {
        /// <summary>Mã định danh đơn vị CNTT</summary>
        public string? Id { get; set; }

        /// <summary>Tên đơn vị CNTT</summary>
        public string? Name { get; set; }
    }
}