using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OOP_TeamProject
{
    class HouseKeeper : Staff
    {
        // 필드
        private string duty; // 담당 업무 (방 청소, 빨래)

        // 속성
        public string Duty
        {
            get { return duty; } // 담당 업무 반환
        }

        // 생성자
        public HouseKeeper(string name, int age, string phoneNumber, double workHours, double salary, string duty)
            : base(name, age, phoneNumber, workHours, salary) // Staff 생성자 호출
        {
            this.duty = duty; // 담당 업무 초기화
        }

        // 추상 메서드
        public override void DoWork()
        {
            Console.WriteLine(Name + " 직원이 " + duty + " 업무를 수행합니다."); // 담당 업무 수행
        }

        public override string ToString()
        {
            return "하우스키퍼 / " + GetBasicInfo(); // protected 메서드 호출
        }

        // 메서드 오버라이딩
        public override void PrintInfo()
        {
            Console.WriteLine(ToString());           // 기본 정보 출력
            Console.WriteLine("담당 업무: " + duty); // 추가 정보 출력
        }
    }
}
