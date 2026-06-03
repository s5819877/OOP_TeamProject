using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class CashPayment : Payment
    {
        // 필드
        private double receivedAmount; // 받은 금액
        private double change;         // 거스름돈

        // 속성
        public double ReceivedAmount
        {
            get { return receivedAmount; } // 받은 금액 반환
        }

        public double Change
        {
            get { return change; }         // 거스름돈 반환
        }

        // 생성자
        public CashPayment(double amount, double receivedAmount)
            // base 키워드
            : base(amount, "워크인") // 현금은 워크인 고정
        {
            this.receivedAmount = receivedAmount;  // 받은 금액 초기화
            this.change = receivedAmount - amount; // 거스름돈 계산
        }

        // 추상 메서드 구현
        public override void Pay()
        {
            IsPaid = true; // 결제 완료
            Console.WriteLine("현금 결제 완료 / 받은 금액: " + receivedAmount + "원 / 거스름돈: " + change + "원");
        }

        public override string ToString()
        {
            return "현금 결제 / 결제 금액: " + Amount + "원 / 받은 금액: " + receivedAmount + "원 / 거스름돈: " + change + "원 / 결제 완료: " + (IsPaid ? "O" : "X"); // 현금 결제 정보 출력
        }
    }
}
