using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarProject.Models
{
    public class Motosiklet : Arac
    {
        public int MotorHacmi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Arac Motor Hacmi = {MotorHacmi}");
        }
    }
}
