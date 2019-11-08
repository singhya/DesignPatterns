using System;

namespace FurnitureShop
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
        ISofa CreateSofa();

    }

    class MordernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ITable CreateTable()
        {
            return new ModernTable();
        }

        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }

    class OldFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new OldChair();
        }

        public ITable CreateTable()
        {
            return new OldTable();
        }

        public ISofa CreateSofa()
        {
            return new OldSofa();
        }

    }

    public interface IChair
    {
        int GetChairPrice();
    }

    public interface ITable
    {
        int GetTablePrice();
    }

    public interface ISofa
    {
        int GetSofaPrice();
    }

    class ModernChair : IChair
    {
        public ModernChair()
        {
            Console.WriteLine("Modern chair created");
        }

        public int GetChairPrice()
        {
            return 1000;
        }
    }

    class ModernTable : ITable
    {
        public ModernTable()
        {
            Console.WriteLine("Modern table created");
        }

        public int GetTablePrice()
        {
            return 1500;
        }
    }

    class ModernSofa : ISofa
    {
        public ModernSofa()
        {
            Console.WriteLine("Modern sofa created");
        }

        public int GetSofaPrice()
        {
            return 2000;
        }
    }

    class OldChair : IChair
    {
        public OldChair()
        {
            Console.WriteLine("Old chair created");
        }

        public int GetChairPrice()
        {
            return 500;
        }
    }

    class OldTable : ITable
    {
        public OldTable()
        {
            Console.WriteLine("Old table created");
        }

        public int GetTablePrice()
        {
            return 750;
        }
    }

    class OldSofa : ISofa
    {
        public OldSofa()
        {
            Console.WriteLine("Old sofa created");
        }

        public int GetSofaPrice()
        {
            return 950;
        }
    }

    class client
    {
        public void Main()
        {
            int ModernFurnitureCost = TotalCostOfFurnitures(new MordernFurnitureFactory());
            int OldFurnitureCost = TotalCostOfFurnitures(new OldFurnitureFactory());

            Console.WriteLine($"Total cost of modern furnitures is : ${ModernFurnitureCost}");
            Console.WriteLine($"Total cost of old furnitures is : ${OldFurnitureCost}");
        }

        public int TotalCostOfFurnitures(IFurnitureFactory factory)
        {
            var chair = factory.CreateChair();
            var table = factory.CreateTable();
            var sofa = factory.CreateSofa();

            return chair.GetChairPrice() + table.GetTablePrice() + sofa.GetSofaPrice();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new client().Main();
        }
    }
}
