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
            double total = 0;
            double payment = 0;
            double totalChange;
            double change;

            // coin counters for chnage
            int penny = 0;
            int nickel = 0;
            int dime = 0;
            int quarter = 0;
            int dollar = 0;
            int fiveDollar = 0;
            int tenDollar = 0;
            int twentyDollar = 0;

            // temp float variables to be truncated after division
            double pennyTemp;
            double nickelTemp;
            double dimeTemp;
            double quarterTemp;
            double dollarTemp;
            double fiveTemp;
            double tenTemp;
            double twentyTemp;
            #endregion

            #region Get inputs
            // input verification
            string input1;
            string input2;
            bool goodInput1 = false;
            bool goodInput2 = false;
            // get total from user
            while (goodInput1 == false)
            {
                Console.WriteLine("Dollar amount of purchase (ex: 14.25)");
                input1 = Console.ReadLine();
                goodInput1 = double.TryParse(input1, out total);
                if (!goodInput1)
                    Console.WriteLine("Invalid input");
            }
            
            // get payment from user
            
            while (goodInput2 == false)
            {
                Console.WriteLine("Dollar amount the customer gave");
                input2 = Console.ReadLine();
                goodInput2 = double.TryParse(input2, out payment);
                if (payment < total)
                {
                    goodInput2 = false;
                    Console.WriteLine("The customer did not give enough moeny to cover the bill");
                }
            }

            // calculate change
            totalChange = payment - total;
            change = totalChange;
            #endregion

            // split leftover change into dollar amounts then coin amounts
            // casting to int from double whenever truncation is required
            // this allows me to skip having to manually truncate each "chnage" amount when 
            // converting to an integer for the final output. However, it forces me to use a temp variable
            // to do the calculation first, then cast into an integer, so there is a trade off
            #region Calculate Dollar Returns
            while (change > 1)
            {
                if (change >= 20)
                {
                    twentyTemp = change / 20;
                    twentyDollar = (int)twentyTemp;
                    change %= 20;
                    change = Math.Round(change, 2);
                }
                else if (change >= 10)
                {
                    tenTemp = change / 10;
                    tenDollar = (int)tenTemp;
                    change %= 10;
                    change = Math.Round(change, 2);
                }
                else if (change >= 5)
                {
                    fiveTemp = change / 5;
                    fiveDollar = (int)fiveTemp;
                    change %= 5;
                    change = Math.Round(change, 2);
                }
                else
                {
                    dollarTemp = change / 1;
                    dollar = (int)dollarTemp;
                    change %= 1;
                    change = Math.Round(change, 2);
                    break;
                }
                
            }
            #endregion

            // calculate amount of each coin type to be returned to customer
            #region Calculate Coin Returns
            while (change > 0.00)
            {
                if (change >= .25)
                {
                    quarterTemp = change / .25;
                    quarter = (int)quarterTemp;
                    change %= .25;
                    change = Math.Round(change, 2);
                }
                else if (change >= .1)
                {
                    dimeTemp = change / .1;
                    dime = (int)dimeTemp;
                    change %= .1;
                    change = Math.Round(change, 2);
                }
                else if (change >= .05)
                {
                    nickelTemp = change / .05;
                    nickel = (int)nickelTemp;
                    change %= .05;
                    change = Math.Round(change, 2);
                }
                else
                {
                    pennyTemp = change / .01;
                    penny = (int)pennyTemp;
                    change %= .01;
                    break;
                }
                
            }
            #endregion

            #region Output dollar and coin returns
            Console.WriteLine();
            Console.WriteLine("total change due back: " + totalChange.ToString());
            Console.WriteLine();
            if (twentyDollar >= 1)
                Console.WriteLine(twentyDollar.ToString() + ": Twenty dollar bill(s)");
            if (tenDollar >= 1)
                Console.WriteLine(tenDollar.ToString() + ": Ten dollar bill(s)");
            if (fiveDollar >= 1)
                Console.WriteLine(fiveDollar.ToString() + ": Five dollar bill(s)");
            if (dollar >= 1)
                Console.WriteLine(dollar.ToString() + ": One dollar bill(s)");
            if (quarter >= 1)
                Console.WriteLine(quarter.ToString() + ": quarter(s)");
            if (dime >= 1)
                Console.WriteLine(dime.ToString() + ": dime(s)");
            if (nickel >= 1)
                Console.WriteLine(nickel.ToString() + ": nickel(s)");
            if (penny >= 1)
                Console.WriteLine(penny.ToString() + ": penny(s)");
            Console.ReadLine();
            #endregion 
        }
    }
}