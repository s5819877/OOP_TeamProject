using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class StandardRoom : Room
    {
        // 필드
        private string bedType;      // 침대 타입 (더블, 트윈)
        private string bathroomType; // 욕실 타입 (샤워부스, 욕조)

        // 속성
        public string BedType
        {
            get { return bedType; }
        }

        public string BathroomType
        {
            get { return bathroomType; }
        }

        // 생성자
        public StandardRoom(int roomNumber, bool hasBreakfast, string bedType, string bathroomType)
            // base 키워드
            : base(roomNumber, 100000, "Standard", hasBreakfast, 2) // 가격이랑 최대인원은 스탠다드룸 고정
        {
            this.bedType = bedType;           // 침대 타입 초기화
            this.bathroomType = bathroomType; // 욕실 타입 초기화
        }

        // 추상 메서드 구현
        public override string ToString()
        {
            return "[스탠다드룸] " + RoomNumber + "호 / 1박 " + Price + "원 / 최대 " + MaxGuests + "인"; // 방 정보 출력
        }

        public override string GetInfo()
        {
            return "침대 타입: " + bedType + " / 욕실 타입: " + bathroomType; // 스탠다드룸 특징 출력
        }
    }
}
