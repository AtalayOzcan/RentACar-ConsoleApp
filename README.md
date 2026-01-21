# Rent-A-Car Console Application

C# öğrenim sürecimde; Nesne Yönelimli Programlama (OOP) mantığını oturtmak, özellikle referans tiplerin (Reference Types) çalışma yapısını kavramak ve LINQ ile veri manipülasyonu pratikleri yapmak amacıyla geliştirdiğim konsol tabanlı araç kiralama projesi.

## Projenin Amacı ve Kazanımlarım

Bu projeyi geliştirirken temel hedefim, sadece çalışan bir kod yazmak değil, sürdürülebilir ve mimari kurallara uyan bir yapı kurmaktı. Özellikle şu konular üzerinde derinleştim:

* **OOP Mimarisi:** `Arac` isminde soyut (abstract) bir sınıf oluşturarak `Otomobil` ve `Motosiklet` sınıflarını bu yapıdan türettim. Bu sayede kod tekrarını önledim.
* **Hafıza Yönetimi (Stack & Heap):** Projedeki kiralama işlemlerinde nesneleri kopyalamak yerine, referansları üzerinden (Heap bölgesindeki adresi yöneterek) durum güncellemelerini gerçekleştirdim.
* **Polimorfizm:** Araçların bilgilerini yazdırma aşamasında `override` mekanizmasını kullanarak, her sınıfın kendine özgü veriyi işlemesini sağladım.
* **Veri Güvenliği (Encapsulation):** Araç fiyatları gibi kritik verilerin hatalı girilmesini (örn: negatif değer) property'ler içerisindeki kontrollerle engelledim.

## Teknik Özellikler

* **Dil:** C# (.NET)
* **Veri Yapısı:** Generic `List<Arac>` koleksiyonu.
* **Sorgulama:** `foreach` döngüleri yerine, raporlama ekranlarında performans ve okunabilirlik açısından **LINQ** (Where, Sum, OrderByDescending) metotlarını kullandım.

## Uygulama Özellikleri

1.  **Araç Havuzu Yönetimi:** Sisteme dinamik olarak farklı tiplerde (Otomobil/Motosiklet) araç eklenebiliyor.
2.  **Kiralama Simülasyonu:** Müsait araçlar filtrelenip kiralanabiliyor. Bu işlem sırasında nesnenin referansı üzerinden anlık durum değişikliği yapılıyor.
3.  **İade ve Ciro Hesabı:** Kiralanan araç teslim alınırken gün sayısı bazında toplam tutar hesaplanıyor ve araç tekrar havuza dahil ediliyor.
4.  **Raporlama:**
    * Müsait ve kirada olan araçların analizi.
    * Beklenen toplam ciro hesaplaması.
    * Araçların fiyat bazlı sıralaması.

## Kurulum

Projeyi bilgisayarınıza indirdikten sonra `RentACarProject.sln` dosyasını Visual Studio ile açarak derleyip çalıştırabilirsiniz.
