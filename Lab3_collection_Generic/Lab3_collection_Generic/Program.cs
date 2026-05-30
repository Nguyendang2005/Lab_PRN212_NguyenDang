#pragma warning disable CS8600, CS8602
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3_collection_Generic
{
    // Product class (Bài 2)
    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double cost, int quantity)
        {
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Cost: {Cost}, Quantity: {Quantity}";
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
            Console.WriteLine("===============Lab3==============\n");

            // Bài 1: Generic Calculator
            Console.WriteLine("Bài 1: Generic Calculator");
            GenericCalculator<double> cal = new GenericCalculator<double>();
            double a = 10.5;
            double b = 5.2;

            Console.WriteLine("Addition: " + cal.Add(a, b));
            Console.WriteLine("Subtraction: " + cal.Subtract(a, b));
            Console.WriteLine("Multiplication: " + cal.Multiply(a, b));
            Console.WriteLine("Division: " + cal.Divide(a, b));

            Console.WriteLine("\n----------------------------------\n");

            // Bài 2: Generic Collection
            Console.WriteLine("Bài 2: Generic Collection");
            List<Product> products = new List<Product>();
            products.Add(new Product("Laptop", 1500.0, 10));
            products.Add(new Product("Smartphone", 800.0, 20));
            products.Add(new Product("Tablet", 500.0, 15));
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\n-------------------------\n");

            // Bài 3: Hashtable
            Console.WriteLine("Bài 3: Hashtable");
            Hashtable days = new Hashtable();
            days.Add(1, "Monday");
            days.Add(2, "Tuesday");
            days.Add(3, "Wednesday");
            days.Add(4, "Thursday");
            days.Add(5, "Friday");
            days.Add(6, "Saturday");
            days.Add(7, "Sunday");

            bool found = false;
            foreach (DictionaryEntry item in days)
            {
                if (item.Value.ToString() == "Tuesday")
                {
                    found = true;
                    break;
                }
            }

            Console.WriteLine(found ? "Tuesday found." : "Tuesday not found.");
            Console.WriteLine("\nDays of Week:");
            foreach (DictionaryEntry item in days)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine("\n-------------------------\n");

            // Bài 4: Generic Swap
            Console.WriteLine("Bài 4: Generic Swap");
            int x = 10;
            int y = 20;
            Console.WriteLine($"Before Swap: x = {x}, y = {y}");
            GenericSwap.Swap(ref x, ref y);
            Console.WriteLine($"After Swap : x = {x}, y = {y}");

            string s1 = "Hello";
            string s2 = "World";
            Console.WriteLine($"\nBefore Swap: s1 = {s1}, s2 = {s2}");
            GenericSwap.Swap(ref s1, ref s2);
            Console.WriteLine($"After Swap : s1 = {s1}, s2 = {s2}");

            Console.WriteLine("\n========== END ==========");
        }
    }
}
