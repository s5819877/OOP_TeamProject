using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    // 추상 클래스 3 + 인터페이스
    abstract class Payment : IPayable
    {
        // 필드
        private double amount;      // 결제 금액
        private DateTime payDate;   // 결제 날짜
        private bool isPaid;        // 결제 완료 여부
        private string bookingType;  // 예약 방식 (워크인, 예약)

        // 속성
        public double Amount
        {
            get { return amount; }  // 결제 금액 반환
        }

        public DateTime PayDate
        {
            get { return payDate; } // 결제 날짜 반환
        }

        public bool IsPaid
        {
            get { return isPaid; }  // 결제 완료 여부 반환
            set { isPaid = value; } // 결제 완료 여부 변경 가능
        }

        public string BookingType
        {
            get { return bookingType; }  // 예약 방식 반환
        }

        // 생성자
        public Payment(double amount, string bookingType)
        {
            this.amount = amount;            // 결제 금액 초기화
            this.payDate = DateTime.Now;     // 결제 날짜는 현재 날짜
            this.isPaid = false;             // 처음엔 결제 미완료 상태
            this.bookingType = bookingType;  // 예약 방식 초기화
        }

        // 추상 메서드 (자식 클래스마다 다르게 구현)
        public abstract void Pay();                 // 결제 
        public abstract override string ToString(); // 결제 정보 출력 

        // protected 멤버
        protected string GetBasicInfo()
        {
            return "결제 금액: " + Amount + "원 / 결제 날짜: " + PayDate.ToString("yyyy-MM-dd") + " / 결제 완료: " + (IsPaid ? "O" : "X"); // 기본 정보 반환
        }

        // 메서드 오버라이딩
        public virtual void PrintReceipt()
        {
            Console.WriteLine("상세 정보 없음"); // 기본 구현
        }
    }
}
