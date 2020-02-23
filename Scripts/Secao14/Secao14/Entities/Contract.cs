using System;
using System.Globalization;
using System.Collections.Generic;

namespace Secao14.Entities
{
    class Contract
    {

        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public double TotalValue { get; private set; }
        public List<Installments> Installments { get; set; }

        public Contract(int number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            Installments = new List<Installments>();
        }

        public void AddInstallment(Installments installment)
        {
            Installments.Add(installment);
        }

        public override string ToString()
        {
            string installmentString = "";
            foreach (Installments installment in Installments)
            {
                installmentString += installment.ToString() + '\n';
            }
            return installmentString;
        }
    }
}
