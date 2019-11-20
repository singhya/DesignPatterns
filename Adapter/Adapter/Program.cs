using System;

namespace Adapter
{
    public interface IJson
    {
        string GetJson();
    }

    class XML
    {
        public string GetXML()
        {
            return "This returns an XML string";
        }
    }

    class XMLToJson : IJson
    {
        private readonly XML _xml;

        public XMLToJson(XML xml)
        {
            this._xml = xml;
        }

        public string GetJson()
        {
            return "This converts xml string to json";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XML xml = new XML();
            IJson json = new XMLToJson(xml);

            Console.WriteLine("XML is incompatible with client");
            Console.WriteLine("But with XMLToJson, XML can be converted to JSON so that it can be passed in acceptable format to client ");

            Console.WriteLine(json.GetJson());
        }
    }
}
