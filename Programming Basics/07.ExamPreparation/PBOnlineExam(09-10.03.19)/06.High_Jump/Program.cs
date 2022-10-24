using System;

namespace _06.High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int desiredHeight = int.Parse(Console.ReadLine());

            bool isFaild = false;
            int jumpsCount = 0;
            int lastHeight = 0;
            for (int currentJumpTarget = desiredHeight - 30; currentJumpTarget <= desiredHeight; currentJumpTarget += 5)
            {
                lastHeight = currentJumpTarget;
                int currentActualJump = int.Parse(Console.ReadLine());
                jumpsCount++;

                int currentJumpFailsCount = 0;
                while (currentActualJump <= currentJumpTarget)
                {
                    currentJumpFailsCount++;

                    if (currentJumpFailsCount == 3)
                    {
                        isFaild = true;
                        break;
                    }

                    currentActualJump = int.Parse(Console.ReadLine());
                    jumpsCount++;
                }

                if (isFaild)
                {
                    break;
                }
            }

            if (isFaild)
            {
                Console.WriteLine($"Tihomir failed at {lastHeight}cm after {jumpsCount} jumps.");

            }
            else
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {lastHeight}cm after {jumpsCount} jumps.");
            }
        }
    }
}
