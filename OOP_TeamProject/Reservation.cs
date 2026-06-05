using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class Reservation : IValidatable
    {
        // 필드
        private static Random random = new Random();    // 랜덤 객체 (모든 예약이 공유)

        private string reservationId;                   // 예약 번호
        private DateTime reservationDate;               // 예약 날짜
        private DateRange stayPeriod;                   // 체크인/아웃 날짜 묶음
        private Room room;                              // 방 정보
        private Guest guest;                            // 손님 정보
        private Payment payment;                        // 결제 정보
        private double totalPrice;                      // 총 금액

        // 속성
        public string ReservationId
        {
            get { return reservationId; }               // 예약 번호 반환
        }

        public DateTime ReservationDate
        {
            get { return reservationDate; }             // 예약 날짜 반환
        }

        public DateTime CheckInDate
        {
            get { return stayPeriod.checkInDate; }      // 체크인 날짜 반환
        }

        public DateTime CheckOutDate
        {
            get { return stayPeriod.checkOutDate; }     // 체크아웃 날짜 반환
        }

        public DateRange StayPeriod
        {
            get { return stayPeriod; }                  // 체크인/아웃 날짜 묶음 반환
        }

        public Room Room
        {
            get { return room; }                        // 방 정보 반환
        }

        public Guest Guest
        {
            get { return guest; }                       // 손님 정보 반환
        }

        public Payment Payment
        {
            get { return payment; }                     // 결제 정보 반환
        }

        public double TotalPrice
        {
            get { return totalPrice; }                  // 총 금액 반환
        }

        // 생성자
        public Reservation(Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate, Payment payment)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // 사용할 문자 목록
            string id = "";
            for (int i = 0; i < 8; i++)
            {
                id += chars[random.Next(0, chars.Length)]; // 랜덤으로 하나씩 추가
            }
            this.reservationId = id;                                    // 예약 번호 초기화
            this.reservationDate = DateTime.Now;                        // 예약 날짜는 현재 날짜
            this.stayPeriod = new DateRange(checkInDate, checkOutDate); // 체크인/아웃 날짜 묶음
            this.room = room;                                           // 방 정보 초기화
            this.guest = guest;                                         // 손님 정보 초기화
            this.payment = payment;                                     // 결제 정보 초기화
            this.totalPrice = stayPeriod.GetNights() * room.Price;      // 총 금액 계산
        }

        // out 키워드
        public bool Validate(out string errorMessage)
        {
            if (stayPeriod.checkInDate < DateTime.Today)
            {
                errorMessage = "체크인 날짜가 오늘 이전입니다.";
                return false;
            }
            if (stayPeriod.checkOutDate <= stayPeriod.checkInDate)
            {
                errorMessage = "체크아웃 날짜가 체크인 날짜보다 앞입니다.";
                return false;
            }
            if (guest.NumberOfGuests > room.MaxGuests)
            {
                errorMessage = "인원이 최대 인원을 초과합니다.";
                return false;
            }
            errorMessage = ""; // 오류 없음
            return true;
        }

        // 메서드 오버라이딩 (object 클래스)
        public override string ToString()
        {
            return "예약번호: " + reservationId +
                   " / 예약날짜: " + reservationDate.ToString("yyyy-MM-dd") +
                   " / 체크인: " + stayPeriod.checkInDate.ToString("yyyy-MM-dd") +
                   " / 체크아웃: " + stayPeriod.checkOutDate.ToString("yyyy-MM-dd") +
                   " / 방: " + room.ToString() +
                   " / 총 금액: " + totalPrice + "원"; // 예약 정보 출력
        }
    }
}
