using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class SuiteRoom : Room
    {
        // 필드
        private bool hasPrivatePool; // 프라이빗 풀 여부

        // 속성
        public bool HasPrivatePool
        {
            get { return hasPrivatePool; } // 프라이빗 풀 여부 반환
        }

        // 생성자
        public SuiteRoom(int roomNumber, bool hasBreakfast, bool hasPrivatePool)
            // base 키워드
            : base(roomNumber, 400000, "Suite", hasBreakfast, 6) // 가격, 최대인원 고정
        {
            this.hasPrivatePool = hasPrivatePool; // 프라이빗 풀 여부 초기화
        }

        // 추상 메서드 구현
        public override string ToString()
        {
            return "[스위트룸] " + RoomNumber + "호 / 1박 " + Price + "원 / 최대 " + MaxGuests + "인 / 프라이빗 풀: " + (hasPrivatePool ? "O" : "X"); // 방 정보 출력
        }

        public override string GetInfo()
        {
            return "킹 침대 1개 / 더블 침대 4개 / 샤워부스 / 욕조 / 프라이빗 풀: " + (hasPrivatePool ? "O" : "X"); // 스위트룸 특징 출력
        }
    }
}
