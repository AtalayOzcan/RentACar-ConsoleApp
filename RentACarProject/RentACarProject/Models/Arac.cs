using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarProject.Models
{
    public abstract class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Plaka { get; set; }
        public string Durum { get; set; }
        private double _gunlukUcret { get; set; }
        public double GunlukUcret {
            get { return _gunlukUcret; }
            set
            {
                if( value <= 0)
                {
                    Console.WriteLine("Ücret Eksi veya sıfır değer olamaz");
                }
                else
                {
                    _gunlukUcret = value;
                }
            }
        }


        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Marka = {Marka}, Model = {Model}, Plaka = {Plaka}, Günlük Ücret = {GunlukUcret}TL, Durum = {Durum}");
        }

    }
}
