using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace radio.txt
{
    class Expedicio
    {
        public int Radioamator;
        public int Nap;
        public string Uzenet;
    }
    class Program
    {
        static void Main(string[] args)
        {

            //1.feladat
            List<Expedicio> VeetelList = new List<Expedicio>();
            StreamReader sr = new StreamReader("veetel.txt", Encoding.Default);
            while (!sr.EndOfStream)
            {
                string sor1 = sr.ReadLine();
                string[] sor1elem = sor1.Split(" ");
                string sor2 = sr.ReadLine();
                Expedicio exp = new Expedicio();
                exp.Nap = Convert.ToInt32(sor1elem[0]);
                exp.Radioamator = Convert.ToInt32(sor1elem[1]);
                exp.Uzenet = sor2;
                VeetelList.Add(exp);
            }
            sr.Close();

            //2.feladat
            Console.WriteLine("2.feladat: ");
            Console.WriteLine("Az első üzenet rögzítője: " +VeetelList[0].Radioamator);
            Console.WriteLine("Az utolsó üzenet rögzítője: " + VeetelList[VeetelList.Count-1].Radioamator);

            //3.feladat
            Console.WriteLine("3.feladat: ");
            for (int i = 0; i < VeetelList.Count; i++)
            {
                if (VeetelList[i].Uzenet.Contains("farkas"))
                {
                    Console.WriteLine(VeetelList[i].Nap + ". nap: " + VeetelList[i].Radioamator + " rádióamatőr");
                }
            }

            //4.feladat
            Console.WriteLine("4.feladat: ");
            for (int i = 1; i <= 11; i++)
            {
                int count = 0;
                for (int j = 0; j < VeetelList.Count; j++)
                {
                    if (VeetelList[j].Nap == i)
                    {
                        count++;
                    }
                }
                Console.WriteLine(i + ". nap: " + count + " rádióamatőr");
            }

            //5.feladat
            Console.WriteLine("5.feladat: ");

            StreamWriter sw = new StreamWriter("adaas.txt", false, Encoding.Default);
            for (int i = 1; i <= 11; i++)
            {
                List<string> segedList = new List<string>();
                for (int j = 0; j < VeetelList.Count; j++)
                {
                    if (VeetelList[j].Nap == i)
                    {
                        segedList.Add(VeetelList[j].Uzenet);
                    }
                }
                // string uzenetsor = segedList[0];
                var helyreallitott = segedList[0].ToCharArray();
                for (int k = 0; k < segedList.Count; k++)
                {
                    for (int l = 0; l < 90; l++)
                    {
                        if (helyreallitott[l] == '#')
                        {
                            helyreallitott[l] = segedList[k][l];
                        }
                    }
                }
                sw.WriteLine(helyreallitott);
            }
            sw.Close();
            Console.WriteLine("adaas.txt elkészült");

            //6.feladat
            Console.WriteLine("6.feladat: ");

            //7.feladat
            Console.WriteLine("7.feladat: ");
            Console.Write("Adja meg a nap sorszámát! ");
            int napsorszam = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg a rádióamatőr sorszámát! ");
            int radioamatorszam = Convert.ToInt32(Console.ReadLine());

            int egyedekszama = 0;
            bool vanfeljegyzes = false;
            for (int i = 0; i < VeetelList.Count; i++)
            {

                if (VeetelList[i].Nap == napsorszam && VeetelList[i].Radioamator == radioamatorszam)
                {

                    string[] sorelem = VeetelList[i].Uzenet.Split(" ")[0].Split("/");
                    if (sorelem.Length == 2 && szame(sorelem[0]) && szame(sorelem[1]))
                    {
                        egyedekszama = Convert.ToInt32(sorelem[0]) + Convert.ToInt32(sorelem[1]);
                        vanfeljegyzes = true;
                    }
                    else
                    {
                        Console.WriteLine("Nincs információ!");
                    }
                }

            }

            Console.WriteLine(vanfeljegyzes? "A megfigyelt egyedek száma: " + egyedekszama : "Nincs ilyen feljegyzés!");
            //rendes kiírás
            /* if (vanfeljegyzes == false)
            {
                Console.WriteLine("Nincs ilyen feljegyzés!");
            }
            else
            {
                Console.WriteLine("A megfigyelt egyedek száma: " + egyedekszama);
            }      
            Console.ReadLine();*/
       
        }
        static bool szame(string szo)
        {
            bool valasz = true;
            for (int i = 1; i < szo.Length; i++)
            {
                if (szo[i] < '0' || szo[i] > '9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }
    }
}
