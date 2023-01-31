using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.Remoting.Messaging;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;

namespace Boss.az
{
    class BossAz
    {
        public List<Human> Humans { get; set; }
        public List<Worker> Workers = new List<Worker>();
        public List<Employer> Employers = new List<Employer>();
        public Worker GetWorkerByUsername(string username)
        {
            for (int i = 0; i < Workers.Count; i++)
            {
                if (username == Workers[i].Username)
                {
                    return Workers[i];
                }
            }
            return null;
        }
        public Employer GetEmployerByUsername(string username)
        {
            for (int i = 0; i < Employers.Count; i++)
            {
                if (username == Employers[i].Username)
                {
                    return Employers[i];
                }
            }
            return null;
        }
        public void WriteWorker()
        {
            using (StreamWriter sw = new StreamWriter("workers.json"))
            {
                var item = JsonConvert.SerializeObject(Workers);
                sw.WriteLine(item);
            }
        }
        public List<Worker> ReadWorker()
        {
            try
            {
                var context = File.ReadAllText("workers.json");
                Workers = JsonConvert.DeserializeObject<List<Worker>>(context);
            }
            catch (Exception)
            {
            }
            return Workers;
        }
        public void WriteEmployer()
        {
            using (StreamWriter sw = new StreamWriter("employers.json"))
            {
                var item = JsonConvert.SerializeObject(Employers);
                sw.WriteLine(item);
            }
        }

        public List<Employer> ReadEmployer()
        {
            try
            {
                var context = File.ReadAllText("employers.json");
                Employers = JsonConvert.DeserializeObject<List<Employer>>(context);
            }
            catch (Exception)
            {
            }
            return Employers;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            WriteAllText writeAllText = new WriteAllText();
            SendMail sendMail = new SendMail();
            Employer employer = new Employer();
            BossAz boss = new BossAz();
            var humans = new List<Human>
            {
                new Worker
                {
                    Name = "Aysel",
                Surname = "Aliyeva",
                Username = "aysel123",
                Password = "aysel123",
                Age = 25,
                City = "Baku",
                TelephoneNumber = 0505673456
                },
                new Employer
                {
                    Name = "Narmin",
                Surname = "Aghayeva",
                Username = "narmin123",
                Password = "narmin123",
                Age = 35,
                City = "Baku",
                TelephoneNumber = 0553456789
                }
            };
            Worker worker1 = new Worker
            {
                Name = "Aysel",
                Surname = "Aliyeva",
                Username = "aysel123",
                Password = "aysel123",
                Age = 25,
                City = "Baku",
                TelephoneNumber = 0505673456
            };
            Employer employer1 = new Employer
            {
                Name = "Narmin",
                Surname = "Aghayeva",
                Username = "narmin123",
                Password = "narmin123",
                Age = 35,
                City = "Baku",
                TelephoneNumber = 0553456789
            };
            Vacancy vacancy1 = new Vacancy
            {
                Id = 1,
                CompanyName = "Pasha",
                Speciality = "Web developer",
                Skills = new string[] { @"    HTML/CSS,JavaScript,Git," +
                "\n\t\t\t\t\t      JS Libraries and Frameworks," +
                "\n\t\t\t\t\t      Responsive Web Designing Skills" },
                Experience = 5,
                Salary = 2000,
                Email = "narmin@gmail.com",
                TelephoneNumber = 0505678923,
                Tags = new string[] { "HTML,CSS,Java,Javascript,Git,JS,JSLibraries,Design,ResponsiveWebDesign,Web,Webdeveloper,webdeveloper,web,html,css,java,javascript,js,design" }
            };
            Vacancy vacancy2 = new Vacancy
            {
                Id = 2,
                CompanyName = "Socar",
                Speciality = "C# developer",
                Skills = new string[] { @"    HTML/CSS,JavaScript,Git," +
                "\n\t\t\t\t\t      JS Libraries and Frameworks," +
                "\n\t\t\t\t\t      Responsive Web Designing Skills" },
                Experience = 2,
                Salary = 2500,
                Email = "narmin@gmail.com",
                TelephoneNumber = 0505678923,
                Tags = new string[] { "C#,C++,HTML,CSS,Java,Javascript,Git,JS,JSLibraries,Design,ResponsiveWebDesign,Web,Webdeveloper,webdeveloper,web,html,css,java,javascript,js,design" }
            };
            Vacancy vacancy3 = new Vacancy
            {
                Id = 3,
                CompanyName = "BP",
                Speciality = ".NET developer",
                Skills = new string[] { @"    HTML/CSS,JavaScript,Git," +
                "\n\t\t\t\t\t      JS Libraries and Frameworks," +
                "\n\t\t\t\t\t      Responsive Web Designing Skills" },
                Experience = 3,
                Salary = 3500,
                Email = "narmin@gmail.com",
                TelephoneNumber = 0505678923,
                Tags = new string[] { "C#,C++,HTML,CSS,Java,Javascript,Git,JS,JSLibraries,Design,ResponsiveWebDesign,Web,Webdeveloper,webdeveloper,web,html,css,java,javascript,js,design" }
            };
            int ID = 3;
            Cv cv1 = new Cv
            {
                Speciality = "Web developer",
                School = "Kaspi lyceums",
                UniversityAdmissionScore = 670,
                Skills = new List<string> { "c#,c++,JS,Javascript,HTML/CSS" },
                Companies = new List<string> { "SOCAR" },
                BeginDate = new DateTime(2015, 05, 03),
                EndDate = new DateTime(2017, 05, 15),
                Languages = new List<string> { "English, Russian" },
                hasHonorsDiploma = true,
                GitLink = "aysel.gitlink",
                LinkedIn = "ayselaysel"
            };
            worker1.WorkerCv = cv1;
            employer1.Vacancies.Add(vacancy1);
            employer1.Vacancies.Add(vacancy2);
            employer1.Vacancies.Add(vacancy3);
            boss.Workers.Add(worker1);
            boss.Employers.Add(employer1);
            boss.WriteEmployer();
            boss.ReadEmployer();
            boss.WriteWorker();
            boss.ReadWorker();
            while (true)
            {
            MyBegin:
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t ██████╗   ██████╗  ███████╗ ███████╗    █████╗  ███████╗");
                Console.WriteLine("\t\t\t\t ██╔══██╗ ██╔═══██╗ ██╔════╝ ██╔════╝   ██╔══██╗ ╚══███╔╝");
                Console.WriteLine("\t\t\t\t ██████╔╝ ██║   ██║ ███████╗ ███████╗   ███████║   ███╔╝ ");
                Console.WriteLine("\t\t\t\t ██╔══██╗ ██║   ██║ ╚════██║ ╚════██║   ██╔══██║  ███╔╝  ");
                Console.WriteLine("\t\t\t\t ██████╔╝ ╚██████╔╝ ███████║ ███████║██╗██║  ██║ ███████╗");
                Console.WriteLine("\t\t\t\t ╚═════╝   ╚═════╝  ╚══════╝ ╚══════╝╚═╝╚═╝  ╚═╝ ╚══════╝");
                Console.ResetColor();
                Console.WriteLine("\n\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\t\t\t\t\t\t╔═════════════════╗");
                Console.WriteLine("\t\t\t\t\t\t║  1. Sign in     ║");
                Console.WriteLine("\t\t\t\t\t\t╚═════════════════╝");
                Console.WriteLine("\t\t\t\t\t\t╔═════════════════╗");
                Console.WriteLine("\t\t\t\t\t\t║  2. Sign up     ║");
                Console.WriteLine("\t\t\t\t\t\t╚═════════════════╝");
                Console.WriteLine("\t\t\t\t\t\t╔═════════════════╗");
                Console.WriteLine("\t\t\t\t\t\t║    3. Exit      ║");
                Console.WriteLine("\t\t\t\t\t\t╚═════════════════╝");
                int begin = int.Parse(Console.ReadLine());
                try
                {
                    if (begin == 1)
                    {
                        writeAllText.WriteToText("User signed in to the system");
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t  ███████╗ ██╗  ██████╗  ███╗   ██╗    ██╗ ███╗   ██╗");
                        Console.WriteLine("\t\t\t\t  ██╔════╝ ██║ ██╔════╝  ████╗  ██║    ██║ ████╗  ██║");
                        Console.WriteLine("\t\t\t\t  ███████╗ ██║ ██║  ███╗ ██╔██╗ ██║    ██║ ██╔██╗ ██║");
                        Console.WriteLine("\t\t\t\t  ╚════██║ ██║ ██║   ██║ ██║╚██╗██║    ██║ ██║╚██╗██║");
                        Console.WriteLine("\t\t\t\t  ███████║ ██║ ╚██████╔╝ ██║ ╚████║    ██║ ██║ ╚████║");
                        Console.WriteLine("\t\t\t\t  ╚══════╝ ╚═╝  ╚═════╝  ╚═╝  ╚═══╝    ╚═╝ ╚═╝  ╚═══╝");
                        Console.WriteLine("\t\t\t\t                                                     ");
                        Console.Write("\t\t\t\t\t   Enter your username : ");
                        string username = Console.ReadLine();
                        Console.Write("\t\t\t\t\t   Enter your password : ");
                        string password = Console.ReadLine();
                        for (int i = 0; i < boss.Workers.Count; i++)
                        {
                            try
                            {
                                if (boss.Workers[i].Username == username && boss.Workers[i].Password == password)
                                {
                                    Console.WriteLine("\t\t\t\t\t   Welcome, Worker!");
                                    Thread.Sleep(1000);
                                    Worker current = boss.GetWorkerByUsername(username);
                                    writeAllText.WriteToText($"User is {current.Name} {current.Surname}");
                                MyWorker:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("\t\t   ██╗    ██╗ ██████╗ ██████╗ ██╗  ██╗███████╗██████╗     ███╗   ███╗███████╗███╗   ██╗██╗   ██╗");
                                    Console.WriteLine("\t\t   ██║    ██║██╔═══██╗██╔══██╗██║ ██╔╝██╔════╝██╔══██╗    ████╗ ████║██╔════╝████╗  ██║██║   ██║");
                                    Console.WriteLine("\t\t   ██║ █╗ ██║██║   ██║██████╔╝█████╔╝ █████╗  ██████╔╝    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║");
                                    Console.WriteLine("\t\t   ██║███╗██║██║   ██║██╔══██╗██╔═██╗ ██╔══╝  ██╔══██╗    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║");
                                    Console.WriteLine("\t\t   ╚███╔███╔╝╚██████╔╝██║  ██║██║  ██╗███████╗██║  ██║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝");
                                    Console.WriteLine("\t\t    ╚══╝╚══╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ ");
                                    Console.WriteLine("\t\t                                                                                                ");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                    Console.WriteLine("\t\t\t\t\t\t║   1. Create your own CV    ║");
                                    Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                    Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                    Console.WriteLine("\t\t\t\t\t\t║       2. Search job        ║");
                                    Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                    Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                    Console.Write("\t\t\t\t\t\t║     3. Notifications ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write($"({current.Notifications.Number})   ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("║");
                                    Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                    Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                    Console.WriteLine("\t\t\t\t\t\t║      4. Observe your CV    ║");
                                    Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                    Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                    Console.WriteLine("\t\t\t\t\t\t║      5. Update your CV     ║");
                                    Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                    Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                    Console.WriteLine("\t\t\t\t\t\t║          6. Exit           ║");
                                    Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                    int first = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        if (first == 1)
                                        {
                                            try
                                            {
                                                if (current.WorkerCv.Speciality == null)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine();
                                                    Console.WriteLine();
                                                    Console.WriteLine("\t\t\t    ██████╗██████╗ ███████╗ █████╗ ████████╗███████╗     ██████╗██╗   ██╗");
                                                    Console.WriteLine("\t\t\t   ██╔════╝██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔════╝    ██╔════╝██║   ██║");
                                                    Console.WriteLine("\t\t\t   ██║     ██████╔╝█████╗  ███████║   ██║   █████╗      ██║     ██║   ██║");
                                                    Console.WriteLine("\t\t\t   ██║     ██╔══██╗██╔══╝  ██╔══██║   ██║   ██╔══╝      ██║     ╚██╗ ██╔╝");
                                                    Console.WriteLine("\t\t\t   ╚██████╗██║  ██║███████╗██║  ██║   ██║   ███████╗    ╚██████╗ ╚████╔╝ ");
                                                    Console.WriteLine("\t\t\t    ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝     ╚═════╝  ╚═══╝  ");
                                                    Console.WriteLine("\t\t\t                                                                         ");
                                                    Console.Write("\t\t\t\t\t   Speciality : ");
                                                    string speciality = Console.ReadLine();
                                                    Console.Write("\t\t\t\t\t   School : ");
                                                    string school = Console.ReadLine();
                                                    Console.Write("\t\t\t\t\t   University Addmission Score : ");
                                                    double score = double.Parse(Console.ReadLine());
                                                    Console.Write("\t\t\t\t\t   Skills : ");
                                                    List<string> skills = new List<string>() { Console.ReadLine() };
                                                    Console.Write("\t\t\t\t\t   Companies : ");
                                                    List<string> companies = new List<string>() { Console.ReadLine() };
                                                    Console.WriteLine("\t\t\t\t\t   Begin date ");
                                                    Console.Write("\t\t\t\t\t   Year : ");
                                                    int year = int.Parse(Console.ReadLine());
                                                    Console.Write("\t\t\t\t\t   Month : ");
                                                    int month = int.Parse(Console.ReadLine());
                                                    Console.Write("\t\t\t\t\t   Day : ");
                                                    int day = int.Parse(Console.ReadLine());
                                                    DateTime begindate = new DateTime(year, month, day);
                                                    Console.WriteLine("\t\t\t\t\t   End date ");
                                                    Console.Write("\t\t\t\t\t   Year : ");
                                                    year = int.Parse(Console.ReadLine());
                                                    Console.Write("\t\t\t\t\t   Month : ");
                                                    month = int.Parse(Console.ReadLine());
                                                    Console.Write("\t\t\t\t\t   Day : ");
                                                    day = int.Parse(Console.ReadLine());
                                                    DateTime enddate = new DateTime(year, month, day);
                                                    Console.Write("\t\t\t\t\t   Languages : ");
                                                    List<string> languages = new List<string>() { Console.ReadLine() };
                                                    Console.WriteLine();
                                                    Console.Write("\t\t\t\t\t   Do you have honors Diploma?\n\t\t\t\t\t   Yes [1]\n\t\t\t\t\t   No  [2]");
                                                    int diploma = int.Parse(Console.ReadLine());
                                                    bool hasHonorsDiploma = false;
                                                    if (diploma == 1)
                                                    {
                                                        hasHonorsDiploma = true;
                                                    }
                                                    else if (diploma == 2)
                                                    {
                                                        hasHonorsDiploma = false;
                                                    }
                                                    Console.Write("\t\t\t\t\t   GitLink : ");
                                                    string gitlink = Console.ReadLine();
                                                    Console.Write("\t\t\t\t\t   LinkedIn : ");
                                                    string linkedIn = Console.ReadLine();
                                                    Cv newcv = new Cv
                                                    {
                                                        Speciality = speciality,
                                                        School = school,
                                                        UniversityAdmissionScore = score,
                                                        Skills = skills,
                                                        Companies = companies,
                                                        BeginDate = begindate,
                                                        EndDate = enddate,
                                                        Languages = languages,
                                                        hasHonorsDiploma = hasHonorsDiploma,
                                                        GitLink = gitlink,
                                                        LinkedIn = linkedIn
                                                    };
                                                    current.WorkerCv = newcv;
                                                    Console.WriteLine("\t\t\t\t\t   CV is added successfully!");
                                                    boss.WriteWorker();
                                                    writeAllText.WriteToText($"{current.Name} {current.Surname} created his/her CV");
                                                    Thread.Sleep(1000);
                                                    goto MyWorker;
                                                }
                                                else
                                                {
                                                    throw new Exception("\t\t\t\t\t   You have already created CV");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(ex.Message);
                                                Thread.Sleep(1000);
                                                Console.ResetColor();
                                                Console.Clear();
                                                goto MyWorker;
                                            }
                                        }
                                        else if (first == 2)
                                        {
                                            if (current.WorkerCv != null)
                                            {
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine("\t\t\t\t\t███████╗███████╗ █████╗ ██████╗  ██████╗██╗  ██╗");
                                                Console.WriteLine("\t\t\t\t\t██╔════╝██╔════╝██╔══██╗██╔══██╗██╔════╝██║  ██║");
                                                Console.WriteLine("\t\t\t\t\t███████╗█████╗  ███████║██████╔╝██║     ███████║");
                                                Console.WriteLine("\t\t\t\t\t╚════██║██╔══╝  ██╔══██║██╔══██╗██║     ██╔══██║");
                                                Console.WriteLine("\t\t\t\t\t███████║███████╗██║  ██║██║  ██║╚██████╗██║  ██║");
                                                Console.WriteLine("\t\t\t\t\t╚══════╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝");
                                                Console.WriteLine("\t\t\t\t\t                                                ");
                                                Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                                Console.WriteLine("\t\t\t\t\t\t║     1. Show All Jobs       ║");
                                                Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                                Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                                Console.WriteLine("\t\t\t\t\t\t║       2. Search job        ║");
                                                Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                                int show = int.Parse(Console.ReadLine());
                                                int myorder = 1;
                                                Console.Clear();
                                                if (show == 1)
                                                {
                                                    for (int j = 0; j < boss.Employers.Count; j++)
                                                    {
                                                        for (int k = 0; k < boss.Employers[j].Vacancies.Count; k++)
                                                        {
                                                            Console.Write($"{myorder} ) ");
                                                            boss.Employers[j].Vacancies[k].Show();
                                                            myorder++;
                                                        }
                                                    }
                                                    Console.WriteLine("\t\t\t\t\t   1. Choose\n\t\t\t\t\t   2. Back");
                                                    Console.WriteLine("\t\t\t\t\t   Enter your choice : ");
                                                    int search = int.Parse(Console.ReadLine());
                                                    try
                                                    {
                                                        if (search == 1)
                                                        {
                                                            Console.Write("\t\t\t\t\t   Choose job, you want to apply : ");
                                                            int apply = int.Parse(Console.ReadLine());
                                                            for (int j = 0; j < boss.Employers.Count; j++)
                                                            {
                                                                for (int k = 0; k < boss.Employers[j].Vacancies.Count; k++)
                                                                {
                                                                    if (apply == boss.Employers[j].Vacancies[k].Id)
                                                                    {
                                                                        boss.Employers[j].Vacancies[k].Show();
                                                                        boss.Employers[j].Notifications.Number += 1;
                                                                        boss.Employers[j].Applicants.Add(current);
                                                                        boss.Employers[j].ApplicantVacancy.Add(boss.Employers[j].Vacancies[k]);
                                                                        writeAllText.WriteToText($"{current.Name} {current.Surname} searched and chose {boss.Employers[j].Vacancies[k]}");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (search == 2)
                                                        {
                                                            writeAllText.WriteToText($"{current.Name} {current.Surname} searched and went to back");
                                                            goto MyWorker;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("\t\t\t\t\t   You should choose 1 or 2!");
                                                        }
                                                        Console.Clear();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine(ex.Message);
                                                        Thread.Sleep(1000);
                                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                        Console.Clear();
                                                        goto MyWorker;
                                                    }

                                                }
                                                else if (show == 2)
                                                {
                                                MySearch:
                                                    Console.Write("\t\t\t\t\t   Enter : ");
                                                    Console.WriteLine();
                                                    string text = "";
                                                    while (true)
                                                    {
                                                        char symbol = Console.ReadKey().KeyChar;
                                                        if ((int)symbol == 13)
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            text = text + symbol;
                                                            Console.WriteLine();
                                                            int l = 1;
                                                            for (int j = 0; j < boss.Employers.Count; j++)
                                                            {
                                                                for (int t = 0; t < boss.Employers[j].Search(text).Count; t++)
                                                                {
                                                                    //l = t + 1;
                                                                    Console.Write($"{l} ) ");
                                                                    boss.Employers[j].Search(text)[t].Show();
                                                                    l++;
                                                                }
                                                            }
                                                            Console.Write(text);
                                                        }
                                                    }
                                                    Console.WriteLine("\t\t\t\t\t   Enter the work you want to apply : ");
                                                    int answer = int.Parse(Console.ReadLine());
                                                    for (int j = 0; j < boss.Employers.Count; j++)
                                                    {
                                                        for (int t = 0; t < boss.Employers[j].Search(text).Count; t++)
                                                        {
                                                            if (answer == boss.Employers[j].Vacancies[t].Id)
                                                            {
                                                                boss.Employers[j].Vacancies[t].Show();
                                                                boss.Employers[j].Notifications.Number += 1;
                                                                boss.Employers[j].Applicants.Add(current);
                                                                boss.Employers[j].ApplicantVacancy.Add(boss.Employers[j].Vacancies[t]);
                                                                writeAllText.WriteToText($"{current.Name} {current.Surname} searched and chose {boss.Employers[j].Vacancies[t]}");
                                                            }
                                                        }
                                                    }
                                                    Console.Clear();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\t\t\t\t\t   You have to add CV!");
                                                Thread.Sleep(1000);
                                                goto MyWorker;
                                            }
                                        }
                                        else if (first == 3)
                                        {
                                            writeAllText.WriteToText($"{current.Name} {current.Surname} entered to notifications section");
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("\t\t███╗   ██╗ ██████╗ ████████╗██╗███████╗██╗ ██████╗ █████╗ ████████╗██╗ ██████╗ ███╗   ██╗███████╗");
                                            Console.WriteLine("\t\t████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██║██╔════╝██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝");
                                            Console.WriteLine("\t\t██╔██╗ ██║██║   ██║   ██║   ██║█████╗  ██║██║     ███████║   ██║   ██║██║   ██║██╔██╗ ██║███████╗");
                                            Console.WriteLine("\t\t██║╚██╗██║██║   ██║   ██║   ██║██╔══╝  ██║██║     ██╔══██║   ██║   ██║██║   ██║██║╚██╗██║╚════██║");
                                            Console.WriteLine("\t\t██║ ╚████║╚██████╔╝   ██║   ██║██║     ██║╚██████╗██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║███████║");
                                            Console.WriteLine("\t\t╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝╚═╝     ╚═╝ ╚═════╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝");
                                            Console.WriteLine("\t\t                                                                                                 ");
                                            if (current.Notifications.Number != 0)
                                            {
                                                current.Notifications.Show();
                                                current.Notifications.Number = 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\t\t\t\t\t      You do not have any notification");
                                            }
                                            boss.WriteWorker();
                                            Thread.Sleep(3000);
                                            Console.Clear();
                                            goto MyWorker;
                                        }
                                        else if (first == 4)
                                        {
                                            writeAllText.WriteToText($"{current.Name} {current.Surname} observed his/her cv");
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("\t\t\t\t██╗   ██╗  ██████╗  ██╗   ██╗ ██████╗      ██████╗ ██╗   ██╗");
                                            Console.WriteLine("\t\t\t\t╚██╗ ██╔╝ ██╔═══██╗ ██║   ██║ ██╔══██╗    ██╔════╝ ██║   ██║");
                                            Console.WriteLine("\t\t\t\t ╚████╔╝  ██║   ██║ ██║   ██║ ██████╔╝    ██║      ██║   ██║");
                                            Console.WriteLine("\t\t\t\t  ╚██╔╝   ██║   ██║ ██║   ██║ ██╔══██╗    ██║      ╚██╗ ██╔╝");
                                            Console.WriteLine("\t\t\t\t   ██║    ╚██████╔╝ ╚██████╔╝ ██║  ██║    ╚██████╗  ╚████╔╝ ");
                                            Console.WriteLine("\t\t\t\t   ╚═╝     ╚═════╝   ╚═════╝  ╚═╝  ╚═╝     ╚═════╝   ╚═══╝ ");
                                            Console.WriteLine();
                                            try
                                            {
                                                if (current.WorkerCv.Speciality != null)
                                                {
                                                    current.WorkerCv.Show();
                                                    Thread.Sleep(5000);
                                                    goto MyWorker;
                                                }
                                                else
                                                {
                                                    throw new Exception("\t\t\t\t\t   You do not have CV ");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(ex.Message);
                                                Thread.Sleep(1000);
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Clear();
                                                goto MyWorker;
                                            }
                                        }
                                        else if (first == 5)
                                        {
                                        MyUpdate:
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("\t\t\t██╗   ██╗██████╗ ██████╗  █████╗ ████████╗███████╗     ██████╗██╗   ██╗");
                                            Console.WriteLine("\t\t\t██║   ██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝    ██╔════╝██║   ██║");
                                            Console.WriteLine("\t\t\t██║   ██║██████╔╝██║  ██║███████║   ██║   █████╗      ██║     ██║   ██║");
                                            Console.WriteLine("\t\t\t██║   ██║██╔═══╝ ██║  ██║██╔══██║   ██║   ██╔══╝      ██║     ╚██╗ ██╔╝");
                                            Console.WriteLine("\t\t\t╚██████╔╝██║     ██████╔╝██║  ██║   ██║   ███████╗    ╚██████╗ ╚████╔╝ ");
                                            Console.WriteLine("\t\t\t ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝     ╚═════╝  ╚═══╝  ");
                                            Console.WriteLine();
                                            try
                                            {
                                                if (current.WorkerCv.Speciality != null)
                                                {
                                                    current.WorkerCv.Show();
                                                    Console.WriteLine();
                                                    Console.WriteLine("\t\t\t\t\t   1. Speciality\n\t\t\t\t\t   2. School\n\t\t\t\t\t   3. University Admission Score\n\t\t\t\t\t   4. Skills\n\t\t\t\t\t   5. Companies\n\t\t\t\t\t   6. Begin Date\n\t\t\t\t\t   7. End Date\n\t\t\t\t\t   8. Languages\n\t\t\t\t\t   9. Has Honor Diploma\n\t\t\t\t\t   10. GitLink\n\t\t\t\t\t   11. LinkedIn");
                                                    Console.WriteLine("\t\t\t         1. Choose\n\t\t\t         2. Back ");
                                                    Console.Write("\t\t\t         Enter your choice : ");
                                                    int before = int.Parse(Console.ReadLine());
                                                    if (before == 1)
                                                    {
                                                        writeAllText.WriteToText($"{current.Name} {current.Surname} updated his/her cv");
                                                        Console.WriteLine("\t\t\t\t\t   What do you want to change?");
                                                        var update = int.Parse(Console.ReadLine());
                                                        try
                                                        {
                                                            if (update == 1)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new Speciality : ");
                                                                string newspeciality = Console.ReadLine();
                                                                current.UpdateSpeciality(newspeciality);
                                                                Console.WriteLine("\t\t\t\t\t   Speciality is updated successfully");
                                                                boss.WriteWorker();
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 2)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new School : ");
                                                                string newschool = Console.ReadLine();
                                                                current.UpdateSchool(newschool);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   School is updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 3)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new Score : ");
                                                                double newscore = double.Parse(Console.ReadLine());
                                                                current.UpdateScore(newscore);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   Score is updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 4)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new Skills : ");
                                                                List<string> newSkills = new List<string>() { Console.ReadLine() };
                                                                current.UpdateSkills(newSkills);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   Skills are updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 5)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new Companies : ");
                                                                List<string> newCompanies = new List<string>() { Console.ReadLine() };
                                                                current.UpdateCompanies(newCompanies);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   Companies are updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 6)
                                                            {
                                                                Console.WriteLine("\t\t\t\t\t   New Begin date  ");
                                                                Console.Write("\t\t\t\t\t   Year : ");
                                                                int newyear = int.Parse(Console.ReadLine());
                                                                Console.Write("\t\t\t\t\t   Month : ");
                                                                int newmonth = int.Parse(Console.ReadLine());
                                                                Console.Write("\t\t\t\t\t   Day : ");
                                                                int newday = int.Parse(Console.ReadLine());
                                                                DateTime newbegindate = new DateTime(newyear, newmonth, newday);
                                                                current.UpdateBeginDate(newbegindate);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   Begin Date is updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 7)
                                                            {
                                                                Console.WriteLine("\t\t\t\t\t   New End date  ");
                                                                Console.Write("\t\t\t\t\t   Year : ");
                                                                int newyear = int.Parse(Console.ReadLine());
                                                                Console.Write("\t\t\t\t\t   Month : ");
                                                                int newmonth = int.Parse(Console.ReadLine());
                                                                Console.Write("\t\t\t\t\t   Day : ");
                                                                int newday = int.Parse(Console.ReadLine());
                                                                DateTime newenddate = new DateTime(newyear, newmonth, newday);
                                                                current.UpdateEndDate(newenddate);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   End Date is updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 8)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new Languages : ");
                                                                List<string> newLang = new List<string>() { Console.ReadLine() };
                                                                current.UpdateLanguages(newLang);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   Languages are updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 9)
                                                            {
                                                                Console.WriteLine("\t\t\t\t\t   Do you have honors Diploma?\n\t\t\t\t\t   Yes [1]\n\t\t\t\t\t   No  [2]");
                                                                int diploma = int.Parse(Console.ReadLine());
                                                                bool hasHonorsDiploma = false;
                                                                if (diploma == 1)
                                                                {
                                                                    current.UpdateHonorDiploma(hasHonorsDiploma);
                                                                    boss.WriteWorker();
                                                                }
                                                                else if (diploma == 2)
                                                                {
                                                                    current.UpdateHonorDiploma(!hasHonorsDiploma);
                                                                    boss.WriteWorker();
                                                                }
                                                            }
                                                            else if (update == 10)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new GitLink : ");
                                                                string newgit = Console.ReadLine();
                                                                current.UpdateGitlink(newgit);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   GitLink is updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else if (update == 11)
                                                            {
                                                                Console.Write("\t\t\t\t\t   Enter new LinkedIn account link : ");
                                                                string newlink = Console.ReadLine();
                                                                current.UpdateLinkedin(newlink);
                                                                boss.WriteWorker();
                                                                Console.WriteLine("\t\t\t\t\t   LinkedIn is updated successfully");
                                                                Thread.Sleep(1000);
                                                                goto MyWorker;
                                                            }
                                                            else
                                                            {
                                                                throw new Exception("\t\t\t\t\t   Please, choose the valid option!");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine(ex.Message);
                                                            Thread.Sleep(1000);
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.Clear();
                                                            goto MyUpdate;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        goto MyWorker;
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception("\t\t\t\t\t   You do not have Cv!");
                                                }
                                            }

                                            catch (Exception ex)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine(ex.Message);
                                                Thread.Sleep(1000);
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Clear();
                                                goto MyWorker;
                                            }
                                        }
                                        else if (first == 6)
                                        {
                                            Console.Clear();
                                            goto MyBegin;
                                        }
                                        else
                                        {
                                            throw new Exception("\t\t\t\t\t   You should choose : 1,2,3,4,5 or 6");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(ex.Message);
                                        Thread.Sleep(1000);
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Clear();
                                        goto MyWorker;
                                    }
                                }
                                else
                                {
                                    for (int k = 0; k < boss.Employers.Count; k++)
                                    {
                                        try
                                        {
                                            if (boss.Employers[k].Username == username && boss.Employers[k].Password == password)
                                            {
                                                Console.WriteLine("\t\t\t\t\t   Welcome, Employer!");
                                                Thread.Sleep(1000);
                                                Employer myemployer = boss.GetEmployerByUsername(username);
                                                writeAllText.WriteToText($"User is {myemployer.Name} {myemployer.Surname}");
                                            MyEmployer:
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine("    ███████╗███╗   ███╗██████╗ ██╗      ██████╗ ██╗   ██╗███████╗██████╗     ███╗   ███╗███████╗███╗   ██╗██╗   ██╗");
                                                Console.WriteLine("    ██╔════╝████╗ ████║██╔══██╗██║     ██╔═══██╗╚██╗ ██╔╝██╔════╝██╔══██╗    ████╗ ████║██╔════╝████╗  ██║██║   ██║");
                                                Console.WriteLine("    █████╗  ██╔████╔██║██████╔╝██║     ██║   ██║ ╚████╔╝ █████╗  ██████╔╝    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║");
                                                Console.WriteLine("    ██╔══╝  ██║╚██╔╝██║██╔═══╝ ██║     ██║   ██║  ╚██╔╝  ██╔══╝  ██╔══██╗    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║");
                                                Console.WriteLine("    ███████╗██║ ╚═╝ ██║██║     ███████╗╚██████╔╝   ██║   ███████╗██║  ██║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝");
                                                Console.WriteLine("    ╚══════╝╚═╝     ╚═╝╚═╝     ╚══════╝ ╚═════╝    ╚═╝   ╚══════╝╚═╝  ╚═╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ ");
                                                Console.WriteLine("                                                                                                                   ");
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                                Console.WriteLine("\t\t\t\t\t\t║       1. Add Vacancy       ║");
                                                Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                                Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                                Console.Write("\t\t\t\t\t\t║     2. Show Applicants ");
                                                Console.ResetColor();
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"({myemployer.Notifications.Number}) ");
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine("║");
                                                Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                                Console.WriteLine("\t\t\t\t\t\t╔════════════════════════════╗");
                                                Console.WriteLine("\t\t\t\t\t\t║          3. Exit           ║");
                                                Console.WriteLine("\t\t\t\t\t\t╚════════════════════════════╝");
                                                int first = int.Parse(Console.ReadLine());
                                                try
                                                {
                                                    if (first == 1)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine();
                                                        Console.WriteLine();
                                                        Console.WriteLine("\t\t\t █████╗ ██████╗ ██████╗     ██╗   ██╗ █████╗  ██████╗ █████╗ ███╗   ██╗ ██████╗██╗   ██╗");
                                                        Console.WriteLine("\t\t\t██╔══██╗██╔══██╗██╔══██╗    ██║   ██║██╔══██╗██╔════╝██╔══██╗████╗  ██║██╔════╝╚██╗ ██╔╝");
                                                        Console.WriteLine("\t\t\t███████║██║  ██║██║  ██║    ██║   ██║███████║██║     ███████║██╔██╗ ██║██║      ╚████╔╝ ");
                                                        Console.WriteLine("\t\t\t██╔══██║██║  ██║██║  ██║    ╚██╗ ██╔╝██╔══██║██║     ██╔══██║██║╚██╗██║██║       ╚██╔╝  ");
                                                        Console.WriteLine("\t\t\t██║  ██║██████╔╝██████╔╝     ╚████╔╝ ██║  ██║╚██████╗██║  ██║██║ ╚████║╚██████╗   ██║   ");
                                                        Console.WriteLine("\t\t\t╚═╝  ╚═╝╚═════╝ ╚═════╝       ╚═══╝  ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝   ╚═╝   ");
                                                        Console.WriteLine();
                                                        Console.WriteLine();
                                                        Console.Write("\t\t\t\t\t        Enter Company Name :");
                                                        string companyName = Console.ReadLine();
                                                        Console.Write("\t\t\t\t\t        Enter Speciality : ");
                                                        string speciality = Console.ReadLine();
                                                        Console.Write("\t\t\t\t\t        Skills : ");
                                                        string[] skills = Console.ReadLine().Split('\u002C');
                                                        Console.Write("\t\t\t\t\t        Enter Experience year :");
                                                        double experience = double.Parse(Console.ReadLine());
                                                        Console.Write("\t\t\t\t\t        Enter salary : ");
                                                        decimal salary = decimal.Parse(Console.ReadLine());
                                                        Console.Write("\t\t\t\t\t        Enter email : ");
                                                        string email = Console.ReadLine();
                                                        Console.Write("\t\t\t\t\t        Enter phone number : ");
                                                        long phoneNumber = long.Parse(Console.ReadLine());
                                                        Console.Write("\t\t\t\t\t        Enter tags : ");
                                                        string[] tags = Console.ReadLine().Split('\u002C');
                                                        Vacancy newVacancy = new Vacancy
                                                        {
                                                            Id = ++ID,
                                                            CompanyName = companyName,
                                                            Speciality = speciality,
                                                            Skills = skills,
                                                            Experience = experience,
                                                            Salary = salary,
                                                            Email = email,
                                                            TelephoneNumber = phoneNumber,
                                                            Tags = tags
                                                        };
                                                        myemployer.Vacancies.Add(newVacancy);
                                                        boss.WriteEmployer();
                                                        Console.WriteLine("\t\t\t\t\t   Vacancy is added successfully!");
                                                        writeAllText.WriteToText($"{myemployer.Name} {myemployer.Surname} added new vacancy");
                                                        Thread.Sleep(1000);
                                                        goto MyEmployer;
                                                    }
                                                    else if (first == 2)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine();
                                                        Console.WriteLine();
                                                        Console.WriteLine("  \t\t     █████╗ ██████╗ ██████╗ ██╗     ██╗ ██████╗ █████╗ ███╗   ██╗████████╗███████╗");
                                                        Console.WriteLine("  \t\t    ██╔══██╗██╔══██╗██╔══██╗██║     ██║██╔════╝██╔══██╗████╗  ██║╚══██╔══╝██╔════╝");
                                                        Console.WriteLine("  \t\t    ███████║██████╔╝██████╔╝██║     ██║██║     ███████║██╔██╗ ██║   ██║   ███████╗");
                                                        Console.WriteLine("  \t\t    ██╔══██║██╔═══╝ ██╔═══╝ ██║     ██║██║     ██╔══██║██║╚██╗██║   ██║   ╚════██║");
                                                        Console.WriteLine("  \t\t    ██║  ██║██║     ██║     ███████╗██║╚██████╗██║  ██║██║ ╚████║   ██║   ███████║");
                                                        Console.WriteLine("  \t\t    ╚═╝  ╚═╝╚═╝     ╚═╝     ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝");
                                                        myemployer.Notifications.Number = 0;
                                                        boss.WriteEmployer();
                                                        for (int m = 0; m < myemployer.Applicants.Count; m++)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            myemployer.Applicants[m].Show();
                                                            Console.ResetColor();
                                                            Console.WriteLine("\t\t\t\t\t   Applied for");
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            myemployer.ApplicantVacancy[m].Show();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                                                        }
                                                        Console.WriteLine("");
                                                        try
                                                        {
                                                            if (myemployer.Applicants.Count > 0)
                                                            {
                                                            CheckUsername:
                                                                Console.WriteLine("\t\t\t\t\t   Enter your choice : \n\t\t\t\t\t   1. Choose applicant\n\t\t\t\t\t   2. Exit");
                                                                int showapp = int.Parse(Console.ReadLine());
                                                                try
                                                                {
                                                                    if (showapp == 1)
                                                                    {
                                                                        Console.Write("\t\t\t\t\t   Enter the username of applicant : ");
                                                                        string user = Console.ReadLine();
                                                                        for (int b = 0; b < boss.Employers.Count; b++)
                                                                        {
                                                                            for (int c = 0; c < boss.Employers[b].Applicants.Count; c++)
                                                                            {
                                                                                try
                                                                                {
                                                                                    if (user == boss.Employers[b].Applicants[c].Username)
                                                                                    {
                                                                                    CheckAccept:
                                                                                        Console.WriteLine("\t\t\t\t\t   1. Accept\n\t\t\t\t\t   2. Reject");
                                                                                        Console.Write("\t\t\t\t\t   Enter you choice : ");
                                                                                        int end = int.Parse(Console.ReadLine());
                                                                                    CheckWorkName:
                                                                                        Console.Write("\t\t\t\t\t   Which work? Add Speciality : ");
                                                                                        string work = Console.ReadLine();
                                                                                        for (int v = 0; v < boss.Employers[b].Vacancies.Count; v++)
                                                                                        {
                                                                                            Vacancy currentvacancy = boss.Employers[b].Vacancies[v];
                                                                                            var currentspeciality = boss.Employers[b].Vacancies[v].Speciality.ToLower();
                                                                                            try
                                                                                            {
                                                                                                if (work.ToLower() == currentspeciality)
                                                                                                {
                                                                                                    try
                                                                                                    {
                                                                                                        if (end == 1)
                                                                                                        {
                                                                                                            boss.Employers[b].Applicants[c].Notifications.Number += 1;
                                                                                                            boss.Employers[b].Applicants[c].Notifications.Message = $"You have been accepted to {currentvacancy.CompanyName} Position: {currentspeciality}";
                                                                                                            sendMail.SendEmail("vstudio7377@gmail.com", "vbsqxayxsgjktzbn", "Job application response", $"You have been accepted to {currentvacancy.CompanyName} Position: {currentspeciality}");
                                                                                                            boss.WriteEmployer();
                                                                                                            boss.Employers[b].Applicants.Remove(boss.Employers[b].Applicants[c]);
                                                                                                            boss.Employers[b].ApplicantVacancy.Remove(currentvacancy);
                                                                                                            writeAllText.WriteToText($"{myemployer.Name} {myemployer.Surname} accepted {boss.Employers[b].Applicants[c]} to {currentvacancy.CompanyName} as {currentvacancy.Speciality}");
                                                                                                            Console.WriteLine("\t\t\t\t\t   Message is sent");
                                                                                                            Thread.Sleep(2000);
                                                                                                            goto MyEmployer;
                                                                                                        }
                                                                                                        else if (end == 2)
                                                                                                        {
                                                                                                            boss.Employers[b].Applicants[c].Notifications.Number += 1;
                                                                                                            boss.Employers[b].Applicants[c].Notifications.Message = $"You have been rejected from {currentvacancy.CompanyName} Position: {currentspeciality}";
                                                                                                            sendMail.SendEmail("vstudio7377@gmail.com", "vbsqxayxsgjktzbn", "Job application response", $"You have been rejected from {currentvacancy.CompanyName} Position: {currentspeciality}");
                                                                                                            boss.WriteEmployer();
                                                                                                            boss.Employers[b].Applicants.Remove(boss.Employers[b].Applicants[c]);
                                                                                                            boss.Employers[b].ApplicantVacancy.Remove(currentvacancy);
                                                                                                            writeAllText.WriteToText($"{myemployer.Name} {myemployer.Surname} rejected {boss.Employers[b].Applicants[c]} from {currentvacancy.CompanyName}. Position is :  {currentvacancy.Speciality}");
                                                                                                            Console.WriteLine("\t\t\t\t\t   Message is sent");
                                                                                                            Thread.Sleep(2000);
                                                                                                            goto MyEmployer;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            throw new Exception("\t\t\t\t\t   You should choose 1 or 2");
                                                                                                        }
                                                                                                    }
                                                                                                    catch (Exception ex)
                                                                                                    {
                                                                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                                                                        Console.WriteLine(ex.Message);
                                                                                                        Thread.Sleep(1000);
                                                                                                        Console.ResetColor();
                                                                                                        Console.Clear();
                                                                                                        goto CheckAccept;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (v == boss.Employers[b].Vacancies.Count - 1)
                                                                                                    {
                                                                                                        throw new Exception("\t\t\t\t\t   This Speciality does not exist");
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            catch (Exception ex)
                                                                                            {
                                                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                                                Console.WriteLine(ex.Message);
                                                                                                Thread.Sleep(1000);
                                                                                                Console.ResetColor();
                                                                                                Console.Clear();
                                                                                                goto CheckWorkName;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (c == boss.Employers[i].Applicants.Count - 1)
                                                                                        {
                                                                                            throw new Exception("\t\t\t\t\t   This username does not exist!");
                                                                                        }
                                                                                    }
                                                                                }
                                                                                catch (Exception ex)
                                                                                {
                                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                                    Console.WriteLine(ex.Message);
                                                                                    Thread.Sleep(1000);
                                                                                    Console.ResetColor();
                                                                                    Console.Clear();
                                                                                    goto CheckUsername;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        goto MyEmployer;
                                                                    }
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine(ex.Message);
                                                                    Thread.Sleep(1000);
                                                                    Console.ResetColor();
                                                                    Console.Clear();
                                                                    goto MyEmployer;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                throw new Exception("\t\t\t\t\t   There does not exist an applicant");
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine(ex.Message);
                                                            Thread.Sleep(2000);
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.Clear();
                                                            goto MyEmployer;
                                                        }
                                                    }
                                                    else if (first == 3)
                                                    {
                                                        Console.Clear();
                                                        goto MyBegin;
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("\t\t\t\t\t   You should choose 1,2 or 3");
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine(ex.Message);
                                                    Thread.Sleep(1000);
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Clear();
                                                    goto MyEmployer;
                                                }
                                            }
                                            else
                                            {
                                                if (k == boss.Employers.Count - 1 && i == boss.Workers.Count - 1)
                                                {
                                                    throw new Exception("\t\t\t\t\t   Invalid username or password");
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine(ex.Message);
                                            Thread.Sleep(1000);
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Clear();
                                            goto MyBegin;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Clear();
                                goto MyBegin;
                            }
                        }
                    }
                    else if (begin == 2)
                    {
                        writeAllText.WriteToText("User signed up ");
                    SignUp:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t  ███████╗ ██╗  ██████╗  ███╗   ██╗    ██╗   ██╗ ██████╗ ");
                        Console.WriteLine("\t\t\t\t  ██╔════╝ ██║ ██╔════╝  ████╗  ██║    ██║   ██║ ██╔══██╗");
                        Console.WriteLine("\t\t\t\t  ███████╗ ██║ ██║  ███╗ ██╔██╗ ██║    ██║   ██║ ██████╔╝");
                        Console.WriteLine("\t\t\t\t  ╚════██║ ██║ ██║   ██║ ██║╚██╗██║    ██║   ██║ ██╔═══╝ ");
                        Console.WriteLine("\t\t\t\t  ███████║ ██║ ╚██████╔╝ ██║ ╚████║    ╚██████╔╝ ██║     ");
                        Console.WriteLine("\t\t\t\t  ╚══════╝ ╚═╝  ╚═════╝  ╚═╝  ╚═══╝     ╚═════╝  ╚═╝     ");
                        Console.WriteLine("\t\t\t\t                                                         ");
                        Console.WriteLine("\t\t\t\t\t\t╔═════════════════╗");
                        Console.WriteLine("\t\t\t\t\t\t║   1. Worker     ║");
                        Console.WriteLine("\t\t\t\t\t\t╚═════════════════╝");
                        Console.WriteLine("\t\t\t\t\t\t╔═════════════════╗");
                        Console.WriteLine("\t\t\t\t\t\t║   2. Employer   ║");
                        Console.WriteLine("\t\t\t\t\t\t╚═════════════════╝");
                    ChoosePerson:
                        Console.WriteLine();
                        Console.Write("\t\t\t\t\t\t   Who are you? ");
                        int person = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t      Enter username : ");
                        string username = Console.ReadLine();
                        if (username.Length <= 5)
                        {
                            Console.WriteLine("\t\t\t\t\t      Please choose the username which has more than 5 characters");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto SignUp;
                        }
                        for (int l = 0; l < humans.Count; l++)
                        {
                            if (username == humans[l].Username)
                            {
                                Console.WriteLine("\t\t\t\t\t\t   This username is taken");
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto SignUp;
                            }
                        }
                    MyPassword:
                        Console.Write("\t\t\t\t\t      Enter password : ");
                        string password = Console.ReadLine();
                        if (password.Length <= 5)
                        {
                            Console.WriteLine("\t\t\t\t\t\t   Password Length must be greater than 5");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto SignUp;
                        }
                        Console.Write("\t\t\t\t\t      Enter your name :");
                        string name = Console.ReadLine();
                        Console.Write("\t\t\t\t\t      Enter your surname :");
                        string surname = Console.ReadLine();
                        Console.Write("\t\t\t\t\t      Enter your age :");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("\t\t\t\t\t      Enter current live address(city) :");
                        string city = Console.ReadLine();
                        Console.Write("\t\t\t\t\t      Enter your Telephone Number :");
                        long number = long.Parse(Console.ReadLine());
                        try
                        {
                            if (person == 1)
                            {
                                Worker newWorker = new Worker
                                {
                                    Name = name,
                                    Surname = surname,
                                    Username = username,
                                    Password = password,
                                    Age = age,
                                    City = city,
                                    TelephoneNumber = number
                                };
                                boss.Workers.Add(newWorker);
                                humans.Add(newWorker);
                                boss.WriteWorker();
                                writeAllText.WriteToText($" New Worker is : {name} {surname}");
                                Console.WriteLine("\t\t\t\t\t   Worker is added successfully!");
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto MyBegin;
                            }
                            else if (person == 2)
                            {
                                Employer newEmployer = new Employer
                                {
                                    Name = name,
                                    Surname = surname,
                                    Username = username,
                                    Password = password,
                                    Age = age,
                                    City = city,
                                    TelephoneNumber = number
                                };
                                boss.Employers.Add(newEmployer);
                                writeAllText.WriteToText($" New Employer is : {name} {surname}");
                                Console.WriteLine("\t\t\t\t\t   Employer is added successfully!");
                                humans.Add(newEmployer);
                                boss.WriteEmployer();
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto MyBegin;
                            }
                            else
                            {
                                throw new Exception("\t\t\t\t\t   You should choose 1 or 2!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Thread.Sleep(1000);
                            Console.ResetColor();
                            Console.Clear();
                            goto ChoosePerson;
                        }
                    }
                    else if (begin == 3)
                    {
                        writeAllText.WriteToText("User exited from the system");
                        return;
                    }
                    else
                    {
                        throw new Exception("\t\t\t\t\t   You should choose 1,2 or 3!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    goto MyBegin;
                }
            }
        }
    }
}
