using System;

namespace cal
{
    internal static class YearCalendar
    {
        internal static void PrintYear(int year)
        {
            Console.WriteLine(CalHelper.GetYearStringLeftPadded(year.ToString()));
            CalHelper.PrintHeader(1);
            WriteQuarter(1, year);
            Console.WriteLine();
            Console.WriteLine();
            CalHelper.PrintHeader(2);
            WriteQuarter(2, year);
            Console.WriteLine();
            Console.WriteLine();
            CalHelper.PrintHeader(3);
            WriteQuarter(3, year);
            Console.WriteLine();
            Console.WriteLine();
            CalHelper.PrintHeader(4);
            WriteQuarter(4, year);
        }

        private static void WriteQuarter(int quarter, int year)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            ConsoleColor backGroundColor = Console.BackgroundColor;
            int? today = null;
            DateTime todaysDate = DateTime.Now.Date;
            HelperData[] helperDataArray = CalHelper.InitializeHelperData(quarter, year);
            if (year == todaysDate.Year)
            {
                if (todaysDate.Month >= helperDataArray[0].CurrentDate.Month && todaysDate.Month <= helperDataArray[0].CurrentDate.Month + 2)
                {
                    today = todaysDate.Day;
                }
            }
            while (ShouldContinue(helperDataArray))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (helperDataArray[i].CurrentDate > helperDataArray[i].EndDate)
                    {
                        Console.Write(new string(' ', 7 * 3));
                        Console.Write(" ");
                        continue;
                    }
                    int startPos = (int)helperDataArray[i].CurrentDate.DayOfWeek;
                    if (helperDataArray[i].CurrentDate.Day == 1)
                    {
                        if (startPos == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                        if (today.HasValue && today.Value == 1 && helperDataArray[i].CurrentDate.Month == todaysDate.Month)
                        {
                            CalHelper.InvertColor(foregroundColor, backGroundColor);
                        }
                        Console.Write("1".PadLeft(startPos * 3));
                        Console.Write(" ");
                        if (Console.BackgroundColor == foregroundColor)
                        {
                            CalHelper.ResetColor(foregroundColor, backGroundColor);
                        }
                        helperDataArray[i].CurrentDate = helperDataArray[i].CurrentDate.AddDays(1);
                        startPos++;
                    }
                    while (startPos < 7 && helperDataArray[i].CurrentDate <= helperDataArray[i].EndDate)
                    {
                        int startDay = helperDataArray[i].CurrentDate.Day;
                        if (today.HasValue && today.Value == startDay && helperDataArray[i].CurrentDate.Month == todaysDate.Month)
                        {
                            CalHelper.InvertColor(foregroundColor, backGroundColor);
                        }
                        Console.Write(startDay.ToString().PadLeft(2));
                        if (Console.BackgroundColor == foregroundColor)
                        {
                            CalHelper.ResetColor(foregroundColor, backGroundColor);
                        }
                        Console.Write(" ");
                        helperDataArray[i].CurrentDate = helperDataArray[i].CurrentDate.AddDays(1);
                        startPos++;
                    }
                    if (helperDataArray[i].CurrentDate > helperDataArray[i].EndDate)
                    {
                        Console.Write(new string(' ', (7 - startPos) * 3));
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static bool ShouldContinue(HelperData[] helperDataArray)
        {
            foreach (HelperData data in helperDataArray)
            {
                if (data.CurrentDate <= data.EndDate)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
