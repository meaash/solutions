
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fuvar
{
    class Taxi
    {
        public int Azonosito;
        public string Indulas;
        public int Idotartam;
        public double Tavolsag;
        public double Viteldij;
        public double Borravalo;
        public string Fizetes;
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Taxi> fuvarList = new List<Taxi>();
            StreamReader sr = new StreamReader("fuvar.csv", Encoding.Default);
            string sor = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                string[] sorelemek = sor.Split(';');
                Taxi t = new Taxi();
                t.Azonosito = Convert.ToInt32(sorelemek[0]);
                t.Indulas = sorelemek[1];
                t.Idotartam = Convert.ToInt32(sorelemek[2]);
                t.Tavolsag = Convert.ToDouble(sorelemek[3]);
                t.Viteldij = Convert.ToDouble(sorelemek[4]);
                t.Borravalo = Convert.ToDouble(sorelemek[5]);
                t.Fizetes = sorelemek[6];
                fuvarList.Add(t);
          
            }
            sr.Close();

            //3.feladat
            Console.WriteLine("3.feladat");
            Console.WriteLine(fuvarList.Count);

            //4.feladat
            Console.WriteLine("4.feladat");
            int db = 0;
            double osszeg = 0;
            for (int i = 0; i < fuvarList.Count; i++)
            {
                if (fuvarList[i].Azonosito == 6185)
                {
                    osszeg = osszeg + fuvarList[i].Viteldij;
                    db++;
                }
            }
            Console.WriteLine( db + " fuvar alatt: " +osszeg +"$");

            //5. feladat
            Console.WriteLine("5.feladat");
            List<string> segedList = new List<string>();
         
            for (int i = 0; i < fuvarList.Count; i++)
            {
                if (!segedList.Contains(fuvarList[i].Fizetes))
                {
                    segedList.Add(fuvarList[i].Fizetes);
                }

            }
            
            for (int i = 0; i < segedList.Count; i++)
            {
                int szamlalo = 0;

                for (int j = 0; j < fuvarList.Count; j++)
                {
                    
                    if (segedList[i] == fuvarList[j].Fizetes)
                    { 
                        szamlalo++;
                        
                    }
                   
                }
                Console.WriteLine(segedList[i] + ": " + szamlalo + " db");
            }
            //6.feladat
            Console.WriteLine("6.feladat");
            double hanykm = 0;
            for (int i = 0; i < fuvarList.Count; i++)
            {
                hanykm = hanykm + fuvarList[i].Tavolsag;
            }
            Console.WriteLine(Math.Round(hanykm*1.6, 2)+"km");

            //7.feladat
            Console.WriteLine("7. feladat");
            int max = 0;
            int taxiazonosito = 0;
            double megtetttavolsag = 0;
            double viteldij = 0;

            for (int i = 0; i < fuvarList.Count; i++)
            {
                if (max < fuvarList[i].Idotartam)
                {
                    max = fuvarList[i].Idotartam;
                    taxiazonosito = fuvarList[i].Azonosito;
                    megtetttavolsag = fuvarList[i].Tavolsag;
                    viteldij = fuvarList[i].Viteldij;
                }
               
            }
            Console.WriteLine("A leghosszabb fuvar: " + max + "másodperc");
            Console.WriteLine("Taxi azonosító: " + taxiazonosito);
            Console.WriteLine("A megtett távolság: " + Math.Round(megtetttavolsag * 1.6, 2) + "km");
            Console.WriteLine(viteldij);

            //8.feladat

            fuvarList = fuvarList.OrderBy(item => item.Indulas).ToList();
            StreamWriter sw = new StreamWriter("hibak.txt", false, Encoding.Default);
            for (int i = 0; i < fuvarList.Count; i++)
            {

                if (fuvarList[i].Idotartam > 0 && fuvarList[i].Viteldij > 0 && fuvarList[i].Tavolsag == 0)
                {
                    
                    sw.WriteLine("{0};{1};{2}{3};{4};{5};{6};", fuvarList[i].Azonosito, fuvarList[i].Indulas, fuvarList[i].Idotartam, fuvarList[i].Tavolsag, fuvarList[i].Viteldij, fuvarList[i].Borravalo, fuvarList[i].Fizetes);
                    
                }
            }
            sw.Close();

        }
    }
}
