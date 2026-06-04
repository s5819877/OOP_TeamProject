using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    // 이미 예약된 방 예약 시도
    class RoomAlreadyBookedException : Exception
    {
        public RoomAlreadyBookedException(int roomNumber)
            : base(roomNumber + "호는 이미 예약된 방입니다.")
        {
        }
    }

    // 현재 날짜 이전 날짜 예약 시도
    class InvalidDateException : Exception
    {
        public InvalidDateException()
            : base("현재 날짜 이전으로는 예약할 수 없습니다.")
        {
        }
    }

    // 체크인 날 아닌데 체크인 시도
    class InvalidCheckInException : Exception
    {
        public InvalidCheckInException()
            : base("체크인 날짜가 아닙니다.")
        {
        }
    }

    // 미성년자끼리만 예약 시도
    class MinorOnlyReservationException : Exception
    {
        public MinorOnlyReservationException()
            : base("미성년자끼리만 예약할 수 없습니다.")
        {
        }
    }

    // 결제 금액 부족
    class InvalidPaymentException : Exception
    {
        public InvalidPaymentException()
            : base("결제 금액이 부족합니다.")
        {
        }
    }

    // 존재하지 않는 방 번호 입력
    class RoomNotFoundException : Exception
    {
        public RoomNotFoundException(int roomNumber)
            : base(roomNumber + "호는 존재하지 않는 방입니다.")
        {
        }
    }

    // 존재하지 않는 예약 번호 입력
    class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException(string reservationId)
            : base(reservationId + "는 존재하지 않는 예약 번호입니다.")
        {
        }
    }
}
