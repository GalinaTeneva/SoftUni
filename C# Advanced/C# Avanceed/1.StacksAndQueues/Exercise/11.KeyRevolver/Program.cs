using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForOneBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int bulletsInBarrel = gunBarrelSize;
            int firedBullets = 0;
            while (locksQueue.Count > 0 && bulletsStack.Count > 0)
            {
                int currLock = locksQueue.Peek();
                int currBullet = bulletsStack.Pop();

                bulletsInBarrel--;
                firedBullets++;

                if (currBullet > currLock)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }

                if (bulletsStack.Count > 0 && bulletsInBarrel == 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsInBarrel = gunBarrelSize;
                }
            }

            if (bulletsStack.Count == 0 && locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int moneyEarned = intelligenceValue - (firedBullets * priceForOneBullet);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
