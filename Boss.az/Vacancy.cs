using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Speciality { get; set; }
        public string[] Skills { get; set; }
        public double Experience { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public long TelephoneNumber { get; set; }
        public string[] Tags { get; set; }
        public void Show()
        {
            Console.Write($"\t\t\tCompany Name    ->    {CompanyName}");
            Console.WriteLine($"\t\t  Speciality        ->    {Speciality}");
            Console.Write($"\t\t\tSalary          ->    {Salary}");
            Console.WriteLine($"\t\t  Experience        ->    {Experience} years");
            Console.Write($"\t\t\tEmail           ->    {Email}");
            Console.WriteLine($"\t  TelephoneNumber   ->    {TelephoneNumber}");
            Console.Write($"\t\t\tSkills          ->");
            for (int i = 0; i < Skills.Length; i++)
            {
                Console.WriteLine(Skills[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
