using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class CardPayment : Payment
    {
        // 필드
        private int installment; // 할부 개월 (0이면 일시불)

        // 속성
        public int Installment
        {
            get { return installment; } // 할부 개월 반환
        }

        // 생성자
        public CardPayment(double amount, string bookingType, int installment)
            : base(amount, bookingType) // 카드는 워크인/예약 둘 다 가능
        {
            this.installment = installment; // 할부 개월 초기화
        }

        // 추상 메서드 구현
        public override void Pay()
        {
            IsPaid = true; // 결제 완료
            if (installment == 0)
            {
                Console.WriteLine("카드 일시불 결제 완료 / 결제 금액: " + Amount + "원"); // 일시불 결제
            }
            else
            {
                Console.WriteLine("카드 할부 결제 완료 / 결제 금액: " + Amount + "원 / " + installment + "개월 할부"); // 할부 결제
            }
        }

        public override string ToString()
        {
            return "카드 결제 / " + GetBasicInfo(); // protected 메서드 호출
        }

        // 메서드 오버라이딩
        public override void PrintReceipt()
        {
            Console.WriteLine(ToString());                                                           // 기본 정보 출력
            Console.WriteLine("할부: " + (installment == 0 ? "일시불" : installment + "개월 할부")); // 추가 정보 출력
        }
    }
}
