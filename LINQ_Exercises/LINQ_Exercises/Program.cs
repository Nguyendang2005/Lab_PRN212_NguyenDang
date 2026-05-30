using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Exercises
{
    // Định nghĩa các class phục vụ cho bài tập trên Slide
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ==========================================
            // SLIDE 32
            // ==========================================
            Console.WriteLine("--- SLIDE 32 ---");

            // #1. Lọc số chẵn
            int[] n1_ex1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var nQuery1 = from tmp in n1_ex1
                          where (tmp % 2) == 0
                          select tmp;

            Console.Write("#1. Các số chẵn: ");
            foreach (var item in nQuery1) Console.Write(item + " ");
            Console.WriteLine();

            // #2. Lọc số trong khoảng (0, 12)
            int[] n1_ex2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
            var nQuery2 = from tmp in n1_ex2
                          where tmp > 0 && tmp < 12 // Gộp điều kiện lại cho chuẩn cú pháp
                          select tmp;

            Console.Write("#2. Các số lớn hơn 0 và nhỏ hơn 12: ");
            foreach (var item in nQuery2) Console.Write(item + " ");
            Console.WriteLine();

            // #3. Lọc từ có độ dài >= 5 và chuyển sang chữ IN HOA
            List<string> animals = new List<string> { "zebra", "elephant", "cat", "dog", "rhino", "bat" };
            var selectedAnimals = animals.Where(s => s.Length >= 5).Select(x => x.ToUpper());

            Console.Write("#3. Con vật có tên >= 5 ký tự (In hoa): ");
            foreach (var animal in selectedAnimals) Console.Write(animal + " ");
            Console.WriteLine("\n");


            // ==========================================
            // SLIDE 33
            // ==========================================
            Console.WriteLine("--- SLIDE 33 ---");

            // #4. Sắp xếp giảm dần và lấy Top 5
            List<int> numbers = new List<int> { 6, 0, 999, 11, 443, 6, 1, 24, 54 };
            var top5 = numbers.OrderByDescending(x => x).Take(5);

            Console.Write("#4. Top 5 số lớn nhất: ");
            foreach (var num in top5) Console.Write(num + " ");
            Console.WriteLine();

            // #5. Sắp xếp Pet theo tuổi tăng dần
            Pet[] pets = {
                new Pet { Name = "Barley", Age = 8 },
                new Pet { Name = "Boots", Age = 4 },
                new Pet { Name = "Whiskers", Age = 1 }
            };
            IEnumerable<Pet> petQuery = pets.OrderBy(pet => pet.Age);

            Console.WriteLine("#5. Danh sách thú cưng theo tuổi tăng dần:");
            foreach (var pet in petQuery)
            {
                Console.WriteLine($"   - {pet.Name} ({pet.Age} tuổi)");
            }
            Console.WriteLine();


            // ==========================================
            // SLIDE 34
            // ==========================================
            Console.WriteLine("--- SLIDE 34 ---");

            // #6. SelectMany kết hợp lọc tên Pet bắt đầu bằng chữ "S"
            PetOwner[] petOwners = {
                new PetOwner { Name = "Higa", Pets = new List<string> { "Scruffy", "Sam" } },
                new PetOwner { Name = "Ashkenazi", Pets = new List<string> { "Walker", "Sugar" } },
                new PetOwner { Name = "Price", Pets = new List<string> { "Scratches", "Diesel" } },
                new PetOwner { Name = "Hines", Pets = new List<string> { "Dusty" } }
            };

            var querySelectMany = petOwners
                .SelectMany(
                    petOwner => petOwner.Pets,
                    (petOwner, petName) => new { petOwner, petName }
                )
                .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                .Select(ownerAndPet => new {
                    Owner = ownerAndPet.petOwner.Name,
                    Pet = ownerAndPet.petName
                });

            Console.WriteLine("#6. Chủ và Thú cưng có tên bắt đầu bằng chữ 'S':");
            foreach (var item in querySelectMany)
            {
                Console.WriteLine($"   - Chủ: {item.Owner} || Thú cưng: {item.Pet}");
            }

            Console.ReadLine();
        }
    }
}