using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class DeluxeRoom : Room
    {
        // 필드
        private string bedType;      // 침대 타입 (킹, 트윈)
        private string bathroomType; // 욕실 타입 (샤워부스, 욕조)
        private bool hasJacuzzi;     // 자쿠지 여부

        // 속성
        public string BedType
        {
            get { return bedType; }      // 침대 타입 반환
        }

        public string BathroomType
        {
            get { return bathroomType; } // 욕실 타입 반환
        }

        public bool HasJacuzzi
        {
            get { return hasJacuzzi; }   // 자쿠지 여부 반환
        }

        // 생성자
        public DeluxeRoom(int roomNumber, bool hasBreakfast, string bedType, string bathroomType, bool hasJacuzzi)
            // base 키워드
            : base(roomNumber, hasJacuzzi ? 250000 : 200000, "Deluxe", hasBreakfast, 4) // 자쿠지 있으면 130000 없으면 100000
        {
            this.bedType = bedType;           // 침대 타입 초기화
            this.bathroomType = bathroomType; // 욕실 타입 초기화
            this.hasJacuzzi = hasJacuzzi;     // 자쿠지 여부 초기화
        }

        // 추상 메서드 구현
        public override string ToString()
        {
            return "[디럭스룸] " + RoomNumber + "호 / 1박 " + Price + "원 / 최대 " + MaxGuests + "인 / " + bedType + " / " + bathroomType + " / 자쿠지: " + (hasJacuzzi ? "O" : "X"); // 방 정보 출력
        }

        public override string GetInfo()
        {
            return "침대 타입: " + bedType + " / 욕실 타입: " + bathroomType + " / 자쿠지: " + (hasJacuzzi ? "O" : "X"); // 디럭스룸 특징 출력
        }
    }
}
