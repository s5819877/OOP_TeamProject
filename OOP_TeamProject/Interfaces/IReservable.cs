using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject.Interfaces
{
    public interface IReservable // 직접 정의한 인터페이스 2
    {
        bool IsAvailable(DateTime checkIn, DateTime checkOut); // 예약 가능 확인
        bool Reserve(DateTime checkIn, DateTime checkOut); // 예약 실행
        bool CancelReservation(); // 예약 취소
    }
}
