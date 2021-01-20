using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace balkezesek
{
    class Balkezesek
    {
        public string Nev;
        public string Elso;
        public string Utolso;
        public double Suly;
        public int Magassag;

    }

 
    class Program
    {
        static List<Balkezesek> balkezsekList = new List<Balkezesek>();

        static void Main(string[] args)
        {
            
            //2.feladat a csv file beolvasása
            StreamReader sr = new StreamReader("balkezesek.csv", Encoding.Default);
            string sor = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine(); //folytatjuk a sorok beolvasását
                string[] SorElemek = sor.Split(';'); //spliteljük a sort
                Balkezesek b = new Balkezesek(); //példányosítom
                b.Nev = SorElemek[0];
                b.Elso = SorElemek[1];
                b.Utolso = SorElemek[2];
                b.Suly = Convert.ToDouble(SorElemek[3]);
                b.Magassag = Convert.ToInt32(SorElemek[4]);
                balkezsekList.Add(b);

            }
            sr.Close();

            //3.feladat
            Console.WriteLine("3.feladat");
            Console.WriteLine(balkezsekList.Count);

            //4.feladat
            Console.WriteLine("4.feladat");
            
            for (int i = 0; i < balkezsekList.Count; i++)
            {
                double testmagasság = 0;
                if (balkezsekList[i].Utolso.Contains("1999-10"))
                {
                    testmagasság = balkezsekList[i].Magassag * 2.54;
                    Console.WriteLine(balkezsekList[i].Nev + ": " + Math.Round(testmagasság, 1) +"cm");
                }
            }

            //5.feladat
            Console.WriteLine("5.feladat");

            Console.Write("Kérem adjon meg egy évszámot 1900 és 1999 között: ");
            bool szamell = false;
            int evszam = Convert.ToInt32(Console.ReadLine());
            while (!szamell)
            {
                
                if (evszam <= 1990 || evszam >= 1999)
                {
                    szamell = false;
                    Console.Write("Hibás adat kérek egy 1900 és 1999 közötti évszámot: ");
                    evszam = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    szamell = true;
                }
            }


            //6.feladat
            Console.WriteLine("6.feladat");
          
            double osszeg = 0;
            int db = 0;
            for (int i = 0; i < balkezsekList.Count; i++)
            {
                int első = Convert.ToInt32(balkezsekList[i].Elso.Substring(0,4));
                int utolsó = Convert.ToInt32(balkezsekList[i].Utolso.Substring(0,4));
                if (evszam >= első && evszam <= utolsó)
                {
                    db++;
                    //segedlista.Add(balkezsekList[i].Suly);
                    osszeg = osszeg + balkezsekList[i].Suly;
                    
                }


            }
            Console.WriteLine(Math.Round(osszeg/db, 2));




        }
    }
}
