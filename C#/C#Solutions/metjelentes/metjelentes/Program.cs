using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace metjelentes
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. feladat Beolvas
            List<MetAdatok> metList = new List<MetAdatok>();
            StreamReader sr = new StreamReader("tavirathu13.txt", Encoding.Default);

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] sorelemek = sor.Split(" ");
                MetAdatok m = new MetAdatok();
                m.Telepules = sorelemek[0];
                m.Meres = sorelemek[1];
                m.Szel = sorelemek[2];
                m.Homerseklet = Convert.ToInt32(sorelemek[3]);
                metList.Add(m);
            }
            sr.Close();

            //2.feladat
            Console.WriteLine("2. feladat");
            Console.Write("Adja meg egy település kódját! Település: ");
            string kód = Console.ReadLine();
            string utolso = "";
            for (int i = 0; i < metList.Count; i++)
            {
                if (kód.ToUpper() == metList[i].Telepules)
                {
                    utolso = metList[i].Meres;
                }
            }

            Console.WriteLine($"Az utolsó mérési adat a településről {utolso.Insert(2, ":")} érkezett");

            //3.feladat
            Console.WriteLine("3.feladat");
            int min = metList[0].Homerseklet;
            int max = metList[0].Homerseklet;
            int minindex = 0;
            int maxindex = 0;
            for (int i = 0; i < metList.Count; i++)
            {
                if (metList[i].Homerseklet < min)
                {
                    min = metList[i].Homerseklet;
                    minindex = i;
                }
                if (metList[i].Homerseklet > max)
                {
                    max = metList[i].Homerseklet;
                    maxindex = i;
                }
            }
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {metList[minindex].Telepules} {metList[minindex].Meres.Insert(2, ":")} {metList[minindex].Homerseklet} fok");
            Console.WriteLine($"A legmagasabb hőmérséklet: {metList[maxindex].Telepules} {metList[maxindex].Meres.Insert(2, ":")} {metList[maxindex].Homerseklet} fok");
            //4.feladat
            Console.WriteLine("4.feladat");
            var szelcsend = metList.Where(item => item.Szel == "00000").ToList();
            foreach (var item in szelcsend)
            {
                Console.WriteLine(item.Telepules + " " + item.Meres.Insert(2, ":"));
            }

            //5.feladat
            Console.WriteLine("5. feladat");
            List<string> segedlist = new List<string>();
            for (int i = 0; i < metList.Count; i++)
            {
                if (!segedlist.Contains(metList[i].Telepules))
                {
                    segedlist.Add(metList[i].Telepules);
                }

            }

            for (int i = 0; i < segedlist.Count; i++)
            {
                double atlag = 0;
                double kozepatlag = 0;
                int oszto = 0;
                bool voltmeres1 = false;
                bool voltmeres2 = false;
                bool voltmeres3 = false;
                bool voltmeres4 = false;

                int maxh = metList[0].Homerseklet;
                int minh = metList[0].Homerseklet;
                int ingadozas = 0;


                for (int j = 0; j < metList.Count; j++)
                {
                    if(segedlist[i] == metList[j].Telepules)
                    { 
                        if(metList[j].Homerseklet < minh)
                        {
                            minh = metList[j].Homerseklet;
                        }

                        if (metList[j].Homerseklet > maxh)
                        {
                            maxh = metList[j].Homerseklet;
                        }
                        ingadozas = maxh -minh;
                    }

                    if (segedlist[i] == metList[j].Telepules && metList[j].Meres.Substring(0, 2) == "01")
                    {
                            atlag += metList[j].Homerseklet;
                            oszto++;
                            voltmeres1 = true;
                    }
                    else if (segedlist[i] == metList[j].Telepules && metList[j].Meres.Substring(0, 2) == "07")
                    {
                        atlag += metList[j].Homerseklet;
                        oszto++;
                        voltmeres2 = true;

                    }
                    else if (segedlist[i] == metList[j].Telepules && metList[j].Meres.Substring(0, 2)=="13")
                    {
                        atlag += metList[j].Homerseklet;
                        oszto++;
                        voltmeres3 = true;
                    }
                    else if (segedlist[i] == metList[j].Telepules && metList[j].Meres.Substring(0, 2)=="19")
                    {
                        atlag += metList[j].Homerseklet;
                        voltmeres4 = true;
                        oszto++;
                    }
               
                    kozepatlag = atlag / oszto;
                   
                }
                if (voltmeres1 && voltmeres2 && voltmeres3 && voltmeres4) 
                {

                Console.WriteLine($"{segedlist[i]} Középhőmérséklet : {Math.Round(kozepatlag)}; Hőmérséklet-ingadozás: {ingadozas}");
                }
                else
                {
                    Console.WriteLine($"{segedlist[i]} :NA; Hőmérséklet-ingadozás: {ingadozas}");
                }
            }

            //6.feladat
            Console.WriteLine("6.feladat");
           
            foreach (string t in segedlist)
            {              
                StreamWriter sw = new StreamWriter($"{t}.txt", false, Encoding.Default);
                sw.WriteLine(t);
                
                foreach  (MetAdatok m in metList)
                {            
                    if (t == m.Telepules)
                    {
                        int szelerösseg = Convert.ToInt32(m.Szel.Substring(3, 1)) + Convert.ToInt32(m.Szel.Substring(4, 1));
                        sw.WriteLine($"{m.Meres} {new String('#', szelerösseg)} ");
                    }
                }
                sw.Close();
            }
            Console.WriteLine("A fájlok elkészültek!");

        }
        public class MetAdatok
        {
            public string Telepules;
            public string Meres;
            public string Szel;
            public int Homerseklet;
        }
    }
}
