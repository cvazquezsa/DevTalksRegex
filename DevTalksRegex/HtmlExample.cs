using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevTalksRegex
{
    internal class HtmlExample
    {
        public static void printTagContent()
        {
            Console.WriteLine("***** BEGIN HTML EXAMPLE *****");
            Console.WriteLine();
            
            string html = @"<table>
        <tr>
            <td class=""first"">text 1</td>
            <TD>text 2</TD>
        </tr>
        <tr>
            <td>text trés</td>
            <td>
                text 4 first line
                text 4 second line
            </td>
            <td></td>
        </tr>
    </table>";

            Regex regex = new Regex(@"<td[^>]*>(?'content'[^<]+)</td>", RegexOptions.IgnoreCase);


            var matches = regex.Matches(html);

            foreach (Match match in matches)
            {
                string value = match.Groups["content"].Value;
                Console.WriteLine(value);
            }

            Console.WriteLine("***** END HTML EXAMPLE *****");
        }
    }
}
