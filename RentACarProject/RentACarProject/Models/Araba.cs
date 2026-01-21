using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarProject.Models
{
    public class Araba : Arac
    {
        public string VitesTipi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Arac Vites Tipi = {VitesTipi}");
        }

        

    }
}
