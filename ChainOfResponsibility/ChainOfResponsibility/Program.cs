using System;

namespace ChainOfResponsibility
{
    public interface IDirProcessor
    {
        IDirProcessor SetNext(IDirProcessor dirProcessor);

        bool Process(string dir);
    }

    abstract class DirProcessor : IDirProcessor
    {
        private IDirProcessor _nextProcessor;

        public IDirProcessor SetNext(IDirProcessor dirProcessor)
        {
            this._nextProcessor = dirProcessor;

            return dirProcessor;
        }

        public virtual bool Process(string dir)
        {
            if(this._nextProcessor != null)
            {
                return this._nextProcessor.Process(dir);
            }
            else
            {
                return true;
            }
        }
    }

    class Normalizer : DirProcessor
    {
        public override bool Process(string dir)
        {
            Console.WriteLine($"Normalized {dir}");
            return base.Process(dir);
        }
    }

    class LowerCase : DirProcessor
    {
        public override bool Process(string dir)
        {
            Console.WriteLine($"Lower cased {dir}");
            return base.Process(dir);
        }
    }

    class Validator : DirProcessor
    {
        public override bool Process(string dir)
        {
            Console.WriteLine($"Validated {dir}");
            return base.Process(dir);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var normalizer = new Normalizer();
            var lowerCase = new LowerCase();
            var validator = new Validator();

            normalizer.SetNext(lowerCase).SetNext(validator);

            var res = normalizer.Process(@"c:\abc\def");

            if(res)
            {
                Console.WriteLine("All processors worked well");
            }
            else
            {
                Console.WriteLine("One of the processor failed");
            }
        }
    }
}
