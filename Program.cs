using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HammingMasik
{
    class Program
    {
        static int HammingErtek(string szo1, string szo2)
        {
            int db = 0;

            for (int i = 0; i < szo1.Length; i++)
			{
                if (!szo1[i].Equals(szo2[i]))
	            {
                    db++;
	            }
			}
            return db;
        }

        static List<string> HammingLista(string szo, List<string> lista)
        { 

            List<string> jo = new List<string>();
            foreach (var l in lista)
	        {
                if (HammingErtek(szo, l) <= 3)
	            {
                    jo.Add(l);
	            }
	        }
            return jo;
        }

        static void Main(string[] args)
        {
            StreamReader be = new StreamReader("adat.txt");
            string szo = "";
            List<string> lista = new List<string>();

            while (!be.EndOfStream)
            {
                szo = be.ReadLine();
                string[] tmp = be.ReadLine().Split(';');

                lista.Clear();

                foreach (var t in tmp)
                {
                    lista.Add(t);
                }

                Console.WriteLine($"szó: {szo}");
                Console.Write("lista: ");
                foreach (var l in lista)
                {
                    Console.Write($"{l}, ");
                }

                HammingLista(szo, lista);


                Console.WriteLine();
            }

            be.Close();


            Console.ReadKey();
            
        }
    }
}
