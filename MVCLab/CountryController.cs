using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCLab
{
    class CountryController
    {
        private CountryListView listView = null;
        public bool FancyGraphics { get; set; }
        public List<Country> CountryDb { get; protected set; }

        public CountryController(List<Country> countries)
        {
            CountryDb = countries;
            FancyGraphics = false;
        }
        public CountryController(params Country[] countries)
        {
            CountryDb = countries.ToList();
            FancyGraphics = false;
            listView = new CountryListView(CountryDb);
        }
        public void WelcomeAction()
        {
            Console.WriteLine("Hello, welcome to the country app.");
            FancyGraphics = Utilities.GetYesNoInput("Would you like to enable fun display mode (warning: it will look like someone filled your console window with skittles)\ny(es)/n(o): ");
        }
        public void SelectCountryAction()
        {
            Console.Clear();
            if (FancyGraphics)
            {
                listView.DisplayColored();
            }
            else
            {
                listView.Display();
            }
            int nCountry = Utilities.GetIntInputAdjusted("Which country would you like to learn more about", listView.Countries.Count);
            CountryAction(CountryDb[nCountry] ?? new Country("An error has occurred.", "Please try again.", "Red", "White"));
        }
        public void CountryAction(Country c)
        {
            if (FancyGraphics)
            {
                new CountryView(c).DisplayColored();
                return;
            }
            new CountryView(c).Display();
        }
    }
}
