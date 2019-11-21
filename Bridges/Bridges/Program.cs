using System;

namespace Bridges
{
    class Shape
    {
        protected IColor _color;

        public Shape(IColor color)
        {
            _color = color;
        }

        public virtual string GetShape()
        {
            return $"It is an abstract shape with {_color.GetColorName()} color";
        }
    }

    class Sphere: Shape
    {
        public Sphere(IColor color) : base (color)
        {

        }

        public override string GetShape()
        {
            return $"It is a sphere with {_color.GetColorName()} color";
        }
    }

    class Cube : Shape
    {
        public Cube(IColor color) : base(color)
        {

        }

        public override string GetShape()
        {
            return $"It is a cube with {_color.GetColorName()} color";
        }
    }

    public interface IColor
    {
        string GetColorName();
    }

    class Red : IColor
    {
        public string GetColorName()
        {
            return "red";
        }
    }

    class Blue : IColor
    {
        public string GetColorName()
        {
            return "blue";
        }
    }

    class Client
    {
        public void ClientCode(Shape shape)
        {
            Console.WriteLine(shape.GetShape());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Shape shape;
            shape = new Shape(new Red());

            client.ClientCode(shape);

            shape = new Sphere(new Blue());
            client.ClientCode(shape);
        }
    }
}
