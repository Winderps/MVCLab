using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCLab
{
    class CountryListView
    {
        public List<Country> Countries { get; protected set; }

        public CountryListView(List<Country> countries)
        {
            Countries = countries;
        }

        public CountryListView(params Country[] countries)
        {
            Countries = countries.ToList();
        }

        public void DisplayColored()
        {
            int i = 0;
            Countries.ForEach(c =>
                Utilities.DisplayColoredByWord($"{++i}. {c.Name}", c.DisplayColors)
                );
        }
        public void Display()
        {
            int i = 0;
            Countries.ForEach(c =>
                Console.WriteLine($"{++i}. {c.Name}", c.DisplayColors)
                );
        }
    }
}
