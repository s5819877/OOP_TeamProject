using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject.Room
{
    // 추상 클래스 1 + 다중 인터페이스
    public abstract class Room : IReservable, IComparable<Room>, IDisplayable
    {
        // private 필드(캡슐화) / private에는 언더바를 붙임
        private string _roomId = string.Empty; // 객실 번호 / 빈 문자열로 초기화
        private double _pricePerNight; // 1박 가격
        private bool _isReserved; // 예약 여부
        private int _floor; // 층수

        // 속성(Property) / public과 구분하기 위함
        public string RoomId
        {
            get => _roomId;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("객실 ID는 비어 있을 수 없습니다.");
                _roomId = value;
            }
        }

        public double PricePerNight
        {
            get => _pricePerNight;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("가격은 0 이상이어야 합니다.");
                _pricePerNight = value;
            }
        }

        public bool IsReserved
        {
            get => _isReserved;
            protected set => _isReserved = value;
        }

        public int Floor
        {
            get => _floor;
            protected set => _floor = value;
        }

        // 추상 속성
        public abstract string RoomType { get; }
        public abstract int MaxGuests { get; }

        // 생성자
        protected Room(string roomId, double pricePerNight, int floor)
        {
            RoomId = roomId;
            PricePerNight = pricePerNight;
            Floor = floor;
            _isReserved = false;
        }

        // 추상 메서드
        public abstract double CalculateTotalPrice(int nights);
        public abstract string GetAmenities();

        // virtual 메서드
        public virtual bool IsAvailable(DateTime checkIn, DateTime checkOut)
        {
            return !IsReserved && checkIn < checkOut && checkIn >= DateTime.Today;
        }

        public virtual bool Reserve(DateTime checkIn, DateTime checkOut)
        {
            if (!IsAvailable(checkIn, checkOut))
                return false;
            IsReserved = true;
            return true;
        }

        public virtual bool CancelReservation()
        {
            if (!IsReserved)
                return false;
            IsReserved = false;
            return true;
        }

        public int CompareTo(Room? other)
        {
            if (other == null)
                return 1;
            return PricePerNight.CompareTo(other.PricePerNight);
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"  ID: {RoomId} | 종류: {RoomType} | {Floor}층");
            Console.WriteLine($"  1박 가격: {PricePerNight:N0}원 | 최대 인원: {MaxGuests}명");
            Console.WriteLine($"  상태: {(IsReserved ? "예약됨" : "예약 가능")}");
        }

        public virtual string GetSummary()
        {
            return $"{RoomId} ({RoomType}) - {PricePerNight:N0}원/박 [{(IsReserved ? "예약됨" : "가능")}]";
        }

        public override string ToString() => GetSummary();
    }
}
