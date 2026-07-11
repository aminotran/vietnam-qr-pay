namespace ICU.Lib.VietQR.Models
{
    /// <summary>Thông tin người thanh toán (chủ tài khoản)</summary>
    public class Consumer
    {
        /// <summary>Mã ngân hàng (BIN)</summary>
        public string? BankBin { get; set; }

        /// <summary>Số tài khoản</summary>
        public string? BankNumber { get; set; }
    }
}