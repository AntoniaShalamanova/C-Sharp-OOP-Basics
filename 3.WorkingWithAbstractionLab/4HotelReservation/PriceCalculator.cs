using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator
{
    public static class PriceCalculator
    {
        public static decimal Calculate(decimal pricePerDay,
            int daysCount,
            Season season,
            Discount discount)
        {
            decimal totalPrice = pricePerDay * (int)season * daysCount;

            return totalPrice -= totalPrice * (decimal)discount / 100;
        }
    }
}
