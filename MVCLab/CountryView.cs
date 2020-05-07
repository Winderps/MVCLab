using System;
using System.Collections.Generic;
using System.Text;

namespace MVCLab
{
    class CountryView
    {
        public Country DisplayCountry { get; protected set; }

        public CountryView(Country c)
        {
            DisplayCountry = c;
        }

        public void DisplayColored()
        {
            string displayText =
                $"Name: {DisplayCountry.Name}\n" +
                $"Continent: {DisplayCountry.Continent}\n" +
                $"Colors: ";
            DisplayCountry.Colors.ForEach(
                c => displayText += c + ", ");
            displayText = displayText.Remove(displayText.Length - 2);

            Utilities.DisplayColoredByWord(displayText, DisplayCountry.DisplayColors);
        }
        public void Display()
        {
            string displayText =
                $"Name: {DisplayCountry.Name}\n" +
                $"Continent: {DisplayCountry.Continent}\n" +
                $"Colors: ";
            DisplayCountry.Colors.ForEach(
                c => displayText += c + ",");
            displayText = displayText.Remove(displayText.Length - 1);

            Console.WriteLine(displayText);
        }
    }
}
