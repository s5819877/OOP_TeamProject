using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject.Interfaces
{
    public interface IPayable // 직접 정의한 인터페이스 1
    {
        double TotalPrice { get; } // 결제 총액
        bool ProcessPayment(double amount, string method); // 결제 수단
        string GetPaymentSummary(); // 영수증
    }
}
