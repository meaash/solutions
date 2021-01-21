using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace kosar2004
{
    class Eredmenyek
    {
        public string Hazai;
        public string Idegen;
        public string Hazai_pont;
        public string Idegen_pont;
        public string Helyszin;
        public string Idopont;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            List<Eredmenyek> EredmenyekList = new List<Eredmenyek>();
            StreamReader sr = new StreamReader("eredmenyek.csv", Encoding.Default);
            string sor = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                string[] sorelemek = sor.Split(";");
                Eredmenyek er = new Eredmenyek();
                er.Hazai = sorelemek[0];
                er.Idegen = sorelemek[1];
                er.Hazai_pont = sorelemek[2];
                er.Idegen_pont = sorelemek[3];
                er.Helyszin = sorelemek[4];
                er.Idopont = sorelemek[5];
                EredmenyekList.Add(er);

            }
            sr.Close();
            //3. feladat 
            int realidegen = 0;
            int realhazai = 0;
           
            for (int i = 0; i < EredmenyekList.Count; i++)
            {
                if (EredmenyekList[i].Hazai == "Real Madrid")
                {
                    realhazai++;
                }
                if (EredmenyekList[i].Idegen == "Real Madrid")
                {
                    realidegen++;
                }     

            }
            Console.WriteLine("3.feladat: Real Madrid Hazai: " + realhazai + ", Idegen: " + realidegen);

            //4. feladat volt döntetlen mérkőzés?
            bool dontetlen = false;
            for (int i = 0; i < EredmenyekList.Count; i++)
            {
                if (EredmenyekList[i].Hazai_pont == EredmenyekList[i].Idegen_pont)
                {
                    dontetlen = true;
                }

            }
            Console.WriteLine(dontetlen ? "4. feladat: Volt döntetlen? igen" : "4. feladat: Volt döntetlen? nem");

            //5. feladat
            string barcelonename = "";
            for (int i = 0; i < EredmenyekList.Count; i++)
            {
                if (EredmenyekList[i].Hazai.Contains("Barcelona"))
                {
                    barcelonename = EredmenyekList[i].Hazai;
                }

            }
            Console.WriteLine("5. fealadat: A barcelonai csapat neve: " + barcelonename);

            //6. feladat
            Console.WriteLine("6. feladat");
            for (int i = 0; i < EredmenyekList.Count; i++)
            {
                if (EredmenyekList[i].Idopont == "2004-11-21")
                {
                    Console.WriteLine(EredmenyekList[i].Hazai + " " + EredmenyekList[i].Idegen + " (" +
                        EredmenyekList[i].Hazai_pont + ":" +EredmenyekList[i].Idegen_pont + ")");
                }

            }
            //7. feladat
            Console.WriteLine("7. feladat");
 
            List<string> helyszinek = new List<string>();

            for (int i = 0; i < EredmenyekList.Count; i++)
            {

                    if (!helyszinek.Contains(EredmenyekList[i].Helyszin))
                    {
                        helyszinek.Add(EredmenyekList[i].Helyszin);
                    }
                       
            }
            for (int i = 0; i < helyszinek.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < EredmenyekList.Count; j++)
                {
                    if (EredmenyekList[j].Helyszin == helyszinek[i])
                    {
                        count++;
                    }
                }
                if (count > 20)
                {
                    Console.WriteLine(helyszinek[i] + ": " + count);
                }
              
            }
                //Console.ReadLine();
        }
    }
   
}
