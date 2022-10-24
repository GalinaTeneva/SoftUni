using System;

namespace _08.O__Time_For_The_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int timeDifference = (examHour * 60 + examMinutes) - (arrivalHour * 60 + arrivalMinutes);
            int hoursDifference = timeDifference / 60;
            int minutesDifference = timeDifference % 60;

            if (timeDifference <= 30 && timeDifference > 0)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{timeDifference} minutes before the start");
            }
            else if (timeDifference > 30)
            {
                Console.WriteLine("Early");
                if (hoursDifference == 0)
                {
                    Console.WriteLine($"{timeDifference} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{hoursDifference}:{minutesDifference:D2} hours before the start");
                }
            }
            else if (timeDifference < 0)
            {
                Console.WriteLine("Late");

                if (hoursDifference == 0)
                {
                    Console.WriteLine($"{Math.Abs(timeDifference)} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(hoursDifference)}:{Math.Abs(minutesDifference):D2} hours after the start");

                }
            }
            else
            {
                Console.WriteLine("On time");
            }
        }
    }
}
