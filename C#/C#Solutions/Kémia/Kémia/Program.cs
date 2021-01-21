
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Kémia
{
    class Kemia
    {
        public string Ev;
        public string Elem;
        public string Vegyjel;
        public int Rendszam;
        public string Felfedező;
    }

    class Program
    {
        static List<Kemia> KemiaList = new List<Kemia>();
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("felfedezesek.csv", Encoding.Default);
            string Fejlec = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] sorelemek = sor.Split(";");
                Kemia k = new Kemia();
                k.Ev = sorelemek[0];
                k.Elem = sorelemek[1];
                k.Vegyjel = sorelemek[2];
                k.Rendszam = Convert.ToInt32(sorelemek[3]);
                k.Felfedező = sorelemek[4];
                KemiaList.Add(k);
            }
            sr.Close();

            //3. feladat
            Console.WriteLine("3. feladat: Eelemek száma: " + KemiaList.Count);

            //4. feladat
            int db = 0;
            for (int i = 0; i < KemiaList.Count; i++)
            {
                if (KemiaList[i].Ev == "Ókor")
                {
                    db++;
                }

            }
            Console.WriteLine("4. feladat: Felfedezések száma az ókorban: " + db);


            //5. feladat
            // addig kell bekérnie amíg nem egy vagy ketjegyü angol abc és mindegy hogy nagy vagy kisbetű
            // meg kell nézni van e ilyen vegyjel, meg kell egyeznie a listaban szereplő valamelyik vegyjellel
            bool jovegyjel = false;
            int bekertID = 0;
            while (!jovegyjel)
            {
            Console.WriteLine("5. feladat : Kérem adjon meg egy vegyjelet: ");
            string bekertvegyjel = Console.ReadLine(); 
                for (int i = 0; i < KemiaList.Count; i++)
                {
                    if (KemiaList[i].Vegyjel.ToLower() == bekertvegyjel.ToLower())
                    {
                        jovegyjel = true;
                        bekertID = i;
                    }
                  
                }
                if (jovegyjel == false)
                { 
                Console.WriteLine("Nincs ilyen elem az adatforrásban");
                }
            }
            //6. feladat
            Console.WriteLine("6. feladat: Keresés");
            Console.WriteLine("Az elem vegyjele: " + KemiaList[bekertID].Vegyjel);
            Console.WriteLine("Az elem Neve: " + KemiaList[bekertID].Elem);
            Console.WriteLine("Rendszáma: " + KemiaList[bekertID].Rendszam);
            Console.WriteLine("Felfedezés éve: " + KemiaList[bekertID].Ev);
            Console.WriteLine("Felfedező: " + KemiaList[bekertID].Felfedező);

            //7.feladat
            int különbség = 0;
            int max = 0;
            //miert kell kivonni -1et?
            for (int i = 0; i < KemiaList.Count-1; i++)
            {
                if (KemiaList[i].Ev != "Ókor")
                { 
                különbség = Convert.ToInt32(KemiaList[i+1].Ev) - Convert.ToInt32(KemiaList[i].Ev);
                }
                if (max < különbség)
                {
                    max = különbség;
                }
            }
            Console.WriteLine("7. feladat: " + max + " év volt a leghosszabb két elem felfedezése között.");

            // 8. feladat
            Console.WriteLine("8.feladat: Statisztika");
            List<string> statisztika = new List<string>();
            for (int i = 0; i < KemiaList.Count; i++)
            {
                    if (!statisztika.Contains(KemiaList[i].Ev) && KemiaList[i].Ev != "Ókor")
                    {
                        statisztika.Add(KemiaList[i].Ev);
                    }             
            }

            for (int i = 0; i < statisztika.Count; i++)
            {
                int dbev = 0;
                for (int j = 0; j < KemiaList.Count; j++)
                {
                    if (statisztika[i] == KemiaList[j].Ev)
                    {
                        dbev++;
                    }

                }
                if (dbev> 3)
                { 
                Console.WriteLine(statisztika[i] + ": " + dbev + "db");
                }
            }
        }
    }
}
