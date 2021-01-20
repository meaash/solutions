using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Morze
{

    class Program
    {
        public static List<MorzeABC> abc = new List<MorzeABC>();

        static void Main(string[] args)
        {


            //2.feladat
            StreamReader sr = new StreamReader("morzeabc.txt", Encoding.Default);
            string fejlec = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] sorelemek = sor.Split("\t");
                MorzeABC m = new MorzeABC();
                m.Betu = sorelemek[0];
                m.Morzejel = sorelemek[1];
                abc.Add(m);

            }
            sr.Close();

            //3.feladat
            Console.WriteLine($"3. feladat:\nA morze abc {abc.Count}db karakter kódját tartalmazza ");

            //4.feladat
            Console.WriteLine("Kérek egy karaktert!");
            string bekert = Console.ReadLine().ToUpper();
            // bool jokarakter = false;
            bool exists = abc.Any(item => item.Betu == bekert);
            if (exists)
            {
                for (int i = 0; i < abc.Count; i++)
                {
                    if (bekert.ToUpper() == abc[i].Betu)
                    {
                        Console.WriteLine($"A {bekert} karakter morzekódja: {abc[i].Morzejel}");
                        //jokarakter = true;
                    }

                }
            }
            else
            {
                Console.WriteLine("Nem található a kódtáblában ilyen karakter!");
            }

            List<Morze> szoveg = new List<Morze>();
            //5.feladat
            StreamReader sr2 = new StreamReader("morze.txt", Encoding.Default);
            while (!sr2.EndOfStream)
            {
                string sor = sr2.ReadLine();
                string[] sorelemek = sor.Split(";");
                Morze mo = new Morze();
                mo.Szerzo = sorelemek[0];
                mo.Idezet = sorelemek[1];
                szoveg.Add(mo);

            }
            sr.Close();



            //6.feladat
            string forditott = Morze2Abc(szoveg[0].Szerzo);
            Console.WriteLine(forditott);

            //7. feladat
            int max = 0;
            string leghosszabb = "";
            for (int i = 0; i < szoveg.Count; i++)
            {

                if (Morze2Abc(szoveg[i].Idezet).Length > max)
                {
                    leghosszabb = $"A leghosszabb idézet szerzője: {Morze2Abc(szoveg[i].Szerzo)} és az idézet {Morze2Abc(szoveg[i].Idezet)}";

                }
            }
            Console.WriteLine(leghosszabb);
            //8.feladat
            for (int i = 0; i < szoveg.Count; i++)
            {
                if (szoveg[i].Szerzo == szoveg[0].Szerzo)
                {
                    Console.WriteLine("- " + Morze2Abc(szoveg[i].Idezet));
                }

            }
            var list = szoveg.Where(item => item.Szerzo == szoveg[0].Szerzo).ToList();
            foreach (var item in list)
            {
                Console.WriteLine("- " + Morze2Abc(item.Idezet));
            }


            //10.feladat
            StreamWriter sw = new StreamWriter("forditas.txt", false, Encoding.Default);
            foreach (var item in szoveg)
            {
                sw.WriteLine($"{Morze2Abc(item.Szerzo)}: {Morze2Abc(item.Idezet)}");
            }
            sw.Close();

        }

        public static string Morze2Abc(string morzeszoveg)
        {
            string abcszoveg = "";

            string[] szavak = morzeszoveg.Split("       ");
            foreach (var szo in szavak)
            {
                string[] betuk = szo.Split("   ");
                foreach (var item in betuk)
                {
                    for (int k = 0; k < abc.Count; k++)
                    {
                        if (item == abc[k].Morzejel)
                        {
                            abcszoveg += abc[k].Betu;
                        }
                    }

                }
                abcszoveg += " ";
            }

            return abcszoveg;
        }

    }

    public class MorzeABC
    {
        public string Betu;
        public string Morzejel;
    }
    public class Morze
    {
        public string Szerzo;
        public string Idezet;
    }
}
