// Author: Tom Kugelman

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Register_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Data Members
            // user generated variables
            float total;
            float payment;
            float change;

            // coin counters for chnage
            int penny = 0;
            int dime = 0;
            int quarter = 0;
            int dollar = 0;

            // temp doubel variables to be truncated after division
            double pennyTemp;
            double dimeTemp;
            double quarterTemp;

            // Track the amoutn of change
            double cents = 0;
            #endregion

            // get total from user
            Console.WriteLine("Dollar amount of purchase (ex: 14.25)");
            total = float.Parse(Console.ReadLine());

            // get payment from user
            Console.WriteLine("Dollar amount the customer gave");
            payment = float.Parse(Console.ReadLine());

            // calculate change
            change = total - payment;

            // split leftover change into dollar amounts and coin amounts
            // casting to int from double whenever truncation is required
            if (change > 1)
            {
                cents = change % 1;

                dollar = (int)change;
            }
            else if (change > 0)
            {
                cents = change % 1;
            }
            else if (change == 0)
                Console.WriteLine("The customer gave exact change!");

            // calculate amount of each coin type to be returned to customer
            #region Calculate Coin Returns
            while (cents > 0)
            {
                if (cents > .25)
                {
                    quarterTemp = cents / .25;
                    quarter = (int)quarterTemp;
                    cents %= .25;
                }
                else if (cents > .1)
                {
                    dimeTemp = cents / .1;
                    dime = (int)dimeTemp;
                    cents %= .1;
                }
                else if (cents > .01)
                {
                    pennyTemp = cents / .01;
                    penny = (int)pennyTemp;
                    cents /= .01;
                }
            }
            #endregion 

            Console.WriteLine("total change due back: " + change.ToString());
            Console.WriteLine((dollar >= 1) ? dollar.ToString() + ": Dollars, " :
                (quarter >= 1) ? quarter.ToString() + ": Quarters, " : 
                (dime >= 1) ? dime.ToString() + ": Dimes, " :
                (penny >= 1) ? penny.ToString() + ": Pennies");

            Console.WriteLine((dollar >= 1) ? dollar.ToString() + ": Dollars, " : "";
        }
    }
}
