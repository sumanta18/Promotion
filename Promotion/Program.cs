using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Purchase = new Dictionary<string, int>();
            Console.WriteLine("How many Items:");
            int items = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<items;i++)
            {
                Console.WriteLine("Enter the SKUID:");
                string item = Console.ReadLine().ToUpper();
                Console.WriteLine("Quantity of:"+ item);
                int itemquantity = Convert.ToInt32( Console.ReadLine());
                Purchase.Add(item, itemquantity);
            }
            int TotalPurchase = 0;
            Promotioncalculation PromoCal = new Promotioncalculation();
            int itemA = 0;
            int itemB = 0;
            int itemC = 0;
            int itemD = 0;
            foreach (KeyValuePair<string, int> pur in Purchase)
            {
                Console.WriteLine("Key: {0}, Value: {1}", pur.Key, pur.Value);

                if (pur.Key=="A")
                {
                    itemA=pur.Value;
                }
                else if (pur.Key == "B")
                {
                    itemB=pur.Value;
                }
               else if (pur.Key == "C")
                {
                    itemC=pur.Value;
                }
                else if (pur.Key == "D")
                {
                    itemD=pur.Value;
                }
            }

            TotalPurchase += PromoCal.PromotionA(itemA);
            TotalPurchase += PromoCal.PromotionB(itemB);
            TotalPurchase += PromoCal.PromotionCD(itemC, itemD);
            Console.WriteLine("Total: " + TotalPurchase);

        }

        
    }

    class Promotioncalculation
    {
        public enum SKUID
        {
            A = 50,
            B = 30,
            C = 20,
            D = 15
        }
        public int PromotionA(int countofProdA)
        {
            int diff1 = countofProdA / 3;
            int diff2 = countofProdA % 3;
            int sum1 = diff1 * 130;
            int sum2 = diff2 * Convert.ToInt32(SKUID.A);
            int result = sum1 + sum2;

            return result;
        }
        public int PromotionB(int countofProdB)
        {
            int diff1 = countofProdB / 2;
            int diff2 = countofProdB % 2;
            int sum1 = diff1 * 45;
            int sum2 = diff2 * Convert.ToInt32(SKUID.B);
            ;
            int result = sum1 + sum2;

            return result;
        }
        public int PromotionCD(int countofProdC, int countofProdD)
        {
            int result;
            int sum1;
            int sum2;
            if (countofProdC > countofProdD)
            {
                sum1 = countofProdD * 30;
                sum2 = countofProdC - countofProdD;
                sum2 *= Convert.ToInt32(SKUID.C); ;
                result = sum1 + sum2;
            }
            else
            {
                sum1 = countofProdC * 30;
                sum2 = countofProdD - countofProdC;
                sum2 *= Convert.ToInt32(SKUID.D); ;
                result = sum1 + sum2;
            }

            return result;
        }
    }

}
