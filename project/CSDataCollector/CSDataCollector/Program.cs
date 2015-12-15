using CSDataCollector.WrapperClasses;
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

        private static FileInfo file;

        static void Main(string[] args)
        {

            file = new FileInfo("DebugLog.log");
            // Make a connection with the mqtt broker and subscribe to several topics.
            Input.InputManager man = new Input.InputManager("145.24.222.132");

            //// --------------------------------------------- DEBUGGING -------------------------------------------
            //Input.DataParser p = new Input.DataParser();
            //FileInfo file2 = new FileInfo("test.json");
            //StreamReader reader = file2.OpenText();
            //string data = reader.ReadToEnd();

            //p.DecodeData(data, "POSITIONS");

            //Console.In.Read();
            //// --------------------------------------------- DEBUGGING -------------------------------------------

        }


        /// <summary>
        /// Write a message to the log file prepared in this "class"
        /// </summary>
        /// <param name="_sMessage"></param>
        public static void Log(string _sMessage)
        {
            StreamWriter writer = file.AppendText();
            writer.WriteLine(_sMessage);
            writer.Close();
        }
    }
}
