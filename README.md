# 📚 Lab_PRN212_NguyenDang - Hướng dẫn & Tài liệu các Lab C#

Chào mừng bạn đến với kho lưu trữ mã nguồn các bài tập Lab môn **PRN212 (Lập trình C#)** của Nguyễn Đăng. 
Tài liệu này được biên soạn nhằm giúp người đọc và người đánh giá hiểu rõ cấu trúc, mục đích và cách thức hoạt động của từng project có trong repository này.

---

## 🗺️ Bản đồ Thư mục & Tổng quan dự án

Repository hiện tại bao gồm **4 thư mục chính** tương ứng với các bài học và bài tập thực hành khác nhau trên lớp:

| # | Thư mục | Chủ đề / Kiến thức trọng tâm | Mô tả ngắn |
|---|---|---|---|
| 1 | **[DemoDesignPattern](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/DemoDesignPattern)** | `Abstract Factory` Pattern | Minh họa mẫu thiết kế khởi tạo họ đối tượng trừu tượng. |
| 2 | **[LINQ_Exercises](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/LINQ_Exercises)** | `LINQ` (Language Integrated Query) | Thực hành lọc, sắp xếp, và gom nhóm dữ liệu (Slide 32-34). |
| 3 | **[Lab2_NguyenDang_DE190324](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/Lab2_NguyenDang_DE190324)** | Hướng đối tượng nâng cao (`OOP`) | Quản lý sản phẩm, xử lý biệt lệ và kiểm tra tính hợp lệ dữ liệu nhập. |
| 4 | **[Lab3_collection_Generic](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/Lab3_collection_Generic)** | `Collections` & `Generics` | Khung xương (skeleton) chuẩn bị cho việc thực hành các tập hợp generic. |

---

## 🔍 Chi tiết từng Project

### 📂 1. DemoDesignPattern
*Đường dẫn mã nguồn chính:* [Program.cs](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/DemoDesignPattern/DemoDesignPattern/Program.cs)

#### 📝 Giới thiệu & Mục tiêu
Project này được xây dựng để thực hành mẫu thiết kế **Abstract Factory (Nhà máy Trừu tượng)**. Đây là một mẫu thiết kế thuộc nhóm khởi tạo (Creational Pattern) rất phổ biến trong lập trình hướng đối tượng.

#### ⚙️ Các khái niệm & Kiến thức áp dụng
*   **Abstract Factory**: Định nghĩa một giao diện (`AbstractFactory`) để tạo ra các sản phẩm trừu tượng.
*   **Concrete Factory**: Các lớp nhà máy cụ thể (`ConcreteFactory1`, `ConcreteFactory2`) thực thi việc khởi tạo các sản phẩm tương ứng.
*   **Abstract Product & Concrete Product**: Định nghĩa giao diện cho các sản phẩm dòng A, B (`AbstractProductA`, `AbstractProductB`) và các lớp triển khai cụ thể của chúng (`ProductA1`, `ProductA2`, `ProductB1`, `ProductB2`).
*   **Loosely Coupling (Liên kết lỏng lẻo)**: Lớp `Client` sử dụng các factory mà không cần biết chính xác lớp cụ thể nào đang được khởi tạo, giúp mã nguồn dễ mở rộng hơn trong tương lai.

---

### 📂 2. LINQ_Exercises
*Đường dẫn mã nguồn chính:* [Program.cs](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/LINQ_Exercises/LINQ_Exercises/Program.cs)

#### 📝 Giới thiệu & Mục tiêu
Project chứa các bài tập truy vấn dữ liệu tích hợp trong C# (**LINQ - Language Integrated Query**). Nó minh họa cách xử lý và chuyển đổi tập dữ liệu một cách ngắn gọn, tường minh thay vì sử dụng các vòng lặp `for` hoặc `foreach` lồng nhau phức tạp.

#### ⚙️ Các khái niệm & Kiến thức áp dụng
Chương trình được chia thành 3 phần rõ rệt ứng với các Slide lý thuyết:
1.  **Slide 32 (Truy vấn & Lọc cơ bản)**:
    *   **Bài 1**: Lọc số chẵn từ mảng số nguyên bằng cú pháp truy vấn (**Query Syntax**): `from tmp in ... where ... select tmp`.
    *   **Bài 2**: Kết hợp nhiều điều kiện lọc số trong khoảng `(0, 12)` bằng **Query Syntax**.
    *   **Bài 3**: Lọc danh sách chuỗi (tên con vật) có độ dài `>= 5` kí tự và chuyển thành chữ in hoa bằng cú pháp phương thức (**Method Syntax**): `.Where().Select(x => x.ToUpper())`.
2.  **Slide 33 (Sắp xếp & Giới hạn dữ liệu)**:
    *   **Bài 4**: Sắp xếp giảm dần và lấy ra top 5 số lớn nhất sử dụng `.OrderByDescending().Take(5)`.
    *   **Bài 5**: Sắp xếp danh sách các đối tượng tự định nghĩa (`Pet`) theo thứ tự tuổi tăng dần sử dụng `.OrderBy(pet => pet.Age)`.
3.  **Slide 34 (Liên kết nâng cao & Trải phẳng tập hợp)**:
    *   **Bài 6**: Sử dụng `.SelectMany()` để duyệt qua danh sách các thú cưng của từng chủ sở hữu (`PetOwner`), lọc tên thú cưng bắt đầu bằng chữ `"S"`, sau đó chiếu thành đối tượng ẩn danh (**Anonymous Type**) gồm 2 thuộc tính `Owner` và `Pet`.

---

### 📂 3. Lab2_NguyenDang_DE190324
*Đường dẫn mã nguồn chính:* [Product.cs](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/Lab2_NguyenDang_DE190324/DemoConsole/Console1/Product.cs) | [Program.cs](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/Lab2_NguyenDang_DE190324/DemoConsole/Console1/Program.cs)

#### 📝 Giới thiệu & Mục tiêu
Đây là một chương trình Console tương tác quản lý thông tin các mặt hàng (Product), áp dụng chặt chẽ các nguyên lý lập trình hướng đối tượng (OOP) cơ bản và các kỹ thuật xử lý ngoại lệ/nhập liệu an toàn.

#### ⚙️ Các khái niệm & Kiến thức áp dụng
*   **Đóng gói (Encapsulation)**: Che giấu các trường dữ liệu bằng thuộc tính `private` (`name`, `price`, `discount`) và chỉ cho phép truy cập thông qua các thuộc tính công khai (`Properties` có `get` và `set`).
*   **Đa hình Constructor (Overloading)**: 
    *   Constructor đầy đủ 3 tham số để gán tất cả dữ liệu.
    *   Constructor 2 tham số tự động gán giá trị mặc định cho discount là `0` thông qua cú pháp tái sử dụng constructor (`: this(name, price, 0)`).
*   **Kiểm soát lỗi nhập liệu (Input Validation)**:
    *   `ReadRequiredString`: Ngăn chặn chuỗi rỗng hoặc chỉ toàn khoảng trắng.
    *   `ReadPositiveDouble`: Ép kiểu dữ liệu số thực thành công và đảm bảo giá trị phải `>= 0`.
    *   `ReadDiscount`: Đảm bảo tỉ lệ giảm giá nằm trong phạm vi từ `0.0` đến `1.0` (từ 0% đến 100%).
*   **Thuế nhập khẩu**: Phương thức `GetImportTax()` tính thuế nhập khẩu tự động bằng `10%` giá trị của sản phẩm.
*   **Giao diện người dùng trực quan**: Đổi màu sắc chữ Console (`Console.ForegroundColor`) khi hiển thị lỗi hoặc nhãn nhập liệu, giúp tăng trải nghiệm người dùng.

---

### 📂 4. Lab3_collection_Generic
*Đường dẫn mã nguồn chính:* [Program.cs](file:///d:/Hoc_web_C%23/Lab_PRN212_NguyenDang/Lab3_collection_Generic/Lab3_collection_Generic/Program.cs)

#### 📝 Giới thiệu & Mục tiêu
Project thực hành nâng cao về **Tập hợp (Collections)** và **Lớp tổng quát (Generics)** trong C#, giải quyết 4 bài tập thực tế từ cơ bản đến nâng cao.

#### ⚙️ Các khái niệm & Kiến thức áp dụng
*   **Bài 1: Generic Calculator**: Xây dựng lớp máy tính tổng quát `GenericCalculator<T>` thực hiện các phép toán cộng, trừ, nhân, chia cho các kiểu dữ liệu số tùy ý thông qua việc ép kiểu động `dynamic`. Xử lý ngoại lệ chia cho 0 an toàn.
*   **Bài 2: Generic Collection**: Sử dụng `List<Product>` lưu trữ và quản lý danh sách sản phẩm với các thuộc tính `Name`, `Cost`, `Quantity`. Nạp chồng phương thức `ToString()` để hiển thị thông tin sản phẩm trực quan.
*   **Bài 3: Hashtable**: Sử dụng cấu trúc dữ liệu phi generic `Hashtable` lưu trữ các ngày trong tuần (Key là số từ 1-7, Value là chuỗi tên ngày). Tìm kiếm phần tử chỉ định (`Tuesday`) và duyệt qua toàn bộ tập hợp sử dụng `DictionaryEntry`.
*   **Bài 4: Generic Swap**: Xây dựng phương thức generic tĩnh `Swap<T>(ref T a, ref T b)` hỗ trợ hoán đổi giá trị của hai biến thuộc kiểu dữ liệu bất kỳ (số nguyên, chuỗi...).

---

## 🚀 Hướng dẫn biên dịch và Chạy thử nghiệm

Để biên dịch và chạy các bài tập này trên máy tính của bạn:

1.  **Yêu cầu môi trường**: Đã cài đặt **.NET SDK 8.0** trở lên và **Visual Studio 2022** hoặc **VS Code**.
2.  **Cách mở dự án**:
    *   Mở Visual Studio, chọn `Open a project or solution` và trỏ tới file solution của project mong muốn (ví dụ: `LINQ_Exercises.slnx` hoặc `DemoDesignPattern.slnx`).
3.  **Chạy bằng Terminal (Command Line)**:
    *   Di chuyển terminal vào thư mục chứa dự án mong muốn (ví dụ: `cd LINQ_Exercises/LINQ_Exercises`).
    *   Chạy lệnh:
        ```bash
        dotnet run
        ```

---
*Chúc các bạn học tập tốt môn PRN212!*
