namespace Console1
{
    internal class Product
    {
        // Encapsulation: private fields
        private string name;
        private double price;
        private double discount;

        // Constructors
        public Product(string name, double price, double discount)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
        }

        public Product(string name, double price)
            : this(name, price, 0)
        {
        }

        // Getters/Setters
        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
        }

        public double Discount
        {
            get => discount;
            set => discount = value;
        }

        // Private method for import tax
        private double GetImportTax()
        {
            return price * 0.10;
        }

        // Public methods
        public void Input()
        {
            name = ReadRequiredString("ProductName");
            price = ReadPositiveDouble("Price");
            discount = ReadDiscount("Discount (0-1)");
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Product");
            Console.ResetColor();
            Console.WriteLine($"{"ProductName",-12}: {name}");
            Console.WriteLine($"{"Price",-12}: {price}");
            Console.WriteLine($"{"Discount",-12}: {discount}");
            Console.WriteLine($"{"ImportTax",-12}: {GetImportTax()}");
        }

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

                PrintError("Khong duoc de trong. Vui long nhap lai.");
            }
        }

        private static double ReadPositiveDouble(string label)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{label}: ");
                Console.ResetColor();
                var input = Console.ReadLine();
                if (double.TryParse(input, out var value) && value >= 0)
                {
                    return value;
                }

                PrintError("Gia tri khong hop le. Vui long nhap so >= 0.");
            }
        }

        private static double ReadDiscount(string label)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{label}: ");
                Console.ResetColor();
                var input = Console.ReadLine();
                if (double.TryParse(input, out var value) && value >= 0 && value <= 1)
                {
                    return value;
                }

                PrintError("Discount phai nam trong khoang 0..1.");
            }
        }

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
