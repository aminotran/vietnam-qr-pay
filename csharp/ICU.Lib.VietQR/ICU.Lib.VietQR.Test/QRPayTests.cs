using ICU.Lib.VietQR.Constants;
using ICU.Lib.VietQR.Enums;

namespace ICU.Lib.VietQR.Test;

public class QRPayTests
{
    #region VietQR Encode

    [Fact]
    public void VietQR_Static_Encode()
    {
        var qrPay = QRPay.InitVietQR(
            bankBin: BanksObject.Acb.Bin,
            bankNumber: "257678859"
        );
        var content = qrPay.Build();

        Assert.Equal("11", qrPay.InitMethod);
        Assert.Equal("00020101021138530010A0000007270123000697041601092576788590208QRIBFTTA53037045802VN6304AE9F", content);
    }

    [Fact]
    public void VietQR_Dynamic_Encode()
    {
        var qrPay = QRPay.InitVietQR(
            bankBin: BanksObject.Acb.Bin,
            bankNumber: "257678859",
            amount: "10000",
            purpose: "Chuyen tien"
        );
        var content = qrPay.Build();

        Assert.Equal("12", qrPay.InitMethod);
        Assert.Equal("00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA53037045405100005802VN62150811Chuyen tien630453E6", content);
    }

    [Fact]
    public void MoMo_Encode()
    {
        var accountNumber = "99MM24011M34875080";
        var momoQR = QRPay.InitVietQR(
            bankBin: BanksObject.BanViet.Bin,
            bankNumber: accountNumber
        );
        momoQR.AdditionalData.Reference = "MOMOW2W" + accountNumber.Substring(10);
        momoQR.SetUnreservedField("80", "046");

        var content = momoQR.Build();
        Assert.Equal("00020101021138620010A00000072701320006970454011899MM24011M348750800208QRIBFTTA53037045802VN62190515MOMOW2W3487508080030466304EBC8", content);
    }

    [Fact]
    public void ZaloPay_Encode()
    {
        var accountNumber = "99ZP24009M07248267";
        var zaloPayQR = QRPay.InitVietQR(
            bankBin: BanksObject.BanViet.Bin,
            bankNumber: accountNumber
        );

        var content = zaloPayQR.Build();
        Assert.Equal("00020101021138620010A00000072701320006970454011899ZP24009M072482670208QRIBFTTA53037045802VN6304073C", content);
    }

    [Fact]
    public void VNPayQR_Encode()
    {
        var qrPay = QRPay.InitVNPayQR(
            merchantId: "0102154778",
            merchantName: "TUGIACOMPANY",
            store: "TU GIA COMPUTER",
            terminal: "TUGIACO1"
        );
        var content = qrPay.Build();
        Assert.Equal("00020101021126280010A0000007750110010215477853037045802VN5912TUGIACOMPANY62310315TU GIA COMPUTER0708TUGIACO16304DF44", content);
    }

    #endregion

    #region VietQR Decode

    [Fact]
    public void VietQR_Decode()
    {
        var qrContent = "00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA5303704540410005802VN62150811Chuyen tien6304BBB8";
        var qrPay = new QRPay(qrContent);

        Assert.True(qrPay.IsValid);
        Assert.Equal("01", qrPay.Version);
        Assert.Equal(Enums.QRProvider.VIETQR, qrPay.Provider.Name);
        Assert.Equal(QRProviderGUID.VIETQR, qrPay.Provider.Guid);
        Assert.Equal("970416", qrPay.Consumer.BankBin);
        Assert.Equal("257678859", qrPay.Consumer.BankNumber);
        Assert.Equal("1000", qrPay.Amount);
        Assert.Equal(qrContent, qrPay.Build());
    }

    [Fact]
    public void VietQR_CRC_ThreeByte()
    {
        var qrContent = "00020101021138580010A000000727012800069704070114190304136010180208QRIBFTTA53037045802VN63040283";
        var qrPay = new QRPay(qrContent);

        Assert.True(qrPay.IsValid);
        Assert.Equal("01", qrPay.Version);
        Assert.Equal(Enums.QRProvider.VIETQR, qrPay.Provider.Name);
        Assert.Equal(QRProviderGUID.VIETQR, qrPay.Provider.Guid);
        Assert.Equal("970407", qrPay.Consumer.BankBin);
        Assert.Equal("19030413601018", qrPay.Consumer.BankNumber);
        Assert.Equal(qrContent, qrPay.Build());
    }

    [Fact]
    public void VietQR_InvalidCRC()
    {
        var qrPay = new QRPay("00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA5303704540410005802VN62150811Chuyen tien6304BBB5");
        Assert.False(qrPay.IsValid);
    }

    [Fact]
    public void VietQR_LowercaseCRC()
    {
        var qrContent = "00020101021138540010A00000072701240006970422011003523509170208QRIBFTTA53037045802VN630479db";
        var qrPay = new QRPay(qrContent);

        Assert.True(qrPay.IsValid);
        Assert.Equal("01", qrPay.Version);
        Assert.Equal(Enums.QRProvider.VIETQR, qrPay.Provider.Name);
        Assert.Equal(QRProviderGUID.VIETQR, qrPay.Provider.Guid);
        Assert.Equal("970422", qrPay.Consumer.BankBin);
        Assert.Equal("0352350917", qrPay.Consumer.BankNumber);
        Assert.Equal(qrContent[^4..].ToUpperInvariant(), qrPay.Build()[^4..]);
    }

    #endregion

    #region VNPayQR Decode

    [Fact]
    public void VNPayQR_Decode()
    {
        var qrContent = "00020101021126280010A000000775011001087990425204597753037045802VN5909MYPHAMHER6005HANOI62260311MY PHAM HER0707MPHER0163041C50";
        var qrPay = new QRPay(qrContent);

        Assert.True(qrPay.IsValid);
        Assert.Equal("01", qrPay.Version);
        Assert.Equal(Enums.QRProvider.VNPAY, qrPay.Provider.Name);
        Assert.Equal(QRProviderGUID.VNPAY, qrPay.Provider.Guid);
        Assert.Equal("MY PHAM HER", qrPay.AdditionalData.Store);
        Assert.Equal("MPHER01", qrPay.AdditionalData.Terminal);
        Assert.Equal("1C50", qrPay.Crc);
        Assert.Equal(qrContent, qrPay.Build());
    }

    [Fact]
    public void VNPayQR2_Decode()
    {
        var qrContent = "00020101021126280010A000000775011001A80187905204549953037045802VN5907SUNFLY16005HaNoi62290313SUNFLY ONLINE0708SUNFLY016304AE6F";
        var qrPay = new QRPay(qrContent);

        Assert.True(qrPay.IsValid);
        Assert.Equal("01", qrPay.Version);
        Assert.Equal(Enums.QRProvider.VNPAY, qrPay.Provider.Name);
        Assert.Equal(QRProviderGUID.VNPAY, qrPay.Provider.Guid);
        Assert.Equal("SUNFLY ONLINE", qrPay.AdditionalData.Store);
        Assert.Equal("SUNFLY01", qrPay.AdditionalData.Terminal);
        Assert.Equal("AE6F", qrPay.Crc);
        Assert.Equal(qrContent, qrPay.Build());
    }

    [Fact]
    public void VNPayQR_InvalidCRC()
    {
        var qrPay = new QRPay("00020101021126280010A000000775011001087990425204597753037045802VN5909MYPHAMHER6005HANOI62260311MY PHAM HER0707MPHER0163041C55");
        Assert.False(qrPay.IsValid);
    }

    #endregion

    #region Other QR Providers

    [Fact]
    public void AirPay_Decode()
    {
        var qrPay = new QRPay("00020101021126610013vn.airpay.www014000000201010100064185noC4efDjGKq0or5GbeBz5204581253037045910RESTAURANT6009HOCHIMINH5802VN6304DA5C");
        Assert.True(qrPay.IsValid);
        Assert.Equal("01", qrPay.Version);
        Assert.Null(qrPay.Provider.Name);
        Assert.Equal("vn.airpay.www", qrPay.Provider.Guid);
    }

    [Fact]
    public void EVN_Decode()
    {
        var qrContent = "000201010211262400020001140100101114-0195204490053037045802VN5931EVN CONG TY DIEN LUC THANH XUAN6006Ha Noi62450302000613PD000000000000702000812TT tien dien6304DC30";
        var qrPay = new QRPay(qrContent);
        Assert.True(qrPay.IsValid);
        Assert.Equal("01", qrPay.Version);
        Assert.Equal("26", qrPay.Provider.FieldId);
        Assert.Equal("00", qrPay.Provider.Guid);
        Assert.Equal("PD00000000000", qrPay.AdditionalData.CustomerLabel);
        Assert.Equal(qrContent, qrPay.Build());
    }

    #endregion

    #region Build & Modify

    [Fact]
    public void Modify_And_Rebuild()
    {
        var qrContent = "00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA5303704540410005802VN62150811Chuyen tien6304BBB8";
        var qrPay = new QRPay(qrContent);

        // Verify initial values
        Assert.Equal("1000", qrPay.Amount);
        Assert.Equal("Chuyen tien", qrPay.AdditionalData.Purpose);

        // Modify
        qrPay.Amount = "999999";
        qrPay.AdditionalData.Purpose = "Cam on nhe";

        var newContent = qrPay.Build();
        Assert.Equal("00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA530370454069999995802VN62140810Cam on nhe6304E786", newContent);
    }

    #endregion

    #region Banks

    [Fact]
    public void FindBankByBin()
    {
        var bank = BanksObject.FindByBin("970416");
        Assert.NotNull(bank);
        Assert.Equal("ACB", bank!.Code);
    }

    [Fact]
    public void FindBankByShortName()
    {
        var bank = BanksObject.FindByShortName("Vietcombank");
        Assert.NotNull(bank);
        Assert.Equal("970436", bank!.Bin);
    }

    [Fact]
    public void FindBank_NotFound()
    {
        var bank = BanksObject.FindByBin("999999");
        Assert.Null(bank);
    }

    [Fact]
    public void BanksObject_AllBanks_HasData()
    {
        Assert.NotEmpty(BanksObject.AllBanks);
        Assert.All(BanksObject.AllBanks, bank =>
        {
            Assert.False(string.IsNullOrEmpty(bank.Bin));
            Assert.False(string.IsNullOrEmpty(bank.Name));
            Assert.False(string.IsNullOrEmpty(bank.ShortName));
        });
    }

    #endregion
}