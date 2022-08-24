# VNLoginDLL

HƯỚNG DẪN SỬ DỤNG VNLOGIN DLL

1. Mục đích:
- VNLogin tạo ra nhằm giúp dev có bộ thư viện tạo - quản lý - và sử dụng cộng nghệ anti detect browser
- Giúp dev ứng dụng công nghệ này trong tool của mình.

2. Tính năng:
- Thay vì sử dụng API hoặc CLI tích hợp trên các tool anti detect trên thị trường. Bắt buộc bạn phải dùng thông qua App của họ.
- Giờ đây bạn chỉ cần một thư viện DLL add trực tiếp vào tool của mình để sử dụng trực tiếp

3. Cách sử dụng (Bạn chỉ cần add trực tiếp file VNLogin.Library.dll vào project của mình)

- B1: Chuột phải Project -> Add -> Existing item -> Chọn VNLogin.Library.dll
- B2: Chuột phải VNLogin.Library.dll -> Properties -> Chọn Build Action = content -> Copy Always
- B3: Copy Class VNLoginDLL.cs trong Project mẫu của VNLoginDLL
- B4: Copy thư mục data bỏ vào Project của bạn ở cùng cấp với exe
- B5: Giải nén Chrome.zip để có file Chrome.dll trong thư mục data/orbitar-browser
- B6: Xem code mẫu để biết những hàm cần sử dụng

Lưu ý: Phải có thư mục data của VNLogin để DLL chạy không bị lỗi thiếu data.

LỖI THƯỜNG GẶP

1. System.BadImageFormatException: 'An attempt was made to load a program with an incorrect format

  - Nguyên nhân: bạn đang bật Prefer 32bit trong Properties -> Build -> Platform targer
  - Khắc phục: Tắt chế độ Prefer 32bit.
  
 2. Khi dùng các hàm sẽ có những lỗi sau được trả về:
  
  - er1: (lỗi quá giới hạn thiết bị được phép đăng nhập, chờ vài phút để session reset)
  - er2: (lỗi key không đúng)
  - er3: (lỗi user không tồn tại)
  - expired: (lỗi hết hạn sử dụng key)
