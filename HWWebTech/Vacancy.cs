using System.Collections.Generic;

namespace HWWebTech
{
    public class Vacancy
    {
        public VacancyItems[] items { get; set; }
    }

    public class VacancyItems
    {
        public int id { get; set; }
        public string name { get; set; }
        public VacancySalary salary { get; set; }
    }

    public class VacancySalary
    {
        public int? from { get; set; }
        public int? to { get; set; }
        public string currency { get; set; }
    }

    public class VacancyMoreInfo
    {
        public List<VacancyKeySkills> key_skills { get; set; }
    }

    public class VacancyKeySkills
    {
        public string name { get; set; }
    }
}
