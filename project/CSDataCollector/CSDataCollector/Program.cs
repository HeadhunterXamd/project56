using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileInfo file = new FileInfo("../../test.json");

            //string data = file.OpenText().ReadToEnd();

            //Input.DataParser d = new Input.DataParser();
            //d.DecodeData(data, "Connection");
            //Console.In.Read();


            Input.InputManager man = new Input.InputManager("m20.cloudmqtt.com");



        }
    }
}
