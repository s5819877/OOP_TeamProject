using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    // 추상 클래스 1 + 다중 인터페이스(표준 인터페이스, 인터페이스)
    abstract class Room : IComparable<Room>, IBookable
    {
        // 필드
        private int roomNumber;      // 방 번호
        private double price;        // 가격
        private string roomType;     // 방 타입
        private bool isAvailable;    // 예약 가능 여부
        private bool hasBreakfast;   // 조식 여부
        private int maxGuests;   // 최대 인원

        // 속성 (캡슐화)
        public int RoomNumber
        {
            get { return roomNumber; }
        }

        public double Price
        {
            get { return hasBreakfast ? price + (20000 * maxGuests) : price; } // 조식 있으면 1인당 20000원 추가
        }

        public string RoomType
        {
            get { return roomType; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; } // 예약/취소 때 변경 가능
        }

        public bool HasBreakfast
        {
            get { return hasBreakfast; }
            set { hasBreakfast = value; } // 예약 때 선택 가능
        }

        public int MaxGuests
        {
            get { return maxGuests; }
        }

        // 생성자
        public Room(int roomNumber, double price, string roomType, bool hasBreakfast, int maxGuests)
        {
            this.roomNumber = roomNumber;  // 방 번호 초기화
            this.price = price;            // 가격 초기화
            this.roomType = roomType;      // 방 타입 초기화
            this.isAvailable = true;       // 처음엔 예약 가능 상태
            this.hasBreakfast = hasBreakfast; // 조식 여부 초기화
            this.maxGuests = maxGuests;     // 최대 인원 초기화
        }

        // 표준 인터페이스 구현
        public int CompareTo(Room other)
        {
            return this.Price.CompareTo(other.Price); // 가격순으로 비교
        }

        // 인터페이스 구현
        public void Book()
        {
            IsAvailable = false; // 예약 중으로 변경
        }

        public void Cancel()
        {
            IsAvailable = true; // 예약 가능으로 변경
        }

        // protected 멤버
        protected string GetBasicInfo()
        {
            return RoomNumber + "호 / 1박 " + Price + "원 / 최대 " + MaxGuests + "인"; // 기본 정보 반환
        }

        // 추상 메서드 (자식이 반드시 구현해야 함)
        public abstract override string ToString(); // 방 기본 정보 출력

        // 메서드 오버라이딩
        public virtual string GetInfo()
        {
            return "상세 정보 없음"; // 기본 구현 / 방 타입별 특징 설명
        }          
    }
}
