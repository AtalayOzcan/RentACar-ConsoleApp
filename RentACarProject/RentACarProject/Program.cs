using RentACarProject.Models;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace RentACarProject
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--- RENT A CAR SİSTEMİ ---");
                Console.WriteLine("1. Yeni Araç Ekle\n2. Araçları Listele\n3. Araç Kirala\n4. Araç Teslim (İade)\n5. Raporlar\n6. Çıkış");
                Console.Write("Cevabınız => ");
                int secim1 = Convert.ToInt32(Console.ReadLine());
                if (secim1 == 1)
                {
                    Console.Write("Otomobil(1) veya Motosiklet(2) mi?, Tuşlayınız => ");
                    int secim2 = Convert.ToInt32(Console.ReadLine());
                    if (secim2 == 1)
                    {
                        Araba araba = new Araba();

                        Console.Write("Eklemek istediğiniz arabanın markasını giriniz: ");
                        araba.Marka = Console.ReadLine();

                        Console.Write("Eklemek istediğiniz arabanın modelini giriniz: ");
                        araba.Model = Console.ReadLine();

                        Console.Write("Eklemek istediğiniz arabanın plakasını giriniz: ");
                        araba.Plaka = Console.ReadLine().Trim().ToUpper();

                        Console.Write("Eklemek istediğiniz arabanın durumunu giriniz: ");
                        araba.Durum = Console.ReadLine();

                        Console.Write("Eklemek istediğiniz arabanın vites tipini giriniz: ");
                        araba.VitesTipi = Console.ReadLine();

                        Console.Write("Eklemek istediğiniz arabanın günlük ücretini giriniz: ");
                        araba.GunlukUcret = Convert.ToDouble(Console.ReadLine());
                        kiralamalar.Add(araba);
                        Console.WriteLine($"Arabayı başarıyla eklediniz.");
                    }
                    else if(secim2 == 2)
                    {
                        Motosiklet motosiklet = new Motosiklet();

                        Console.Write("Eklemek istediğiniz motosikletin markasını giriniz: ");
                        motosiklet.Marka = Console.ReadLine();

                        Console.Write("Eklemek istediğiniz motosikletin modelini giriniz: ");
                        motosiklet.Model = Console.ReadLine();

                        Console.Write("Eklemek istediğiniz motosikletin plakasını giriniz: ");
                        motosiklet.Plaka = Console.ReadLine().Trim().ToUpper();

                        Console.Write("Eklemek istediğiniz motosikletin durumunu giriniz: ");
                        motosiklet.Durum = Console.ReadLine();

                        Console.Write("Eklemek istediğiniz motosikletin motor hacmini giriniz: ");
                        motosiklet.MotorHacmi = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Eklemek istediğiniz motosikletin günlük ücretini giriniz: ");
                        motosiklet.GunlukUcret = Convert.ToDouble(Console.ReadLine());
                        kiralamalar.Add(motosiklet);
                        Console.WriteLine($"Arabayı başarıyla eklediniz.");
                        
                    }
                    else
                    {
                        Console.WriteLine("Sadece iki seçenek vardır {1} ve {2} Lütfen başka tuşlama yapmayınız.");
                        continue;
                    }
                }
                if(secim1 == 2)
                {
                    if(kiralamalar.Count == 0) { Console.WriteLine("Galeride hiç araç yok !"); }
                    else
                    {
                        foreach (var x in kiralamalar) 
                        {
                            x.BilgiYazdir();
                        }
                    }
                }
                if( secim1 == 3)
                {
                    Console.Write("Kiralamak istediğiniz aracın plakasını giriniz: ");
                    string secilenArac= Console.ReadLine().Trim().ToUpper();

                    var varMi = kiralamalar.FirstOrDefault(x => x.Plaka == secilenArac);
                    if (varMi == null) { Console.WriteLine($"{secilenArac}'lu araç sistemimizde yok."); continue; }
                    else
                    {
                        if(varMi.Durum == "Müsait")
                        {
                            varMi.Durum = "Kirada";
                        }
                        else
                        {
                            Console.WriteLine("Bu araç zaten kirada.");
                        }
                    }
                }
                if (secim1 == 4)
                {

                    Console.Write("İade edilecek aracın plakasını giriniz: ");
                    string iadeArac = Console.ReadLine().Trim().ToUpper();

                    var varMi = kiralamalar.FirstOrDefault(x => x.Plaka == iadeArac);
                    if (varMi == null) { Console.WriteLine($"{iadeArac}'lu araç sistemimizde yok."); continue; }
                    else if(varMi.Durum == "Müsait") { Console.WriteLine("Araç halihazırda kiralanmamıştır. Lütfen kiraladığınız aracı iade ediniz."); continue; }
                    else
                    {
                        Console.Write("Kaç gün kiralama yaptınız: ");
                        int kiraSayac = Convert.ToInt32(Console.ReadLine());

                        double toplamDeger = kiraSayac * varMi.GunlukUcret;
                        varMi.Durum = "Müsait";

                        Console.WriteLine($"{iadeArac} plakalı araç toplam {kiraSayac} gün kadar kiralanmıştır. Toplam ücret = {toplamDeger}");
                    }
                }
                if(secim1 == 5)
                {
                    Console.WriteLine("--- RAPORLAR ---");
                    var musaitSayisi = kiralamalar
                                          .Where(x => x.Durum == "Müsait");
                    double toplamGelir = kiralamalar
                                         .Where(x => x.Durum == "Kirada")
                                         .Sum(x => x.GunlukUcret);
                    var fiyatSiralamasi = kiralamalar
                                          .OrderByDescending(x => x.GunlukUcret);

                    if (musaitSayisi.Count() > 0) Console.WriteLine($"Müsait Araç Sayısı: {musaitSayisi.Count()}");
                    else Console.WriteLine($"Şu anda müsait araç yoktur.");

                    if (toplamGelir > 0) Console.WriteLine($"Kiradaki Araçlardan Beklenen Gelir: {toplamGelir}");
                    else Console.WriteLine("Şu an kirada araç yoktur.");

                    foreach ( var x in fiyatSiralamasi )
                    {
                        Console.WriteLine($"{x.Marka} {x.Model} - {x.GunlukUcret} TL");
                    }
                }
            }
            
        }

        public static List<Arac> kiralamalar = new List<Arac>();
    }
}
