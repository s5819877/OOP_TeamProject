using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class Guest : IValidatable
    {
        // 필드
        private string name;           // 이름
        private int age;               // 나이
        private string phoneNumber;    // 전화번호
        private int numberOfGuests;    // 인원

        // 속성
        public string Name
        {
            get { return name; }           // 이름 반환
        }

        public int Age
        {
            get { return age; }            // 나이 반환
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }    // 전화번호 반환
        }

        public int NumberOfGuests
        {
            get { return numberOfGuests; } // 인원 반환
        }

        // 생성자
        public Guest(string name, int age, string phoneNumber, int numberOfGuests)
        {
            this.name = name;                     // 이름 초기화
            this.age = age;                       // 나이 초기화
            this.phoneNumber = phoneNumber;        // 전화번호 초기화
            this.numberOfGuests = numberOfGuests;  // 인원 초기화
        }

        // out 키워드
        public bool Validate(out string errorMessage)
        {
            if (name == "")
            {
                errorMessage = "이름을 입력해주세요.";
                return false;
            }
            if (age < 0)
            {
                errorMessage = "나이가 올바르지 않습니다.";
                return false;
            }
            if (age < 18)
            {
                errorMessage = "미성년자는 예약할 수 없습니다.";
                return false;
            }
            if (phoneNumber == "")
            {
                errorMessage = "전화번호를 입력해주세요.";
                return false;
            }
            errorMessage = ""; // 오류 없음
            return true;
        }

        // 메서드 오버라이딩 (object 클래스)
        public override string ToString()
        {
            return "이름: " + name +
                   " / 나이: " + age +
                   " / 전화번호: " + phoneNumber +
                   " / 인원: " + numberOfGuests + "명"; // 손님 정보 출력
        }
    }
}
