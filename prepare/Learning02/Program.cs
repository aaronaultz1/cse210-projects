using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    public class Job
    {
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;

        public void Display()
        {
            Console.WriteLine($"Company: {_company}, Job Title: {_jobTitle}, Year: {_startYear} - {_endYear}");
        }

    }
    public class Resume
    {
        public string _name;
        public List<Job> _jobs = new List<Job>();
        
    }

    static void Main(string[] args)
    {

        Job walmart = new Job();

        walmart._company = "Walmart";
        walmart._jobTitle = "Digital Associate";
        walmart._startYear = 2018;
        walmart._endYear = 2020;

        walmart.Display();

        Job bricon = new Job();

        bricon._company = "Bricon";
        bricon._jobTitle = "Construction Worker";
        bricon._startYear = 2020;
        bricon._endYear = 2025;

        bricon.Display();


        
        Resume aaronResume = new Resume();
        aaronResume._name = "Aaron Aultz";
        aaronResume._jobs.Add(walmart);
        aaronResume._jobs.Add(bricon);


    }
}