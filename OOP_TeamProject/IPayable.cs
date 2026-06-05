using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    interface IPayable
    {
        void Pay();           // 결제
        bool IsPaid { get; }  // 결제 완료 여부
    }
}
