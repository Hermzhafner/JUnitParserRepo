using System;
using System.IO;
using System.Threading;


namespace ParseRXJUnitReport
{
    class Program
    {
        public static bool registered = false;
        static void Main(string[] args)
        {
            string[] reportFileDirectory = Directory.GetFiles(Directory.GetCurrentDirectory());
            string name = "";



            for (int i = 0; i < reportFileDirectory.Length; i++)
            {
                Console.WriteLine("any key " + reportFileDirectory[i].ToString());
                if (reportFileDirectory[i].Contains(".rxlog.junit.xml"))
                {
                    name = reportFileDirectory[i].ToString();
                    Console.WriteLine("found!");
                }
            }


            
            if (!File.Exists(name))
            {
                        System.Environment.Exit(1);
            }

            int j = 0;

            while (File.ReadAllText(name).Length == 0 && j < 10)
            {
                        Thread.Sleep(5000);
                        j++;
            }

            byte[] text = File.ReadAllBytes(name);
            byte[] b = new byte[text.Length - 3];

            for (int i = 0; i < b.Length; i++)
            {
                        b[i] = text[i + 3];
            }

            File.WriteAllBytes(name.Replace(".rxlog.junit.xml", ".rxlog.junit_fixed.xml"), b);

            System.Environment.Exit(0);

        }
    }
}
