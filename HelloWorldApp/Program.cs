using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldApp
{
    internal class Program
    {
        static void Main(String[] args)
        {
            List<String> nationalities;
            void initList()
            {
                nationalities = new List<String>()
                {
                "Australian",
                "Mongolian",
                "Russian",
                "Austrian",
                "Brazilian"
                };
            }

            initList();
            nationalities.Sort();


            foreach (String nationality in nationalities)
            {
                Console.WriteLine(nationality);
            }
        }
    }
}
