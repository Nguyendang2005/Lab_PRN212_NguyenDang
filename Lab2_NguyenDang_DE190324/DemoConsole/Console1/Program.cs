namespace Console1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 2: input 2 products from keyboard
            var pd1 = new Product("", 0, 0);
            var pd2 = new Product("", 0, 0);
            pd1.Input();
            pd2.Input();
            pd1.Display();
            pd2.Display();

            // Part 3: create with constructors
            var pd3 = new Product("Pen", 10, 1);
            var pd4 = new Product("Book", 20);
            pd3.Display();
            pd4.Display();
        }
    }
}
