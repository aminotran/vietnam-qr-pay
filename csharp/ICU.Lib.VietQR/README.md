# ICU.Lib.VietQR

Thư viện C# hỗ trợ **Encode/Decode** mã QR thanh toán theo chuẩn **VietQR** (QR Ngân hàng), **VNPayQR**, QR Đa năng **MoMo/ZaloPay** và các nhà cung cấp khác.

Ported from [vietnam-qr-pay](https://github.com/xuannghia/vietnam-qr-pay) (TypeScript) sang .NET Standard 2.1.

## Cài đặt

```bash
dotnet add package ICU.Lib.VietQR
```

Hoặc thêm trực tiếp vào file `.csproj`:

```xml
<PackageReference Include="ICU.Lib.VietQR" Version="1.0.0" />
```

## Cách sử dụng

### Encode - Tạo mã QR

#### VietQR Tĩnh

```csharp
using ICU.Lib.VietQR;
using ICU.Lib.VietQR.Constants;

var qrPay = QRPay.InitVietQR(
    bankBin: BanksObject.Acb.Bin,       // Mã ngân hàng
    bankNumber: "257678859"              // Số tài khoản
);
var content = qrPay.Build();

Console.WriteLine(content);
// 00020101021138530010A0000007270123000697041601092576788590208QRIBFTTA53037045802VN6304AE9F
```

#### VietQR Động

```csharp
using ICU.Lib.VietQR;
using ICU.Lib.VietQR.Constants;

var qrPay = QRPay.InitVietQR(
    bankBin: BanksObject.Acb.Bin,
    bankNumber: "257678859",
    amount: "10000",                     // Số tiền
    purpose: "Chuyen tien"               // Nội dung chuyển tiền
);
var content = qrPay.Build();

Console.WriteLine(content);
// 00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA53037045405100005802VN62150811Chuyen tien630453E6
```

#### QR Đa năng MoMo

```csharp
using ICU.Lib.VietQR;
using ICU.Lib.VietQR.Constants;
using ICU.Lib.VietQR.Enums;

// Số tài khoản trong ví MoMo
var accountNumber = "99MM24011M34875080";

var momoQR = QRPay.InitVietQR(
    bankBin: BanksObject.BanViet.Bin,
    bankNumber: accountNumber
);

// Trong mã QR của MoMo có chứa thêm 1 mã tham chiếu tương ứng với STK
momoQR.AdditionalData.Reference = "MOMOW2W" + accountNumber.Substring(10);

// Mã QR của MoMo có thêm 1 trường ID 80 với giá trị là 3 số cuối của SĐT tài khoản nhận
momoQR.SetUnreservedField("80", "046");

var content = momoQR.Build();
Console.WriteLine(content);
// 00020101021138620010A00000072701320006970454011899MM24011M348750800208QRIBFTTA53037045802VN62190515MOMOW2W3487508080030466304EBC8
```

#### QR Đa năng ZaloPay

```csharp
using ICU.Lib.VietQR;
using ICU.Lib.VietQR.Constants;

// Số tài khoản trong ví ZaloPay
var accountNumber = "99ZP24009M07248267";

var zaloPayQR = QRPay.InitVietQR(
    bankBin: BanksObject.BanViet.Bin,
    bankNumber: accountNumber
);

var content = zaloPayQR.Build();
Console.WriteLine(content);
// 00020101021138620010A00000072701320006970454011899ZP24009M072482670208QRIBFTTA53037045802VN6304073C
```

#### VNPayQR

```csharp
using ICU.Lib.VietQR;

var qrPay = QRPay.InitVNPayQR(
    merchantId: "0102154778",
    merchantName: "TUGIACOMPANY",
    store: "TU GIA COMPUTER",
    terminal: "TUGIACO1"
);
var content = qrPay.Build();
Console.WriteLine(content);
// 00020101021126280010A0000007750110010215477853037045802VN5912TUGIACOMPANY62310315TU GIA COMPUTER0708TUGIACO16304DF44
```

### Decode - Đọc mã QR

#### VietQR

```csharp
using ICU.Lib.VietQR;
using ICU.Lib.VietQR.Enums;

var qrContent = "00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA5303704540410005802VN62150811Chuyen tien6304BBB8";
var qrPay = new QRPay(qrContent);

Console.WriteLine(qrPay.IsValid);              // True
Console.WriteLine(qrPay.Provider.Name);        // VIETQR
Console.WriteLine(qrPay.Consumer.BankBin);     // 970416
Console.WriteLine(qrPay.Consumer.BankNumber);  // 257678859
Console.WriteLine(qrPay.Amount);               // 1000
Console.WriteLine(qrPay.AdditionalData.Purpose); // Chuyen tien
```

#### VNPayQR

```csharp
using ICU.Lib.VietQR;
using ICU.Lib.VietQR.Enums;

var qrContent = "00020101021126280010A0000007750110010531314453037045408210900005802VN5910CELLPHONES62600312CPSHN ONLINE0517021908061613127850705ONLHN0810CellphoneS63047685";
var qrPay = new QRPay(qrContent);

Console.WriteLine(qrPay.IsValid);                    // True
Console.WriteLine(qrPay.Provider.Name);              // VNPAY
Console.WriteLine(qrPay.Merchant.Id);                // 0105313144
Console.WriteLine(qrPay.Amount);                     // 21090000
Console.WriteLine(qrPay.AdditionalData.Store);       // CPSHN ONLINE
Console.WriteLine(qrPay.AdditionalData.Terminal);    // ONLHN
Console.WriteLine(qrPay.AdditionalData.Purpose);     // CellphoneS
Console.WriteLine(qrPay.AdditionalData.Reference);   // 02190806161312785
```

### Modify - Sửa thông tin và tạo lại QR

```csharp
using ICU.Lib.VietQR;

var qrContent = "00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA5303704540410005802VN62150811Chuyen tien6304BBB8";
var qrPay = new QRPay(qrContent);

// qrPay.Amount == "10000"
// qrPay.AdditionalData.Purpose == "Chuyen tien"

qrPay.Amount = "999999";
qrPay.AdditionalData.Purpose = "Cam on nhe";

var newQRContent = qrPay.Build();
Console.WriteLine(newQRContent);
// 00020101021238530010A0000007270123000697041601092576788590208QRIBFTTA530370454069999995802VN62140810Cam on nhe6304E786
```

## Cấu trúc thư viện

```
ICU.Lib.VietQR/
├── Enums/
│   └── QRProvider.cs         # Các enum và hằng số của QR Pay
├── Models/
│   ├── Provider.cs           # Thông tin nhà cung cấp
│   ├── Consumer.cs           # Thông tin người thanh toán
│   ├── Merchant.cs           # Thông tin merchant
│   └── AdditionalData.cs     # Thông tin bổ sung
├── Services/
│   └── Crc16.cs              # CRC-16/CCITT implementation
├── Constants/
│   └── Banks.cs              # Danh sách ngân hàng Việt Nam
├── QRPay.cs                  # Lớp chính (Encode/Decode)
├── ICU.Lib.VietQR.csproj     # Project file
└── README.md
```

## API

### Class `QRPay`

| Property | Type | Description |
|----------|------|-------------|
| `IsValid` | `bool` | Kiểm tra tính hợp lệ của mã QR |
| `Version` | `string` | Phiên bản |
| `InitMethod` | `string` | Phương thức khởi tạo (`11` - QR Tĩnh, `12` - QR động) |
| `Provider` | `Provider` | Thông tin nhà cung cấp |
| `Merchant` | `Merchant` | Thông tin merchant |
| `Consumer` | `Consumer` | Thông tin người thanh toán |
| `Amount` | `string` | Số tiền giao dịch |
| `Currency` | `string` | Mã tiền tệ (VNĐ: 704) |
| `Nation` | `string` | Mã quốc gia |
| `AdditionalData` | `AdditionalData` | Thông tin bổ sung |
| `Crc` | `string` | Mã kiểm tra |
| `EVMCo` | `Dictionary<string, string>` | EMVCo Reserved Fields (65-79) |
| `Unreserved` | `Dictionary<string, string>` | Unreserved Fields (80-99) |

### Methods

| Method | Description |
|--------|-------------|
| `Parse(string content)` | Parse nội dung QR code |
| `Build()` | Tạo lại nội dung QR code mới |
| `InitVietQR(...)` | Khởi tạo QR với cấu hình VietQR |
| `InitVNPayQR(...)` | Khởi tạo QR với cấu hình VNPayQR |
| `SetEVMCoField(id, value)` | Thiết lập EMVCo Reserved Field (65-79) |
| `SetUnreservedField(id, value)` | Thiết lập Unreserved Field (80-99) |

## Yêu cầu

- .NET Standard 2.1 trở lên (.NET 5+, .NET Core 3.0+, .NET Framework 4.8+)

## Giấy phép

MIT License