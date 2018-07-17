using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cal
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DateTime test = new DateTime(2018, 1, 1);
            for (int i = 0; i < 12; i++)
            {
                MonthCalendar.PrintMonth(test);
                test = test.AddMonths(1);
            }
            YearCalendar.PrintYear(2018);
        }

        
    }
}
