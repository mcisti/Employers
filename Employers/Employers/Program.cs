using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employers
{
    public class tulajdonsagok
    {
        public int azonosito { get; set; }
        public string nev { get; set; }
        public int kor { get; set; }
        public int kereset { get; set; }


        public tulajdonsagok(string sor)
        {
            string[] darabok = sor.Split(',');
            this.azonosito = Convert.ToInt32(darabok[0]);
            this.nev = darabok[1];
            this.kor = Convert.ToInt32(darabok[2]);
            this.kereset = Convert.ToInt32(darabok[3]);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<tulajdonsagok> tulajdonsag = new List<tulajdonsagok>();
            StreamReader sr = new StreamReader("tulajdonsagok_100sor.txt");

            Console.Write("3. feladat" + '\n');
            Console.WriteLine("Az összes alkalmazott neve: ");
            foreach (var item in tulajdonsag)
            {
                Console.WriteLine(item.nev);
            }

            Console.Write("4. feladat" + '\n');

            var maxKereset = tulajdonsag.Max(d => d.kereset);
            var legjobbanKeresok = tulajdonsag.Where(d => d.kereset == maxKereset);

            foreach (var item in tulajdonsag)
            {
                Console.WriteLine(item.azonosito + item.nev);
            }

            Console.Write("5. feladat" + '\n');
            var nyugdijhozKozeli = tulajdonsag.Where(d => 65 - d.kor <= 10);

            foreach (var item in tulajdonsag)
            {
                Console.WriteLine(item.nev + item.kor);
            }
            Console.Write("6. feladat" + '\n');
            var feletteKereset = tulajdonsag.Count(d => d.kereset > 50000);
            Console.WriteLine(feletteKereset);
        }
    }
}