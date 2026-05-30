#pragma warning disable CS8600, CS8602, CS8618
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3_collection_Generic
{
    // Custom Validation Exception
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    // Product class (Bài 2) with Encapsulation & Validation
    class Product
    {
        private string name;
        private double cost;
        private int quantity;

        public Product(string name, double cost, int quantity)
        {
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Product name cannot be empty or whitespace.");
                name = value.Trim();
            }
        }

        public double Cost
        {
            get => cost;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Product cost must be greater than or equal to 0.");
                cost = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Product quantity must be greater than or equal to 0.");
                quantity = value;
            }
        }

        public override string ToString()
        {
            return $"[Product] Name: {Name,-15} | Cost: {Cost,8:C} | Quantity: {Quantity,5}";
        }
    }

    // Bài 1: Generic Calculator
    class GenericCalculator<T>
    {
        public T Add(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }

        public T Subtract(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x - y;
        }

        public T Multiply(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x * y;
        }

        public T Divide(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return x / y;
        }
    }

    // Bài 4: Generic Swap
    class GenericSwap
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==================================================");
                Console.WriteLine("          LAB 3: COLLECTIONS & GENERICS           ");
                Console.WriteLine("==================================================");
                Console.ResetColor();
                Console.WriteLine("1. Bài 1: Generic Calculator (Với kiểm lỗi nhập liệu)");
                Console.WriteLine("2. Bài 2: Generic Collection Product (Nhập và Quản lý danh sách)");
                Console.WriteLine("3. Bài 3: Hashtable Days of Week (Tra cứu & Tìm kiếm hợp lệ)");
                Console.WriteLine("4. Bài 4: Generic Swap (Hoán đổi đa kiểu dữ liệu có validate)");
                Console.WriteLine("5. Thoát");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==================================================");
                Console.ResetColor();

                int choice = ReadInt("Chọn chức năng (1-5)", 1, 5);

                switch (choice)
                {
                    case 1:
                        RunGenericCalculator();
                        break;
                    case 2:
                        RunGenericCollection();
                        break;
                    case 3:
                        RunHashtableDemo();
                        break;
                    case 4:
                        RunGenericSwap();
                        break;
                    case 5:
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCảm ơn bạn đã sử dụng chương trình!");
                        Console.ResetColor();
                        break;
                }

                if (!exit)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu chính...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        // ==========================================
        // BÀI 1: GENERIC CALCULATOR
        // ==========================================
        static void RunGenericCalculator()
        {
            PrintHeader("BÀI 1: GENERIC CALCULATOR (CÓ VALIDATE)");
            
            double num1 = ReadDouble("Nhập số thứ nhất (a)");
            double num2 = ReadDouble("Nhập số thứ hai (b)");

            GenericCalculator<double> cal = new GenericCalculator<double>();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Kết quả phép toán với kiểu Double]:");
            Console.ResetColor();
            Console.WriteLine($"- Phép cộng (a + b)  : {cal.Add(num1, num2)}");
            Console.WriteLine($"- Phép trừ (a - b)   : {cal.Subtract(num1, num2)}");
            Console.WriteLine($"- Phép nhân (a * b)  : {cal.Multiply(num1, num2)}");

            try
            {
                double divResult = cal.Divide(num1, num2);
                Console.WriteLine($"- Phép chia (a / b)  : {divResult}");
            }
            catch (DivideByZeroException ex)
            {
                PrintValidationError($"- Phép chia (a / b)  : Lỗi: {ex.Message}");
            }
        }

        // ==========================================
        // BÀI 2: GENERIC COLLECTION (PRODUCT)
        // ==========================================
        static void RunGenericCollection()
        {
            PrintHeader("BÀI 2: GENERIC COLLECTION (PRODUCT LIST WITH INPUT VALIDATION)");

            List<Product> products = new List<Product>
            {
                new Product("Laptop", 1500.0, 10),
                new Product("Smartphone", 800.0, 20),
                new Product("Tablet", 500.0, 15)
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Danh sách sản phẩm mẫu ban đầu:");
            Console.ResetColor();
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("\n[Thêm sản phẩm mới với kiểm soát lỗi nhập liệu]");
            int countToAdd = ReadInt("Bạn muốn nhập thêm bao nhiêu sản phẩm?", 0, 10);

            for (int i = 1; i <= countToAdd; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nNhập sản phẩm thứ {i}:");
                Console.ResetColor();
                
                string name = "";
                double cost = 0;
                int quantity = 0;
                bool validProduct = false;

                while (!validProduct)
                {
                    try
                    {
                        name = ReadRequiredString("Tên sản phẩm");
                        cost = ReadDouble("Giá sản phẩm (Cost)", 0);
                        quantity = ReadInt("Số lượng (Quantity)", 0);

                        // Thử tạo để kích hoạt property validation
                        Product p = new Product(name, cost, quantity);
                        products.Add(p);
                        validProduct = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("-> Thêm sản phẩm thành công!");
                        Console.ResetColor();
                    }
                    catch (ArgumentException ex)
                    {
                        PrintValidationError($"Lỗi thuộc tính sản phẩm: {ex.Message} Vui lòng nhập lại.");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDanh sách tất cả sản phẩm hiện có:");
            Console.ResetColor();
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }

        // ==========================================
        // BÀI 3: HASHTABLE DAYS OF WEEK
        // ==========================================
        static void RunHashtableDemo()
        {
            PrintHeader("BÀI 3: HASHTABLE DAYS OF WEEK (VALIDATED SEARCH)");

            Hashtable days = new Hashtable
            {
                { 1, "Monday" },
                { 2, "Tuesday" },
                { 3, "Wednesday" },
                { 4, "Thursday" },
                { 5, "Friday" },
                { 6, "Saturday" },
                { 7, "Sunday" }
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Danh sách Hashtable (Key (Mã) -> Value (Thứ)):");
            Console.ResetColor();
            foreach (DictionaryEntry item in days)
            {
                Console.WriteLine($"Mã: {item.Key} -> Thứ: {item.Value}");
            }

            Console.WriteLine("\n[1. Tra cứu thứ theo mã số]");
            int searchKey = ReadInt("Nhập mã số cần tìm (1 - 7)", 1, 7);
            if (days.ContainsKey(searchKey))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"-> Tìm thấy: Mã số {searchKey} tương ứng với ngày: {days[searchKey]}");
                Console.ResetColor();
            }

            Console.WriteLine("\n[2. Kiểm tra sự tồn tại của ngày trong tuần]");
            string searchVal = ReadRequiredString("Nhập tên ngày cần tìm kiếm (Ví dụ: Tuesday)");
            
            bool found = false;
            foreach (DictionaryEntry item in days)
            {
                if (string.Equals(item.Value.ToString(), searchVal, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"-> Kết quả: Tìm thấy ngày '{searchVal}' trong tuần.");
                Console.ResetColor();
            }
            else
            {
                PrintValidationError($"-> Kết quả: Không tìm thấy ngày '{searchVal}' trong tuần (Lưu ý viết đúng tiếng Anh).");
            }
        }

        // ==========================================
        // BÀI 4: GENERIC SWAP
        // ==========================================
        static void RunGenericSwap()
        {
            PrintHeader("BÀI 4: GENERIC SWAP (HOÁN ĐỔI ĐA DẠNG CÓ VALIDATE)");

            Console.WriteLine("Chọn kiểu dữ liệu bạn muốn hoán đổi:");
            Console.WriteLine("1. Kiểu Số nguyên (Integer)");
            Console.WriteLine("2. Kiểu Chuỗi (String)");
            int swapChoice = ReadInt("Lựa chọn (1-2)", 1, 2);

            if (swapChoice == 1)
            {
                int val1 = ReadInt("Nhập số nguyên thứ nhất");
                int val2 = ReadInt("Nhập số nguyên thứ hai");

                Console.WriteLine($"Trước khi Swap: Số thứ 1 = {val1}, Số thứ 2 = {val2}");
                GenericSwap.Swap(ref val1, ref val2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Sau khi Swap  : Số thứ 1 = {val1}, Số thứ 2 = {val2}");
                Console.ResetColor();
            }
            else
            {
                string s1 = ReadRequiredString("Nhập chuỗi thứ nhất");
                string s2 = ReadRequiredString("Nhập chuỗi thứ hai");

                Console.WriteLine($"Trước khi Swap: Chuỗi thứ 1 = \"{s1}\", Chuỗi thứ 2 = \"{s2}\"");
                GenericSwap.Swap(ref s1, ref s2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Sau khi Swap  : Chuỗi thứ 1 = \"{s1}\", Chuỗi thứ 2 = \"{s2}\"");
                Console.ResetColor();
            }
        }

        // ==========================================
        // CÁC PHƯƠNG THỨC TRỢ GIÚP VALIDATE NHẬP LIỆU
        // ==========================================
        private static string ReadRequiredString(string label)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{label}: ");
                Console.ResetColor();
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                PrintValidationError("Lỗi: Dữ liệu nhập không được để trống. Vui lòng nhập lại.");
            }
        }

        private static double ReadDouble(string label, double? min = null, double? max = null)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{label}: ");
                Console.ResetColor();
                var input = Console.ReadLine();
                if (double.TryParse(input, out var value))
                {
                    if (min.HasValue && value < min.Value)
                    {
                        PrintValidationError($"Lỗi: Giá trị nhập phải >= {min.Value}. Vui lòng nhập lại.");
                        continue;
                    }
                    if (max.HasValue && value > max.Value)
                    {
                        PrintValidationError($"Lỗi: Giá trị nhập phải <= {max.Value}. Vui lòng nhập lại.");
                        continue;
                    }
                    return value;
                }

                PrintValidationError("Lỗi: Định dạng số thực không hợp lệ. Vui lòng nhập lại.");
            }
        }

        private static int ReadInt(string label, int? min = null, int? max = null)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{label}: ");
                Console.ResetColor();
                var input = Console.ReadLine();
                if (int.TryParse(input, out var value))
                {
                    if (min.HasValue && value < min.Value)
                    {
                        PrintValidationError($"Lỗi: Giá trị nhập phải >= {min.Value}. Vui lòng nhập lại.");
                        continue;
                    }
                    if (max.HasValue && value > max.Value)
                    {
                        PrintValidationError($"Lỗi: Giá trị nhập phải <= {max.Value}. Vui lòng nhập lại.");
                        continue;
                    }
                    return value;
                }

                PrintValidationError("Lỗi: Định dạng số nguyên không hợp lệ. Vui lòng nhập lại.");
            }
        }

        private static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($">>> {title} <<<");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('-', title.Length + 8));
            Console.ResetColor();
        }

        private static void PrintValidationError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
