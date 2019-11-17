using System;

namespace FactoryMethod
{
    abstract class TrasportFactory
    {
        public abstract Transport FactoryMethod();
        string productName;
        int count;

        public void CreateTrasport()
        {
            var product = FactoryMethod();
            productName = product.Name();
            count++;
        }

        public int Count()
        {
            return count;
        }

        public string GetProductName()
        {
            return productName;
        }

        public abstract string GetFactoryName();
    }

    abstract class ShipFactory : TrasportFactory
    {
        public override Transport FactoryMethod()
        {
            return new Ship();
        }
    }

    class ModernShipFactory : ShipFactory
    {
        public override string GetFactoryName()
        {
            return $"Modern {GetProductName()} Factory";
        }
    }

    class OldShipFactory : ShipFactory
    {
        public override string GetFactoryName()
        {
            return $"Old {GetProductName()} Factory";
        }
    }

    class TruckFactory : TrasportFactory
    {
        public override Transport FactoryMethod()
        {
            return new Truck();
        }

        public override string GetFactoryName()
        {
            return $"{GetProductName()} Factory";
        }
    }

    public interface Transport
    {
        string Name();
    }

    class Ship : Transport
    {
        public string Name()
        {
            return "Ship";
        }
    }

    class Truck : Transport
    {
        public string Name()
        {
            return "Truck";
        }
    }

    class Client
    {
        public void Main()
        {
            ClientCode(new TruckFactory());
            ClientCode(new ModernShipFactory());
            ClientCode(new OldShipFactory());
        }

        public void ClientCode(TrasportFactory factory)
        {
            for (int i = 0; i < 10; i++)
            {
                factory.CreateTrasport();
                Console.WriteLine($"{factory.GetFactoryName()} created {factory.Count()} {factory.GetProductName()}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
