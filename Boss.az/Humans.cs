using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    abstract class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public long TelephoneNumber { get; set; }
        public void Show()
        {
            Console.WriteLine($"\t\t\t        Name                       ->       {Name}");
            Console.WriteLine($"\t\t\t        Surname                    ->       {Surname}");
            Console.WriteLine($"\t\t\t        Username                   ->       {Username}");
            Console.WriteLine($"\t\t\t        Age                        ->       {Age}");
            Console.WriteLine($"\t\t\t        City                       ->       {City}");
            Console.WriteLine($"\t\t\t        TelephoneNumber            ->       {TelephoneNumber}");
        }
        public override string ToString()
        {
            return $"Name : {Name}\nSurname : {Surname}\nUsername : {Username}\nAge : {Age}\nCity : {City}\nTelephoneNumber : {TelephoneNumber}";
        }
    }
    class Worker : Human
    {
        public static int WorkerId { get; set; } = 1;
        public Cv WorkerCv { get; set; } = new Cv();
        public Notification Notifications { get; set; } = new Notification();
        public Worker()
        {
            Id = WorkerId++;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\n{WorkerCv.ToString()}";
        }
        public void UpdateSpeciality(string newspeciality)
        {
            if (newspeciality != null)
            {
                WorkerCv.Speciality = newspeciality;
            }
        }
        public void UpdateSchool(string newschool)
        {
            if (newschool != null)
            {
                WorkerCv.School = newschool;
            }
        }
        public void UpdateScore(double newscore)
        {
            if (newscore != null)
            {
                WorkerCv.UniversityAdmissionScore = newscore;
            }
        }
        public void UpdateSkills(List<string> newskills)
        {
            if (newskills != null)
            {
                WorkerCv.Skills = newskills;
            }
        }
        public void UpdateCompanies(List<string> newcompanies)
        {
            if (newcompanies != null)
            {
                WorkerCv.Companies = newcompanies;
            }
        }
        public void UpdateBeginDate(DateTime newbegin)
        {
            if (newbegin != null)
            {
                WorkerCv.BeginDate = newbegin;
            }
        }
        public void UpdateEndDate(DateTime newend)
        {
            if (newend != null)
            {
                WorkerCv.EndDate = newend;
            }
        }
        public void UpdateLanguages(List<string> newlang)
        {
            if (newlang != null)
            {
                WorkerCv.Languages = newlang;
            }
        }
        public void UpdateHonorDiploma(bool hashonor)
        {
            WorkerCv.hasHonorsDiploma = hashonor;
        }
        public void UpdateGitlink(string newgit)
        {
            if (newgit != null)
            {
                WorkerCv.GitLink = newgit;
            }
        }
        public void UpdateLinkedin(string newlink)
        {
            if (newlink != null)
            {
                WorkerCv.LinkedIn = newlink;
            }
        }
        public new void Show()
        {
            base.Show();
            WorkerCv.Show();
        }
    }
    class Employer : Human
    {
        public List<Vacancy> Vacancies = new List<Vacancy>();
        public List<Worker> Applicants = new List<Worker>();
        public List<Vacancy> ApplicantVacancy = new List<Vacancy>();
        public Notification Notifications { get; set; } = new Notification() { Message = "", Number = 0 };
        public Employer(Notification notifications)
        {
            Notifications = notifications;
        }
        public int EmployerId { get; set; } = 1;

        public Employer()
        {
            Id = EmployerId++;
        }
        public new void Show()
        {
            base.Show();
        }
        //public List<Vacancy> Search(string text)
        //{
        //    List<Vacancy> MyVacancies = new List<Vacancy> { };
        //    for (int i = 0; i < Vacancies.Count; i++)
        //    {
        //        for (int k = 0; k < Vacancies[i].Tags.Length; k++)
        //        {
        //            if (Vacancies[i].Tags[k].Contains(text))
        //            {
        //                MyVacancies.Add(Vacancies[i]);
        //            }
        //        }
        //    }
        //    return MyVacancies;           
        //}
        public List<Vacancy> Search(string text)
        {
            List<Vacancy> MyVacancies = new List<Vacancy> { };
            var selectedworks = from vacancy in Vacancies
                                where vacancy.Tags.Any(x => x.ToLower().Contains(text.ToLower()))
                                select vacancy;

            foreach (var item in selectedworks)
            {
                MyVacancies.Add(item);
            }
            return MyVacancies;
        }
    }
}
