using System.Collections.Generic;

namespace ICU.Lib.VietQR.Constants
{
    /// <summary>Thông tin ứng dụng ngân hàng (deeplink, app store)</summary>
    public class BankApp
    {
        /// <summary>Mã ngân hàng</summary>
        public BankKey Bank { get; set; }
        /// <summary>Scheme deeplink</summary>
        public string? Scheme { get; set; }
        /// <summary>Package ID Android</summary>
        public string? PackageId { get; set; }
        /// <summary>App Store ID iOS</summary>
        public string? AppStoreId { get; set; }
        /// <summary>Hỗ trợ VietQR</summary>
        public bool SupportVietQR { get; set; }
        /// <summary>Hỗ trợ mở deeplink trên web VNPay</summary>
        public bool SupportVNPayQR { get; set; }
    }

    /// <summary>Danh sách ứng dụng ngân hàng hỗ trợ deeplink</summary>
    public static class BankApps
    {
        public static List<BankApp> All => new()
        {
            new() { Bank = BankKey.ABBANK, Scheme = "abbankmobile", PackageId = "com.vnpay.abbank", AppStoreId = "id1137160023", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.ACB, Scheme = "acbapp", PackageId = "mobile.acb.com.vn", AppStoreId = "id950141024", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.AGRIBANK, Scheme = "agribankmobile", PackageId = "com.vnpay.Agribank3g", AppStoreId = "id935944952", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.BAC_A_BANK, PackageId = "com.bab.retailUAT", AppStoreId = "id1441408786", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.BAOVIET_BANK, Scheme = "baovietmobile", PackageId = "com.vnpay.bvbank", AppStoreId = "id1504422967", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.BIDC, Scheme = "bidcvnmobile", PackageId = "com.vnpay.bidc", AppStoreId = "id1043501726", SupportVietQR = false, SupportVNPayQR = true },
            new() { Bank = BankKey.BIDV, Scheme = "bidvsmartbanking", PackageId = "com.vnpay.bidv", AppStoreId = "id1061867449", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.CAKE, Scheme = "cake.vn", PackageId = "xyz.be.cake", AppStoreId = "id1551907051", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.CBBANK, PackageId = "cbbank.vn.mobile", AppStoreId = "id1531443181", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.CIMB, Scheme = "cimb", PackageId = "vn.cimbbank.octo", AppStoreId = "id1318127958", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.COOP_BANK, Scheme = "coopbankmobile", PackageId = "com.vnpay.coopbank", AppStoreId = "id1578445811", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.DBS_BANK, PackageId = "com.dbs.sg.dbsmbanking", AppStoreId = "id1068403826", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.DONG_A_BANK, PackageId = "com.dongabank.mobilenternet", AppStoreId = "id993124125", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.EXIMBANK, Scheme = "eximbankmobile", PackageId = "com.vnpay.eximbank", AppStoreId = "id1242260338", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.GPBANK, SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.HDBANK, Scheme = "hdbankmobile", PackageId = "com.vnpay.hdbank", AppStoreId = "id1461658565", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.HONGLEONG_BANK, PackageId = "my.com.hongleongconnect.mobileconnect", AppStoreId = "id1446719260", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.HSBC, PackageId = "vn.hsbc.hsbcvietnam", AppStoreId = "id1472163155", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.IBK_HCM, Scheme = "ionebankglobal", PackageId = "com.ibk.neobanking.mini", AppStoreId = "id787064809", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.IBK_HN, SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.INDOVINA_BANK, Scheme = "ivbmobilebanking", PackageId = "com.vnpay.ivb", AppStoreId = "id1096963960", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.KASIKORN_BANK, PackageId = "com.kasikornbank.kplus.vn", AppStoreId = "id1586576195", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.KIENLONG_BANK, Scheme = "kienlongbankmobilebanking", PackageId = "com.sunshine.ksbank", AppStoreId = "id1562823941", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.KOOKMIN_BANK_HCM, PackageId = "com.kbstar.global", AppStoreId = "id1542727700", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.KOOKMIN_BANK_HN, SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.LIENVIETPOST_BANK, Scheme = "lv24h", PackageId = "vn.com.lpb.lienviet24h", AppStoreId = "id1488794748", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.LPBANK, Scheme = "lv24h", PackageId = "vn.com.lpb.lienviet24h", AppStoreId = "id1488794748", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.LIOBANK, Scheme = "lio", PackageId = "com.ocb.liobank", AppStoreId = "id6444787281", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.MBBANK, Scheme = "mbmobile", PackageId = "com.mbmobile", AppStoreId = "id1205807363", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.MBV, Scheme = "oceanbankmobilebanking", PackageId = "com.vnpay.ocean", AppStoreId = "id1469028843", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.MSB, Scheme = "msbmobile", PackageId = "vn.com.msb.smartBanking", AppStoreId = "id436134873", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.NAM_A_BANK, Scheme = "deeplinkapp", PackageId = "ops.namabank.com.vn", AppStoreId = "id1456997296", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.NCB, Scheme = "ncbizimobile", PackageId = "com.ncb.bank", AppStoreId = "id1465217154", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.NONGHYUP_BANK_HN, Scheme = "newnhsmartbanking", PackageId = "nh.smart.banking", AppStoreId = "id1444712671", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.OCB, Scheme = "omniapp", PackageId = "com.ocb.omniextra", AppStoreId = "id1358682577", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.OCEANBANK, Scheme = "oceanbankmobilebanking", PackageId = "com.vnpay.ocean", AppStoreId = "id1469028843", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.PGBANK, PackageId = "pgbankApp.pgbank.com.vn", AppStoreId = "id1537765475", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.PUBLIC_BANK, Scheme = "publicbankmobile", PackageId = "com.vnpay.publicbank", AppStoreId = "id1573736472", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.PVCOM_BANK, Scheme = "pvcombankapp", PackageId = "com.vsii.pvcombank", AppStoreId = "id957284067", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.SACOMBANK, Scheme = "sacombankmobile", PackageId = "src.com.sacombank", AppStoreId = "id885814869", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.SAIGONBANK, Scheme = "Sgbmobile", PackageId = "com.vnpay.sgbank", AppStoreId = "id1481832587", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.SCB, Scheme = "scbmobilebanking", PackageId = "com.vnpay.SCB", AppStoreId = "id954973621", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.SEA_BANK, Scheme = "seabankmobile", PackageId = "vn.com.seabank.mb1", AppStoreId = "id846407152", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.SHB, Scheme = "shbmobile", PackageId = "vn.shb.mbanking", AppStoreId = "id538278798", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.SHINHAN_BANK, Scheme = "shinhanglbvnbank", PackageId = "com.shinhan.global.vn.bank", AppStoreId = "id1071033810", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.STANDARD_CHARTERED_BANK, PackageId = "com.sc.mobilebanking.vn", AppStoreId = "id1146741999", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.TECHCOMBANK, Scheme = "tcb", PackageId = "vn.com.techcombank.bb.app", AppStoreId = "id1548623362", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.TIMO, Scheme = "plus", PackageId = "io.lifestyle.plus", AppStoreId = "id1521230347", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.TPBANK, Scheme = "hydro", PackageId = "com.tpb.mb.gprsandroid", AppStoreId = "id450464147", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.UBANK, PackageId = "vn.vpbank.ubank", AppStoreId = "id1529056628", SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.UNITED_OVERSEAS_BANK, Scheme = "mightyapp", PackageId = "com.uob.mightyvn", AppStoreId = "id1174327324", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.VIB, Scheme = "myvib2", PackageId = "com.vib.myvib2", AppStoreId = "id1626624790", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.VIET_A_BANK, Scheme = "vabmobilebanking", PackageId = "phn.com.vn.mb", AppStoreId = "id910897337", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.VIET_BANK, Scheme = "vietbankmobilebanking", PackageId = "com.vnpay.vietbank", AppStoreId = "id1461658565", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.BANVIET, Scheme = "bvbankdigimi", PackageId = "vn.banvietbank.mobilebanking", AppStoreId = "id1526444697", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.VIETCOMBANK, Scheme = "vietcombankmobile", PackageId = "com.VCB", AppStoreId = "id561433133", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.VIETINBANK, Scheme = "vietinbankmobile", PackageId = "com.vietinbank.ipay", AppStoreId = "id689963454", SupportVietQR = true, SupportVNPayQR = true },
            new() { Bank = BankKey.VIKKI, Scheme = "vikki", PackageId = "com.finx.vikki", AppStoreId = "id6471952024", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.VPBANK, Scheme = "vpbankneo", PackageId = "com.vnpay.vpbankonline", AppStoreId = "id1209349510", SupportVietQR = true, SupportVNPayQR = false },
            new() { Bank = BankKey.VRB, SupportVietQR = false, SupportVNPayQR = false },
            new() { Bank = BankKey.WOORI_BANK, Scheme = "wvbs", PackageId = "vn.com.woori.smart", AppStoreId = "id1501785125", SupportVietQR = true, SupportVNPayQR = false }
        };
    }
}