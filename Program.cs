using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kelimeBolme
{
    class Program
    {
        static void Main(string[] args)
        {

            string cumle = "Erişmekistedikleribirhedefiolmayanlarçalışmaktanzevkalmazlar";
            string  kcumle=cumle.ToLower();
            string[] kelimeler = {"Ak","Al", "Alı","Alış","Alışma","Alışmak","Alışmakta","Alışmaktan","Alma","Almaz","Almazlar","An","Anla","Anlar",
                "Ayan","Az","Azla", "Azlar","Bir","Çal","Çalı","Çalış","Çalışma","Çalışmak","Çalışmakta","Çalışmaktan","De","Def","Dik","Dikler",
                "Dikleri","Ede","Ek","Eki","Er","Eri","Eriş","Erişme","Erişmek","Ev","Fi","Hedef","Hedefi","İs","İste","İstedi","İstedik","İstedikleri",
                "İş","Kal","Kalma","Kalmaz","Kalmazlar","Kist","Kiste","Maya","Ol","Olma","Olmaya","Olmayan","Olmayanla","Olmayanlar","Ta","Tan",
                "Ya","Yan","Zevk"};
            string[] yKelimeler = new string[kelimeler.Length];
            for (int i = 0; i < yKelimeler.Length; i++)
            {
                yKelimeler[i] = kelimeler[i].ToLower();
            }
            List<string> kelimelerListesi = new List<string>(yKelimeler);
            CumleBolme cumlebol = new CumleBolme();
            cumlebol.KelimeleriAyir(kcumle, kelimelerListesi);
            cumlebol.Yazdir(kcumle, kelimelerListesi);
            Console.ReadLine();
        }
    }
    class CumleBolme
    {
        public List<string> KelimeleriAyir(string s, List<string> ciktiListe)
        {
          
            List<string> liste = new List<string>();
            if (ciktiListe.Contains(s))
                liste.Add(s);
            for (int i = 0; i < s.Length; i++)
            {
                string tut = s.Substring(0, i);
                if (ciktiListe.Contains(tut))
                {
                    List<string> listeEk = KelimeleriAyir(s.Substring(i), ciktiListe);
                    foreach (string ekle in listeEk)
                    {
                        liste.Add(tut+" "+ekle);
                    }
                }
            }
            return liste;
        }
        public void Yazdir(string cumle,List<string> kelimeListesi)
        {
            var x = KelimeleriAyir(cumle, kelimeListesi);
            foreach (string cikti in x)
            {
                Console.WriteLine(cikti);
            }
        }
    }
}
