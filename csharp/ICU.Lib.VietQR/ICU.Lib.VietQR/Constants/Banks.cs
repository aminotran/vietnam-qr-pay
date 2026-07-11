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
        /// <summary>Key định danh</summary>
        public string Key { get; set; } = "";
        /// <summary>Mã ngân hàng viết tắt</summary>
        public string Code { get; set; } = "";
        /// <summary>Tên đầy đủ</summary>
        public string Name { get; set; } = "";
        /// <summary>Tên viết tắt</summary>
        public string ShortName { get; set; } = "";
        /// <summary>Mã BIN</summary>
        public string Bin { get; set; } = "";
        /// <summary>Trạng thái hỗ trợ VietQR</summary>
        public VietQRStatus VietQRStatus { get; set; }
        /// <summary>Hỗ trợ lookup (0/1)</summary>
        public int? LookupSupported { get; set; }
        /// <summary>Mã Swift</summary>
        public string? SwiftCode { get; set; }
        /// <summary>Từ khóa tìm kiếm</summary>
        public string? Keywords { get; set; }
        /// <summary>Đã ngừng hỗ trợ?</summary>
        public bool? Deprecated { get; set; }
    }

    /// <summary>
    /// Danh sách đầy đủ các ngân hàng Việt Nam hỗ trợ VietQR
    /// Tham khảo từ: https://github.com/xuannghia/vietnam-qr-pay
    /// </summary>
    public static class BanksObject
    {
        public static Bank ABBank => new()
        {
            Key = "abbank",
            Code = "ABB",
            Name = "Ngân hàng TMCP An Bình",
            ShortName = "AB Bank",
            Bin = "970425",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "ABBKVNVX"
        };

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

        public static Bank BacABank => new()
        {
            Key = "bacabank",
            Code = "BAB",
            Name = "Ngân hàng TMCP Bắc Á",
            ShortName = "BacA Bank",
            Bin = "970409",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "NASCVNVX"
        };

        public static Bank BaoVietBank => new()
        {
            Key = "baoviet",
            Code = "BAOVIETBANK",
            Name = "Ngân hàng TMCP Bảo Việt",
            ShortName = "BaoViet Bank",
            Bin = "970438",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "BVBVVNVX"
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

        public static Bank BIDC => new()
        {
            Key = "bidc",
            Code = "BIDC",
            Name = "Ngân hàng TMCP Đầu tư và Phát triển Campuchia",
            ShortName = "BIDC",
            Bin = "",
            VietQRStatus = VietQRStatus.NOT_SUPPORTED
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

        public static Bank Cake => new()
        {
            Key = "cake",
            Code = "CAKE",
            Name = "Ngân hàng số CAKE by VPBank - Ngân hàng TMCP Việt Nam Thịnh Vượng",
            ShortName = "CAKE by VPBank",
            Bin = "546034",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = null
        };

        public static Bank CBBank => new()
        {
            Key = "cbbank",
            Code = "VNCB",
            Name = "Ngân hàng Thương mại TNHH MTV Xây dựng Việt Nam",
            ShortName = "CB Bank",
            Bin = "970444",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "GTBAVNVX"
        };

        public static Bank CIMB => new()
        {
            Key = "cimb",
            Code = "CIMB",
            Name = "Ngân hàng TNHH MTV CIMB Việt Nam",
            ShortName = "CIMB Bank",
            Bin = "422589",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "CIBBVNVN"
        };

        public static Bank CoopBank => new()
        {
            Key = "coopbank",
            Code = "COOPBANK",
            Name = "Ngân hàng Hợp tác xã Việt Nam",
            ShortName = "Co-op Bank",
            Bin = "970446",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = null
        };

        public static Bank DBSBank => new()
        {
            Key = "dbsbank",
            Code = "DBS",
            Name = "NH TNHH MTV Phát triển Singapore - Chi nhánh TP. Hồ Chí Minh",
            ShortName = "DBS Bank",
            Bin = "796500",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 0,
            SwiftCode = "DBSSVNVX"
        };

        public static Bank DongABank => new()
        {
            Key = "dongabank",
            Code = "DONGABANK",
            Name = "Ngân hàng TMCP Đông Á",
            ShortName = "DongA Bank",
            Bin = "970406",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "EACBVNVX"
        };

        public static Bank Eximbank => new()
        {
            Key = "eximbank",
            Code = "EIB",
            Name = "Ngân hàng TMCP Xuất Nhập khẩu Việt Nam",
            ShortName = "Eximbank",
            Bin = "970431",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "EBVIVNVX"
        };

        public static Bank GPBank => new()
        {
            Key = "gpbank",
            Code = "GPBANK",
            Name = "Ngân hàng Thương mại TNHH MTV Dầu Khí Toàn Cầu",
            ShortName = "GPBank",
            Bin = "970408",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "GBNKVNVX"
        };

        public static Bank HDBank => new()
        {
            Key = "hdbank",
            Code = "HDB",
            Name = "Ngân hàng TMCP Phát triển TP. Hồ Chí Minh",
            ShortName = "HDBank",
            Bin = "970437",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "HDBCVNVX"
        };

        public static Bank HongLeongBank => new()
        {
            Key = "hongleongbank",
            Code = "HLB",
            Name = "Ngân hàng TNHH MTV Hong Leong Việt Nam",
            ShortName = "HongLeong Bank",
            Bin = "970442",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "HLBBVNVX"
        };

        public static Bank HSBC => new()
        {
            Key = "hsbc",
            Code = "HSBC",
            Name = "Ngân hàng TNHH MTV HSBC (Việt Nam)",
            ShortName = "HSBC Vietnam",
            Bin = "458761",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "HSBCVNVX"
        };

        public static Bank IBKHCM => new()
        {
            Key = "ibkhcm",
            Code = "IBKHCM",
            Name = "Ngân hàng Công nghiệp Hàn Quốc - Chi nhánh TP. Hồ Chí Minh",
            ShortName = "IBK HCM",
            Bin = "970456",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 0,
            SwiftCode = null
        };

        public static Bank IBKHN => new()
        {
            Key = "ibkhn",
            Code = "IBKHN",
            Name = "Ngân hàng Công nghiệp Hàn Quốc - Chi nhánh Hà Nội",
            ShortName = "IBK HN",
            Bin = "970455",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 0,
            SwiftCode = null
        };

        public static Bank IndovinaBank => new()
        {
            Key = "indovinabank",
            Code = "IVB",
            Name = "Ngân hàng TNHH Indovina",
            ShortName = "Indovina Bank",
            Bin = "970434",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = null
        };

        public static Bank KasikornBank => new()
        {
            Key = "kasikorn",
            Code = "KBANK",
            Name = "Ngân hàng Đại chúng TNHH KASIKORNBANK - CN TP. Hồ Chí Minh",
            ShortName = "Kasikornbank",
            Bin = "668888",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "KASIVNVX"
        };

        public static Bank KienlongBank => new()
        {
            Key = "kienlongbank",
            Code = "KLB",
            Name = "Ngân hàng TMCP Kiên Long",
            ShortName = "KienlongBank",
            Bin = "970452",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "KLBKVNVX"
        };

        public static Bank KookminBankHCM => new()
        {
            Key = "kookminhcm",
            Code = "KBHCM",
            Name = "Ngân hàng Kookmin - Chi nhánh TP. Hồ Chí Minh",
            ShortName = "Kookmin Bank HCM",
            Bin = "970463",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 0,
            SwiftCode = null
        };

        public static Bank KookminBankHN => new()
        {
            Key = "kookminhn",
            Code = "KBHN",
            Name = "Ngân hàng Kookmin - Chi nhánh Hà Nội",
            ShortName = "Kookmin Bank HN",
            Bin = "970462",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 0,
            SwiftCode = null
        };

        public static Bank LienVietPostBank => new()
        {
            Key = "lienvietpostbank",
            Code = "LPB",
            Name = "Ngân hàng TMCP Bưu Điện Liên Việt",
            ShortName = "LienVietPostBank",
            Bin = "970449",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "LVBKVNVX",
            Deprecated = true
        };

        public static Bank LPBank => new()
        {
            Key = "lpbank",
            Code = "LPB",
            Name = "Ngân hàng TMCP Lộc Phát Việt Nam",
            ShortName = "LPBank",
            Bin = "970449",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "LVBKVNVX"
        };

        public static Bank LioBank => new()
        {
            Key = "liobank",
            Code = "LIOBANK",
            Name = "Ngân hàng số Liobank - Ngân hàng TMCP Phương Đông",
            ShortName = "Liobank",
            Bin = "963369",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = null
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

        public static Bank MBV => new()
        {
            Key = "mbv",
            Code = "MBV",
            Name = "Ngân hàng TNHH MTV Việt Nam Hiện Đại",
            ShortName = "MBV",
            Bin = "970414",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "OCBKUS3M"
        };

        public static Bank MSB => new()
        {
            Key = "msb",
            Code = "MSB",
            Name = "Ngân hàng TMCP Hàng Hải",
            ShortName = "MSB",
            Bin = "970426",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "MCOBVNVX"
        };

        public static Bank NamABank => new()
        {
            Key = "namabank",
            Code = "NAB",
            Name = "Ngân hàng TMCP Nam Á",
            ShortName = "Nam A Bank",
            Bin = "970428",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "NAMAVNVX"
        };

        public static Bank NCB => new()
        {
            Key = "ncb",
            Code = "NVB",
            Name = "Ngân hàng TMCP Quốc Dân",
            ShortName = "NCB Bank",
            Bin = "970419",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "NVBAVNVX"
        };

        public static Bank NonghyupBankHN => new()
        {
            Key = "nonghyup",
            Code = "NONGHYUP",
            Name = "Ngân hàng Nonghyup - Chi nhánh Hà Nội",
            ShortName = "Nonghyup Bank",
            Bin = "801011",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 0,
            SwiftCode = null
        };

        public static Bank OCB => new()
        {
            Key = "ocb",
            Code = "OCB",
            Name = "Ngân hàng TMCP Phương Đông",
            ShortName = "OCB Bank",
            Bin = "970448",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "ORCOVNVX"
        };

        public static Bank OceanBank => new()
        {
            Key = "oceanbank",
            Code = "OCEANBANK",
            Name = "Ngân hàng Thương mại TNHH MTV Đại Dương",
            ShortName = "Ocean Bank",
            Bin = "970414",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "OCBKUS3M",
            Deprecated = true
        };

        public static Bank PGBank => new()
        {
            Key = "pgbank",
            Code = "PGB",
            Name = "Ngân hàng TMCP Xăng dầu Petrolimex",
            ShortName = "PG Bank",
            Bin = "970430",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "PGBLVNVX"
        };

        public static Bank PublicBank => new()
        {
            Key = "publicbank",
            Code = "PBVN",
            Name = "Ngân hàng TNHH MTV Public Việt Nam",
            ShortName = "Public Bank Vietnam",
            Bin = "970439",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "VIDPVNVX"
        };

        public static Bank PVcomBank => new()
        {
            Key = "pvcombank",
            Code = "PVCOMBANK",
            Name = "Ngân hàng TMCP Đại Chúng Việt Nam",
            ShortName = "PVcomBank",
            Bin = "970412",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "WBVNVNVX"
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

        public static Bank SaigonBank => new()
        {
            Key = "saigonbank",
            Code = "SGB",
            Name = "Ngân hàng TMCP Sài Gòn Công Thương",
            ShortName = "SaigonBank",
            Bin = "970400",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "SBITVNVX"
        };

        public static Bank SCB => new()
        {
            Key = "scb",
            Code = "SCB",
            Name = "Ngân hàng TMCP Sài Gòn",
            ShortName = "SCB",
            Bin = "970429",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "SACLVNVX"
        };

        public static Bank SeABank => new()
        {
            Key = "seabank",
            Code = "SSB",
            Name = "Ngân hàng TMCP Đông Nam Á",
            ShortName = "SeABank",
            Bin = "970440",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "SEAVVNVX"
        };

        public static Bank SHB => new()
        {
            Key = "shb",
            Code = "SHB",
            Name = "Ngân hàng TMCP Sài Gòn - Hà Nội",
            ShortName = "SHB",
            Bin = "970443",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "SHBAVNVX"
        };

        public static Bank ShinhanBank => new()
        {
            Key = "shinhanbank",
            Code = "SVB",
            Name = "Ngân hàng TNHH MTV Shinhan Việt Nam",
            ShortName = "Shinhan Bank",
            Bin = "970424",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "SHBKVNVX"
        };

        public static Bank StandardCharteredBank => new()
        {
            Key = "standardcharteredbank",
            Code = "SC",
            Name = "Ngân hàng TNHH MTV Standard Chartered Bank Việt Nam",
            ShortName = "Standard Chartered Vietnam",
            Bin = "970410",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = "SCBLVNVX"
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

        public static Bank Timo => new()
        {
            Key = "timo",
            Code = "TIMO",
            Name = "Ngân hàng số Timo by Bản Việt Bank",
            ShortName = "Timo",
            Bin = "963388",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 0,
            SwiftCode = null
        };

        public static Bank TPBank => new()
        {
            Key = "tpbank",
            Code = "TPB",
            Name = "Ngân hàng TMCP Tiên Phong",
            ShortName = "TPBank",
            Bin = "970423",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "TPBVVNVX"
        };

        public static Bank UBank => new()
        {
            Key = "ubank",
            Code = "UBANK",
            Name = "Ngân hàng số Ubank by VPBank - Ngân hàng TMCP Việt Nam Thịnh Vượng",
            ShortName = "Ubank by VPBank",
            Bin = "546035",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = null
        };

        public static Bank UnitedOverseasBank => new()
        {
            Key = "uob",
            Code = "UOB",
            Name = "Ngân hàng United Overseas Bank Việt Nam",
            ShortName = "United Overseas Bank Vietnam",
            Bin = "970458",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = null
        };

        public static Bank VIB => new()
        {
            Key = "vib",
            Code = "VIB",
            Name = "Ngân hàng TMCP Quốc tế Việt Nam",
            ShortName = "VIB",
            Bin = "970441",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "VNIBVNVX"
        };

        public static Bank VietABank => new()
        {
            Key = "vietabank",
            Code = "VAB",
            Name = "Ngân hàng TMCP Việt Á",
            ShortName = "VietABank",
            Bin = "970427",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "VNACVNVX"
        };

        public static Bank VietBank => new()
        {
            Key = "vietbank",
            Code = "VBB",
            Name = "Ngân hàng TMCP Việt Nam Thương Tín",
            ShortName = "VietBank",
            Bin = "970433",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "VNTTVNVX"
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

        public static Bank Vikki => new()
        {
            Key = "vikki",
            Code = "VIKKI",
            Name = "Ngân hàng TNHH MTV Số Vikki",
            ShortName = "Vikki Bank",
            Bin = "970406",
            VietQRStatus = VietQRStatus.TRANSFER_SUPPORTED,
            LookupSupported = 1,
            SwiftCode = "EACBVNVX"
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

        public static Bank VRB => new()
        {
            Key = "vrb",
            Code = "VRB",
            Name = "Ngân hàng Liên doanh Việt - Nga",
            ShortName = "VietNgaBank",
            Bin = "970421",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = null
        };

        public static Bank WooriBank => new()
        {
            Key = "wooribank",
            Code = "WRB",
            Name = "Ngân hàng TNHH MTV Woori Việt Nam",
            ShortName = "Woori Bank",
            Bin = "970457",
            VietQRStatus = VietQRStatus.RECEIVE_ONLY,
            LookupSupported = 1,
            SwiftCode = null
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
            ABBank, Acb, Agribank, BacABank, BaoVietBank, BanViet, BIDC, BIDV, Cake, CBBank, CIMB,
            CoopBank, DBSBank, DongABank, Eximbank, GPBank, HDBank, HongLeongBank, HSBC,
            IBKHCM, IBKHN, IndovinaBank, KasikornBank, KienlongBank, KookminBankHCM, KookminBankHN,
            LienVietPostBank, LPBank, LioBank, MBBank, MBV, MSB, NamABank, NCB, NonghyupBankHN,
            OCB, OceanBank, PGBank, PublicBank, PVcomBank, Sacombank, SaigonBank, SCB, SeABank,
            SHB, ShinhanBank, StandardCharteredBank, Techcombank, Timo, TPBank, UBank,
            UnitedOverseasBank, VIB, VietABank, VietBank, Vietcombank, Vietinbank, Vikki,
            VPBank, VRB, WooriBank
        };
    }
}