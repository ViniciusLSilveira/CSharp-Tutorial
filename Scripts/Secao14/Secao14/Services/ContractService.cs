using System;
using Secao14.Entities;

namespace Secao14.Services
{
    class ContractService
    {

        private IOnlinePaymentService _OnlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _OnlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue/months;
            for (int i = 1; i <= months; i++)
            {
                DateTime dueDate = contract.Date.AddMonths(i);
                double updateQuota =  basicQuota + _OnlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updateQuota + _OnlinePaymentService.PaymentFee(updateQuota);
                contract.AddInstallment(new Installments(dueDate, fullQuota));
            }
        }

    }
}
