using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    public class Cv
    {
        public string Speciality { get; set; }
        public string School { get; set; }
        public double UniversityAdmissionScore { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Companies { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Languages { get; set; }
        public bool hasHonorsDiploma { get; set; }
        public string GitLink { get; set; }
        public string LinkedIn { get; set; }
        public override string ToString()
        {
            return $"Speciality : {Speciality}\nSchool : {School}\nUniversityAdmissionScore : {UniversityAdmissionScore}\nSkills : {Skills}\nCompanies : {Companies}\nBeginDate : {BeginDate}\nEndDate : {EndDate}\nLanguages : {Languages}\nHas Honor Diploma : {hasHonorsDiploma}\nGitLink : {GitLink}\nLinkedIn : {LinkedIn}";
        }
        public void Show()
        {
            Console.WriteLine($"\t\t\t\tSpeciality                 ->       {Speciality}");
            Console.WriteLine($"\t\t\t\tSchool                     ->       {School}");
            Console.WriteLine($"\t\t\t\tUniversityAdmissionScore   ->       {UniversityAdmissionScore}");
            Console.Write("\t\t\t\tSkills                     ->       ");
            for (int i = 0; i < Skills.Count; i++)
            {
                Console.Write(Skills[i]);
            }
            Console.WriteLine();
            Console.Write("\t\t\t\tCompanies                  ->       ");
            for (int i = 0; i < Companies.Count; i++)
            {
                Console.Write(Companies[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\tBeginDate                  ->       {BeginDate}");
            Console.WriteLine($"\t\t\t\tEndDate                    ->       {EndDate}");
            Console.Write("\t\t\t\tLanguages                  ->       ");
            for (int i = 0; i < Languages.Count; i++)
            {
                Console.Write(Languages[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\tHas Honor Diploma          ->       {hasHonorsDiploma}");
            Console.WriteLine($"\t\t\t\tGitLink                    ->       {GitLink}");
            Console.WriteLine($"\t\t\t\tLinkedIn                   ->       {LinkedIn}");
        }
    }
}
