using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    struct DateRange
    {
        public DateTime checkInDate;  // 체크인 날짜
        public DateTime checkOutDate; // 체크아웃 날짜

        public DateRange(DateTime checkInDate, DateTime checkOutDate)
        {
            this.checkInDate = checkInDate;   // 체크인 날짜 초기화
            this.checkOutDate = checkOutDate; // 체크아웃 날짜 초기화
        }

        public int GetNights()
        {
            return (checkOutDate - checkInDate).Days; // 숙박 일수 계산
        }
    }

    // 아직 구현 안 함 (안 쓸 수도)
    /*
    struct RoomInfo
    {
        public int roomNumber;   // 방 번호
        public string roomType;  // 방 타입
        public double price;     // 가격
    }

    struct GuestInfo
    {
        public string name;        // 이름
        public int age;            // 나이
        public string phoneNumber; // 전화번호
    }
    */
}
