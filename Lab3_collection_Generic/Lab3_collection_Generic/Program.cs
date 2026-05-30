using System;

namespace DemoDesignPattern
{
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA() => new ProductA1();
        public override AbstractProductB CreateProductB() => new ProductB1();
    }

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA() => new ProductA2();
        public override AbstractProductB CreateProductB() => new ProductB2();
    }

    abstract class AbstractProductA
    {
        public abstract void ShowA();
    }

    class ProductA1 : AbstractProductA
    {
        public override void ShowA() => Console.WriteLine("ProductA1");
    }

    class ProductA2 : AbstractProductA
    {
        public override void ShowA() => Console.WriteLine("ProductA2");
    }

    abstract class AbstractProductB
    {
        public abstract void ShowB();
    }

    class ProductB1 : AbstractProductB
    {
        public override void ShowB() => Console.WriteLine("ProductB1");
    }

    class ProductB2 : AbstractProductB
    {
        public override void ShowB() => Console.WriteLine("ProductB2");
    }

    class Client
    {
        private readonly AbstractProductA _productA;
        private readonly AbstractProductB _productB;

        public Client(AbstractFactory factory)
        {
            _productA = factory.CreateProductA();
            _productB = factory.CreateProductB();
        }

        public void Run()
        {
            _productA.ShowA();
            _productB.ShowB();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory 1:");
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            Console.WriteLine();
            Console.WriteLine("Factory 2:");
            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();
            Console.ReadLine();
        }
    }
}
