using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCLab
{
    class Country
    {
        private List<string> _colors;
        private List<ConsoleColor> _displayColors;

        public string Name { get; protected set; }
        public string Continent { get; protected set; }
        public List<ConsoleColor> DisplayColors { get { return _displayColors; } }
        public List<string> Colors
        {
            get
            {
                return _colors;
            }
            protected set
            {
                _colors = value;
                _displayColors = new List<ConsoleColor>();
                foreach (string s in value)
                {
                    try
                    {
                        _displayColors.Add((ConsoleColor)Enum.Parse(typeof(ConsoleColor), s));
                    }
                    catch
                    {
                        _displayColors.Add(ConsoleColor.White);
                    }
                }
            }
        }

        public Country(string name, string continent, List<string> colors)
        {
            Name = name;
            Continent = continent;
            
            Colors = colors;
        }

        public Country(string name, string continent, params string[] colors)
        {
            Name = name;
            Continent = continent;
            Colors = colors.ToList();
        }
    }
}
