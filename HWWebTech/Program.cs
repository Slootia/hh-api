using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HWWebTech
{
    //TODO: Учитывать другие валюты
    class Program
    { 

        static void Main(string[] args)
        {
            int counter = 1;
            int salary = 120000;
            string requestMore;
            string request;
            IEnumerable<VacancyItems> result;
            VacancyMoreInfo resultMore;

            //Можно вынести в отдельный метод, сетод сортировки - передавать делегатом
            for (int i = 0; i < 19; i++)
            {
                request = Deserialize.GetVacancy(i).Result;
                result = Filter.MoreThen(request, salary);
               
                foreach (var item in result)
                {
                    Console.WriteLine($"{counter}.{item.name} (id: {item.id}): {item.salary.from} - {item.salary.to} {item.salary.currency}");

                    requestMore = Deserialize.GetMoreInfo(item.id).Result;
                    Console.Write("Навыки:");
                    resultMore = JsonConvert.DeserializeObject<VacancyMoreInfo>(requestMore);
                    foreach (var skill in resultMore.key_skills)
                    {
                        Console.Write(skill.name + ' ');
                    }
                    Console.WriteLine("\n");
                    counter++;
                }
            }


            counter = 0;
            for (int i = 0; i < 19; i++)
            {
                request = Deserialize.GetVacancy(i).Result;
                result = Filter.LessThen(request, salary);

                foreach (var item in result)
                {
                    Console.WriteLine($"{counter}.{item.name} (id: {item.id}): {item.salary.from} - {item.salary.to} {item.salary.currency}");

                    requestMore = Deserialize.GetMoreInfo(item.id).Result;
                    Console.Write("Навыки:");
                    resultMore = JsonConvert.DeserializeObject<VacancyMoreInfo>(requestMore);
                    foreach (var skill in resultMore.key_skills)
                    {
                        Console.Write(skill.name + ' ');
                    }
                    Console.WriteLine("\n");
                    counter++;
                }
            }

            Console.ReadLine();
        }
    }
}