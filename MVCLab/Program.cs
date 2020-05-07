using System;

namespace MVCLab
{
    class Program
    {
        static CountryController bigBoss;
        static void Main(string[] args)
        {
            bigBoss = new CountryController(
                new Country("The United States", "North America", "Red", "White", "Blue"),
                new Country("Dogland", "Where the doggos live", "White", "Green", "Gray"), 
                new Country("Russia", "Europe/Asia", "White", "Blue", "Red"),
                new Country("Australia", "Dinosaur Island", "White", "Red", "NavyBlue"));
            bigBoss.WelcomeAction();
            do
            {
                bigBoss.SelectCountryAction();
            } while (Utilities.GetYesNoInput("Enter y(es) to continue or n(o) to exit: "));
        }
    }
}
