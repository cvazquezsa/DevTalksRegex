using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevTalksRegex
{
    internal class ParsingObject
    {
        internal static void GetHeroes()
        {
            string text = "Name: Thanos|Age: 1000 years|Type: Villian|Name: Dr. Steven Strange|Age: 36 years|Type: Heroe|Name: Natasha Romanoff|Age: 31 years|Type: Heroe";

            Regex regex = new Regex(@"Name: (?'Name'[^|:]+)\|Age: (?'Age'\d+) years\|Type: (?'Type'Villian|Heroe)");

            var matches = regex.Matches(text);

            Console.WriteLine("***** BEGIN Parsing Object EXAMPLE *****");

            foreach (Match match in matches)
            {
                MarvelCharacter character = new MarvelCharacter()
                {
                    Name = match.Groups["Name"].Value,
                    Age = Int32.Parse(match.Groups["Age"].Value),
                    Type = Enum.Parse<CharacterType>(match.Groups["Type"].Value)
                };

                Console.WriteLine(character);
            }

            Console.WriteLine("***** END Parsing Object EXAMPLE *****");

        }


    }

    internal class MarvelCharacter
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CharacterType Type { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Age: {Age}");
            sb.AppendLine($"Type: {Type}");

            return sb.ToString();
        }
    }

    internal enum CharacterType
    {
        Heroe,
        Villian
    }
}
