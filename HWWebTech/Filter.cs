using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWWebTech
{
    class Filter
    {
        public static IEnumerable<VacancyItems> MoreThen(string request, int salary)
        {
            var desobj = JsonConvert.DeserializeObject<Vacancy>(request);

            var selectedVacancy = from vacancy in desobj.items
                                  where vacancy.salary != null && vacancy.salary.currency == "RUR"
                                  where (vacancy.salary.@from != null && vacancy.salary.to != null) ?
                                  (((vacancy.salary.@from + vacancy.salary.to) / 2) >= salary) :
                                  (vacancy.salary.@from != null) ? (vacancy.salary.@from >= salary) :
                                  (vacancy.salary.to >= salary)
                                  select vacancy;

            return selectedVacancy;
        }


        public static IEnumerable<VacancyItems> LessThen(string request, int salary)
        {
            var desobj = JsonConvert.DeserializeObject<Vacancy>(request);

            var selectedVacancy = from vacancy in desobj.items
                                  where vacancy.salary != null && vacancy.salary.currency == "RUR"
                                  where (vacancy.salary.@from != null && vacancy.salary.to != null) ?
                                  (((vacancy.salary.@from + vacancy.salary.to) / 2) <= salary) :
                                  (vacancy.salary.@from != null) ? (vacancy.salary.@from <= salary) :
                                  (vacancy.salary.to <= salary)
                                  select vacancy;

            return selectedVacancy;
        }
    }
}
