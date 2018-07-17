using System;
using System.Collections.Generic;

namespace cal
{
    class Program
    {
        private static readonly Dictionary<string, int> months = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "Jan", 1 },
            { "Feb", 2 },
            { "Mar",3 },
            {"Apr",4 },
            {"May",5 },
            {"Jun",6 },
            {"Jul",7 },
            {"Aug",8 },
            {"Sep",9 },
            {"Oct",10 },
            {"Nov",11 },
            {"Dec",12 },
            {"January",1 },
            {"February",2 },
            {"March",3 },
            {"April",4 },
            {"June",6 },
            {"July",7 },
            {"August",8 },
            {"September",9 },
            {"October",10 },
            {"November",11 },
            {"December", 12 },
        };
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                MonthCalendar.PrintMonth(DateTime.Now.Date);
            }
            else if (args.Length == 1)
            {
                if (int.TryParse(args[0], out int year))
                {
                    bool result = IsValidYear(year);
                    if (!result)
                        return;
                    YearCalendar.PrintYear(year);
                }
            }
            else if (args.Length == 2)
            {
                if (int.TryParse(args[1], out int year))
                {
                    bool result = IsValidYear(year);
                    if (!result)
                        return;
                }
                if (!months.TryGetValue(args[0], out int month))
                {
                    Console.WriteLine($"Unknown month argument {args[0]}");
                    return;
                }

                MonthCalendar.PrintMonth(new DateTime(year, month, 1));
            }
        }

        private static bool IsValidYear(int year)
        {
            if (year < 1 || year > 9998)
            {
                Console.WriteLine($"Unknown year argument {year}");
                return false;
            }

            return true;
        }
    }
}
