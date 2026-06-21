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
}
