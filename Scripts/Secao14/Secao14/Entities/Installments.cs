using System;
using System.Globalization;

namespace Secao14.Entities
{
    class Installments
    {

        public DateTime DueDate { get; set; }
        public double Amount { get; set; }

        public Installments(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return DueDate.ToShortDateString() + " - " + Amount.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
