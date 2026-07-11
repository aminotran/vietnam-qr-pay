using System.Collections.Generic;

namespace ICU.Lib.VietQR.Constants
{
    /// <summary>Trạng thái hỗ trợ VietQR</summary>
    public enum VietQRStatus
    {
        /// <summary>Không hỗ trợ</summary>
        NOT_SUPPORTED = -1,
        /// <summary>Chỉ nhận</summary>
        RECEIVE_ONLY = 0,
        /// <summary>Hỗ trợ chuyển và nhận</summary>
        TRANSFER_SUPPORTED = 1
    }

    /// <summary>Thông tin ngân hàng</summary>
    public class Bank
    {
        public string Key { get; set; } = "";
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string ShortName { get; set; } = "";
        public string Bin { get; set; } = "";
        public VietQRStatus VietQRStatus { get; set; }
        public int? LookupSupported { get; set; }
        public string? SwiftCode { get; set; }
        public string? Keywords { get; set; }
        public bool? Deprecated { get; set; }
    }

    /// <summary>
    /// Danh sách các ngân hàng Việt Nam hỗ trợ VietQR
    /// Tham khảo đầy đủ tại: https://github.com/xuannghia/vietnam-qr-pay
    /// </summary>
    public static class BanksObject
    {
        public static Bank Acb => new()
        {
            Key = "acb",
            Code = "ACB",
            Name = "Ngân hàng TMCP Á Châu",
            ShortName = "ACB",
            Bin = "970416",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "ASCBVNVX"
        };

        public static Bank Vietcombank => new()
        {
            Key = "vietcombank",
            Code = "VCB",
            Name = "Ngân hàng TMCP Ngoại Thương Việt Nam",
            ShortName = "Vietcombank",
            Bin = "970436",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "BFTVVNVX"
        };

        public static Bank Techcombank => new()
        {
            Key = "techcombank",
            Code = "TCB",
            Name = "Ngân hàng TMCP Kỹ thương Việt Nam",
            ShortName = "Techcombank",
            Bin = "970407",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "VTCBVNVX"
        };

        public static Bank BIDV => new()
        {
            Key = "bidv",
            Code = "BID",
            Name = "Ngân hàng TMCP Đầu tư và Phát triển Việt Nam",
            ShortName = "BIDV",
            Bin = "970418",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "BIDVVNVX"
        };

        public static Bank Vietinbank => new()
        {
            Key = "vietinbank",
            Code = "CTG",
            Name = "Ngân hàng TMCP Công thương Việt Nam",
            ShortName = "VietinBank",
            Bin = "970415",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "ICBVVNVX"
        };

        public static Bank MBBank => new()
        {
            Key = "mbbank",
            Code = "MBB",
            Name = "Ngân hàng TMCP Quân đội",
            ShortName = "MB Bank",
            Bin = "970422",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "MSCBVNVX"
        };

        public static Bank Agribank => new()
        {
            Key = "agribank",
            Code = "AGRIBANK",
            Name = "Ngân hàng Nông nghiệp và Phát triển Nông thôn Việt Nam",
            ShortName = "Agribank",
            Bin = "970405",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "VBAAVNVX"
        };

        public static Bank BanViet => new()
        {
            Key = "banviet",
            Code = "BVB",
            Name = "Ngân hàng TMCP Bản Việt",
            ShortName = "BVBank",
            Bin = "970454",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "VCBCVNVX"
        };

        public static Bank Sacombank => new()
        {
            Key = "sacombank",
            Code = "STB",
            Name = "Ngân hàng TMCP Sài Gòn Thương Tín",
            ShortName = "Sacombank",
            Bin = "970403",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "SGTTVNVX"
        };

        public static Bank VPBank => new()
        {
            Key = "vpbank",
            Code = "VPB",
            Name = "Ngân hàng TMCP Việt Nam Thịnh Vượng",
            ShortName = "VPBank",
            Bin = "970432",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "VPBKVNVX"
        };

        /// <summary>Tra cứu thông tin ngân hàng theo BIN</summary>
        public static Bank? FindByBin(string bin)
        {
            return AllBanks.Find(b => b.Bin == bin);
        }

        /// <summary>Tra cứu thông tin ngân hàng theo tên viết tắt</summary>
        public static Bank? FindByShortName(string shortName)
        {
            return AllBanks.Find(b =>
                b.ShortName.Equals(shortName, System.StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Danh sách tất cả ngân hàng</summary>
        public static List<Bank> AllBanks => new()
        {
            Acb, Vietcombank, Techcombank, BIDV, Vietinbank,
            MBBank, Agribank, BanViet, Sacombank, VPBank
        };
    }
}