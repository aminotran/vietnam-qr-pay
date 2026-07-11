namespace ICU.Lib.VietQR.Enums
{
    public enum QRProvider
    {
        VIETQR,
        VNPAY
    }

    public static class QRProviderGUID
    {
        public const string VNPAY = "A000000775";
        public const string VIETQR = "A000000727";
    }

    public static class FieldID
    {
        public const string VERSION = "00";
        public const string INIT_METHOD = "01";
        public const string VNPAYQR = "26";
        public const string VIETQR = "38";
        public const string CATEGORY = "52";
        public const string CURRENCY = "53";
        public const string AMOUNT = "54";
        public const string TIP_AND_FEE_TYPE = "55";
        public const string TIP_AND_FEE_AMOUNT = "56";
        public const string TIP_AND_FEE_PERCENT = "57";
        public const string NATION = "58";
        public const string MERCHANT_NAME = "59";
        public const string CITY = "60";
        public const string ZIP_CODE = "61";
        public const string ADDITIONAL_DATA = "62";
        public const string CRC = "63";
    }

    public static class ProviderFieldID
    {
        public const string GUID = "00";
        public const string DATA = "01";
        public const string SERVICE = "02";
    }

    public enum VietQRService
    {
        /// <summary>Dịch vụ chuyển nhanh NAPAS247 đến Tài khoản</summary>
        BY_ACCOUNT_NUMBER,
        /// <summary>Dịch vụ chuyển nhanh NAPAS247 đến Thẻ</summary>
        BY_CARD_NUMBER
    }

    public static class VietQRServiceValue
    {
        public const string BY_ACCOUNT_NUMBER = "QRIBFTTA";
        public const string BY_CARD_NUMBER = "QRIBFTTC";
    }

    public static class VietQRConsumerFieldID
    {
        public const string BANK_BIN = "00";
        public const string BANK_NUMBER = "01";
    }

    public static class AdditionalDataID
    {
        /// <summary>Số hóa đơn</summary>
        public const string BILL_NUMBER = "01";
        /// <summary>Số ĐT</summary>
        public const string MOBILE_NUMBER = "02";
        /// <summary>Mã cửa hàng</summary>
        public const string STORE_LABEL = "03";
        /// <summary>Mã khách hàng thân thiết</summary>
        public const string LOYALTY_NUMBER = "04";
        /// <summary>Mã tham chiếu</summary>
        public const string REFERENCE_LABEL = "05";
        /// <summary>Mã khách hàng</summary>
        public const string CUSTOMER_LABEL = "06";
        /// <summary>Mã số điểm bán</summary>
        public const string TERMINAL_LABEL = "07";
        /// <summary>Mục đích giao dịch</summary>
        public const string PURPOSE_OF_TRANSACTION = "08";
        /// <summary>Yêu cầu dữ liệu KH bổ sung</summary>
        public const string ADDITIONAL_CONSUMER_DATA_REQUEST = "09";
    }

    /// <summary>
    /// EMVCo Reserved Field IDs (65-79)
    /// </summary>
    public static class EVMCoFieldID
    {
        public const string ID_65 = "65";
        public const string ID_66 = "66";
        public const string ID_67 = "67";
        public const string ID_68 = "68";
        public const string ID_69 = "69";
        public const string ID_70 = "70";
        public const string ID_71 = "71";
        public const string ID_72 = "72";
        public const string ID_73 = "73";
        public const string ID_74 = "74";
        public const string ID_75 = "75";
        public const string ID_76 = "76";
        public const string ID_77 = "77";
        public const string ID_78 = "78";
        public const string ID_79 = "79";
    }

    /// <summary>
    /// Unreserved Field IDs (80-99) for custom/proprietary data
    /// </summary>
    public static class UnreservedFieldID
    {
        public const string ID_80 = "80";
        public const string ID_81 = "81";
        public const string ID_82 = "82";
        public const string ID_83 = "83";
        public const string ID_84 = "84";
        public const string ID_85 = "85";
        public const string ID_86 = "86";
        public const string ID_87 = "87";
        public const string ID_88 = "88";
        public const string ID_89 = "89";
        public const string ID_90 = "90";
        public const string ID_91 = "91";
        public const string ID_92 = "92";
        public const string ID_93 = "93";
        public const string ID_94 = "94";
        public const string ID_95 = "95";
        public const string ID_96 = "96";
        public const string ID_97 = "97";
        public const string ID_98 = "98";
        public const string ID_99 = "99";
    }
}