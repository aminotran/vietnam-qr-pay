using System;
using System.Collections.Generic;
using System.Linq;
using ICU.Lib.VietQR.Enums;
using ICU.Lib.VietQR.Models;
using ICU.Lib.VietQR.Services;

namespace ICU.Lib.VietQR
{
    /// <summary>
    /// Lớp chính để Encode/Decode mã QR thanh toán (VietQR, VNPayQR)
    /// </summary>
    public class QRPay
    {
        #region Properties

        /// <summary>Kiểm tra tính hợp lệ của mã QR</summary>
        public bool IsValid { get; private set; } = true;

        /// <summary>Phiên bản (mặc định: 01)</summary>
        public string Version { get; set; } = "01";

        /// <summary>Phương thức khởi tạo (11 - QR Tĩnh, 12 - QR Động)</summary>
        public string InitMethod { get; set; } = "11";

        /// <summary>Thông tin nhà cung cấp</summary>
        public Provider Provider { get; set; }

        /// <summary>Thông tin merchant</summary>
        public Merchant Merchant { get; set; }

        /// <summary>Thông tin người thanh toán</summary>
        public Consumer Consumer { get; set; }

        /// <summary>Mã danh mục</summary>
        public string? Category { get; set; }

        /// <summary>Mã tiền tệ (VNĐ: 704)</summary>
        public string? Currency { get; set; }

        /// <summary>Số tiền giao dịch</summary>
        public string? Amount { get; set; }

        /// <summary>Loại phí & tip</summary>
        public string? TipAndFeeType { get; set; }

        /// <summary>Số tiền phí & tip</summary>
        public string? TipAndFeeAmount { get; set; }

        /// <summary>Phần trăm phí & tip</summary>
        public string? TipAndFeePercent { get; set; }

        /// <summary>Mã quốc gia (mặc định: VN)</summary>
        public string? Nation { get; set; }

        /// <summary>Thành phố</summary>
        public string? City { get; set; }

        /// <summary>Mã bưu chính</summary>
        public string? ZipCode { get; set; }

        /// <summary>Thông tin bổ sung</summary>
        public AdditionalData AdditionalData { get; set; }

        /// <summary>Mã CRC</summary>
        public string? Crc { get; set; }

        /// <summary>EMVCo Reserved Fields (ID 65-79)</summary>
        public Dictionary<string, string>? EVMCo { get; set; }

        /// <summary>Unreserved Fields (ID 80-99) - Dùng cho dữ liệu tùy chỉnh</summary>
        public Dictionary<string, string>? Unreserved { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo QRPay từ nội dung QR code string
        /// </summary>
        /// <param name="content?">Nội dung QR code (có thể null)</param>
        public QRPay(string? content = null)
        {
            Provider = new Provider();
            Consumer = new Consumer();
            Merchant = new Merchant();
            AdditionalData = new AdditionalData();

            if (!string.IsNullOrEmpty(content))
            {
                Parse(content);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Parse nội dung QR code
        /// </summary>
        /// <param name="content">Chuỗi nội dung QR code</param>
        public void Parse(string content)
        {
            if (content.Length < 4)
            {
                Invalidate();
                return;
            }

            // Verify CRC
            if (!VerifyCrc(content))
            {
                Invalidate();
                return;
            }

            // Parse content
            ParseRootContent(content);
        }

        /// <summary>
        /// Tạo/xây dựng lại nội dung QR code từ các thông tin hiện tại
        /// </summary>
        /// <returns>Nội dung QR code dạng string</returns>
        public string Build()
        {
            var version = GenFieldData(FieldID.VERSION, Version ?? "01");
            var initMethod = GenFieldData(FieldID.INIT_METHOD, InitMethod ?? "11");

            var guid = GenFieldData(ProviderFieldID.GUID, Provider.Guid);

            string providerDataContent;
            if (Provider.Guid == QRProviderGUID.VIETQR)
            {
                var bankBin = GenFieldData(VietQRConsumerFieldID.BANK_BIN, Consumer.BankBin);
                var bankNumber = GenFieldData(VietQRConsumerFieldID.BANK_NUMBER, Consumer.BankNumber);
                providerDataContent = bankBin + bankNumber;
            }
            else if (Provider.Guid == QRProviderGUID.VNPAY)
            {
                providerDataContent = Merchant.Id ?? "";
            }
            else
            {
                providerDataContent = Provider.Data ?? "";
            }

            var provider = GenFieldData(ProviderFieldID.DATA, providerDataContent);
            var service = GenFieldData(ProviderFieldID.SERVICE, Provider.Service);
            var providerData = GenFieldData(Provider.FieldId, guid + provider + service);

            var category = GenFieldData(FieldID.CATEGORY, Category);
            var currency = GenFieldData(FieldID.CURRENCY, Currency ?? "704");
            var amountStr = GenFieldData(FieldID.AMOUNT, Amount);
            var tipAndFeeType = GenFieldData(FieldID.TIP_AND_FEE_TYPE, TipAndFeeType);
            var tipAndFeeAmount = GenFieldData(FieldID.TIP_AND_FEE_AMOUNT, TipAndFeeAmount);
            var tipAndFeePercent = GenFieldData(FieldID.TIP_AND_FEE_PERCENT, TipAndFeePercent);
            var nation = GenFieldData(FieldID.NATION, Nation ?? "VN");
            var merchantName = GenFieldData(FieldID.MERCHANT_NAME, Merchant.Name);
            var city = GenFieldData(FieldID.CITY, City);
            var zipCode = GenFieldData(FieldID.ZIP_CODE, ZipCode);

            var buildNumber = GenFieldData(AdditionalDataID.BILL_NUMBER, AdditionalData.BillNumber);
            var mobileNumber = GenFieldData(AdditionalDataID.MOBILE_NUMBER, AdditionalData.MobileNumber);
            var storeLabel = GenFieldData(AdditionalDataID.STORE_LABEL, AdditionalData.Store);
            var loyaltyNumber = GenFieldData(AdditionalDataID.LOYALTY_NUMBER, AdditionalData.LoyaltyNumber);
            var reference = GenFieldData(AdditionalDataID.REFERENCE_LABEL, AdditionalData.Reference);
            var customerLabel = GenFieldData(AdditionalDataID.CUSTOMER_LABEL, AdditionalData.CustomerLabel);
            var terminal = GenFieldData(AdditionalDataID.TERMINAL_LABEL, AdditionalData.Terminal);
            var purpose = GenFieldData(AdditionalDataID.PURPOSE_OF_TRANSACTION, AdditionalData.Purpose);
            var dataRequest = GenFieldData(AdditionalDataID.ADDITIONAL_CONSUMER_DATA_REQUEST, AdditionalData.DataRequest);

            var additionalDataContent = buildNumber + mobileNumber + storeLabel + loyaltyNumber + reference + customerLabel + terminal + purpose + dataRequest;
            var additionalData = GenFieldData(FieldID.ADDITIONAL_DATA, additionalDataContent);

            var evmCoContent = EVMCo != null
                ? string.Concat(EVMCo.Keys.OrderBy(k => k).Select(key => GenFieldData(key, EVMCo[key])))
                : "";

            var unreservedContent = Unreserved != null
                ? string.Concat(Unreserved.Keys.OrderBy(k => k).Select(key => GenFieldData(key, Unreserved[key])))
                : "";

            var content = $"{version}{initMethod}{providerData}{category}{currency}{amountStr}{tipAndFeeType}{tipAndFeeAmount}{tipAndFeePercent}{nation}{merchantName}{city}{zipCode}{additionalData}{evmCoContent}{unreservedContent}{FieldID.CRC}04";
            var crc = GenCrcCode(content);
            return content + crc;
        }

        /// <summary>
        /// Khởi tạo QRPay với cấu hình VietQR
        /// </summary>
        /// <param name="bankBin">Mã ngân hàng (BIN)</param>
        /// <param name="bankNumber">Số tài khoản</param>
        /// <param name="amount?">Số tiền (null = QR Tĩnh)</param>
        /// <param name="purpose?">Nội dung chuyển tiền</param>
        /// <param name="service?">Dịch vụ (mặc định: BY_ACCOUNT_NUMBER)</param>
        /// <returns>QRPay instance</returns>
        public static QRPay InitVietQR(string bankBin, string bankNumber,
            string? amount = null, string? purpose = null,
            VietQRService service = VietQRService.BY_ACCOUNT_NUMBER)
        {
            var qr = new QRPay
            {
                InitMethod = !string.IsNullOrEmpty(amount) ? "12" : "11",
                Provider =
                {
                    FieldId = FieldID.VIETQR,
                    Guid = QRProviderGUID.VIETQR,
                    Name = Enums.QRProvider.VIETQR,
                    Service = service == VietQRService.BY_ACCOUNT_NUMBER
                        ? VietQRServiceValue.BY_ACCOUNT_NUMBER
                        : VietQRServiceValue.BY_CARD_NUMBER
                },
                Consumer =
                {
                    BankBin = bankBin,
                    BankNumber = bankNumber
                },
                Amount = amount,
                AdditionalData = { Purpose = purpose }
            };
            return qr;
        }

        /// <summary>
        /// Khởi tạo QRPay với cấu hình VNPayQR
        /// </summary>
        /// <param name="merchantId">Mã merchant</param>
        /// <param name="merchantName">Tên merchant</param>
        /// <param name="store">Tên cửa hàng</param>
        /// <param name="terminal">Tên điểm bán</param>
        /// <param name="amount?">Số tiền</param>
        /// <param name="purpose?">Nội dung giao dịch</param>
        /// <param name="billNumber?">Số hóa đơn</param>
        /// <param name="mobileNumber?">Số điện thoại</param>
        /// <param name="loyaltyNumber?">Mã KH thân thiết</param>
        /// <param name="reference?">Mã tham chiếu</param>
        /// <param name="customerLabel?">Mã khách hàng</param>
        /// <returns>QRPay instance</returns>
        public static QRPay InitVNPayQR(string merchantId, string merchantName,
            string store, string terminal,
            string? amount = null, string? purpose = null,
            string? billNumber = null, string? mobileNumber = null,
            string? loyaltyNumber = null, string? reference = null,
            string? customerLabel = null)
        {
            var qr = new QRPay
            {
                Merchant =
                {
                    Id = merchantId,
                    Name = merchantName
                },
                Provider =
                {
                    FieldId = FieldID.VNPAYQR,
                    Guid = QRProviderGUID.VNPAY,
                    Name = Enums.QRProvider.VNPAY
                },
                Amount = amount,
                AdditionalData =
                {
                    Purpose = purpose,
                    BillNumber = billNumber,
                    MobileNumber = mobileNumber,
                    Store = store,
                    Terminal = terminal,
                    LoyaltyNumber = loyaltyNumber,
                    Reference = reference,
                    CustomerLabel = customerLabel
                }
            };
            return qr;
        }

        /// <summary>
        /// Thiết lập EMVCo Reserved Field (ID 65-79)
        /// </summary>
        public void SetEVMCoField(string id, string value)
        {
            EVMCo ??= new Dictionary<string, string>();
            EVMCo[id] = value;
        }

        /// <summary>
        /// Thiết lập Unreserved Field (ID 80-99) cho dữ liệu tùy chỉnh
        /// </summary>
        public void SetUnreservedField(string id, string value)
        {
            Unreserved ??= new Dictionary<string, string>();
            Unreserved[id] = value;
        }

        /// <summary>
        /// Tạo mã CRC từ nội dung QR code
        /// </summary>
        public static string GenCrcCode(string content)
        {
            var crcCode = Crc16.Compute(content).ToString("X4");
            return crcCode;
        }

        #endregion

        #region Private Methods

        private void ParseRootContent(string content)
        {
            var (id, length, value, nextValue) = SliceContent(content);
            if (value.Length != length)
            {
                Invalidate();
                return;
            }

            switch (id)
            {
                case var _ when id == FieldID.VERSION:
                    Version = value;
                    break;
                case var _ when id == FieldID.INIT_METHOD:
                    InitMethod = value;
                    break;
                case var _ when id == FieldID.VIETQR || id == FieldID.VNPAYQR:
                    Provider.FieldId = id;
                    ParseProviderInfo(value);
                    break;
                case var _ when id == FieldID.CATEGORY:
                    Category = value;
                    break;
                case var _ when id == FieldID.CURRENCY:
                    Currency = value;
                    break;
                case var _ when id == FieldID.AMOUNT:
                    Amount = value;
                    break;
                case var _ when id == FieldID.TIP_AND_FEE_TYPE:
                    TipAndFeeType = value;
                    break;
                case var _ when id == FieldID.TIP_AND_FEE_AMOUNT:
                    TipAndFeeAmount = value;
                    break;
                case var _ when id == FieldID.TIP_AND_FEE_PERCENT:
                    TipAndFeePercent = value;
                    break;
                case var _ when id == FieldID.NATION:
                    Nation = value;
                    break;
                case var _ when id == FieldID.MERCHANT_NAME:
                    Merchant.Name = value;
                    break;
                case var _ when id == FieldID.CITY:
                    City = value;
                    break;
                case var _ when id == FieldID.ZIP_CODE:
                    ZipCode = value;
                    break;
                case var _ when id == FieldID.ADDITIONAL_DATA:
                    ParseAdditionalData(value);
                    break;
                case var _ when id == FieldID.CRC:
                    Crc = value;
                    break;
                default:
                    if (int.TryParse(id, out var idNum))
                    {
                        if (idNum >= 65 && idNum <= 79)
                        {
                            EVMCo ??= new Dictionary<string, string>();
                            EVMCo[id] = value;
                        }
                        else if (idNum >= 80 && idNum <= 99)
                        {
                            Unreserved ??= new Dictionary<string, string>();
                            Unreserved[id] = value;
                        }
                    }
                    break;
            }

            if (nextValue.Length > 4)
                ParseRootContent(nextValue);
        }

        private void ParseProviderInfo(string content)
        {
            var (id, _, value, nextValue) = SliceContent(content);

            switch (id)
            {
                case var _ when id == ProviderFieldID.GUID:
                    Provider.Guid = value;
                    break;
                case var _ when id == ProviderFieldID.DATA:
                    if (Provider.Guid == QRProviderGUID.VNPAY)
                    {
                        Provider.Name = Enums.QRProvider.VNPAY;
                        Merchant.Id = value;
                    }
                    else if (Provider.Guid == QRProviderGUID.VIETQR)
                    {
                        Provider.Name = Enums.QRProvider.VIETQR;
                        ParseVietQRConsumer(value);
                    }
                    Provider.Data = value;
                    break;
                case var _ when id == ProviderFieldID.SERVICE:
                    Provider.Service = value;
                    break;
            }

            if (nextValue.Length > 4)
                ParseProviderInfo(nextValue);
        }

        private void ParseVietQRConsumer(string content)
        {
            var (id, _, value, nextValue) = SliceContent(content);

            switch (id)
            {
                case var _ when id == VietQRConsumerFieldID.BANK_BIN:
                    Consumer.BankBin = value;
                    break;
                case var _ when id == VietQRConsumerFieldID.BANK_NUMBER:
                    Consumer.BankNumber = value;
                    break;
            }

            if (nextValue.Length > 4)
                ParseVietQRConsumer(nextValue);
        }

        private void ParseAdditionalData(string content)
        {
            var (id, _, value, nextValue) = SliceContent(content);

            switch (id)
            {
                case var _ when id == AdditionalDataID.BILL_NUMBER:
                    AdditionalData.BillNumber = value;
                    break;
                case var _ when id == AdditionalDataID.MOBILE_NUMBER:
                    AdditionalData.MobileNumber = value;
                    break;
                case var _ when id == AdditionalDataID.STORE_LABEL:
                    AdditionalData.Store = value;
                    break;
                case var _ when id == AdditionalDataID.LOYALTY_NUMBER:
                    AdditionalData.LoyaltyNumber = value;
                    break;
                case var _ when id == AdditionalDataID.REFERENCE_LABEL:
                    AdditionalData.Reference = value;
                    break;
                case var _ when id == AdditionalDataID.CUSTOMER_LABEL:
                    AdditionalData.CustomerLabel = value;
                    break;
                case var _ when id == AdditionalDataID.TERMINAL_LABEL:
                    AdditionalData.Terminal = value;
                    break;
                case var _ when id == AdditionalDataID.PURPOSE_OF_TRANSACTION:
                    AdditionalData.Purpose = value;
                    break;
                case var _ when id == AdditionalDataID.ADDITIONAL_CONSUMER_DATA_REQUEST:
                    AdditionalData.DataRequest = value;
                    break;
            }

            if (nextValue.Length > 4)
                ParseAdditionalData(nextValue);
        }

        private static bool VerifyCrc(string content)
        {
            var checkContent = content[..^4];
            var crcCode = content[^4..].ToUpperInvariant();
            var genCrcCode = GenCrcCode(checkContent);
            return crcCode == genCrcCode;
        }

        private static (string id, int length, string value, string nextValue) SliceContent(string content)
        {
            var id = content[..2];
            var length = int.Parse(content[2..4]);
            var value = content.Substring(4, length);
            var nextValue = content[(4 + length)..];
            return (id, length, value, nextValue);
        }

        private void Invalidate()
        {
            IsValid = false;
        }

        private static string GenFieldData(string? id, string? value)
        {
            var fieldId = id ?? "";
            var fieldValue = value ?? "";
            if (fieldId.Length != 2 || fieldValue.Length <= 0)
                return "";
            var length = fieldValue.Length.ToString("D2");
            return $"{fieldId}{length}{fieldValue}";
        }

        #endregion
    }
}