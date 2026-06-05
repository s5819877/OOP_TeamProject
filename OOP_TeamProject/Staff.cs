using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    // 추상 클래스 2
    abstract class Staff
    {
        // 필드
        private string name;        // 이름
        private int age;            // 나이
        private string phoneNumber; // 전화번호
        private double workHours;   // 일하는 시간
        private double salary;      // 월급

        // 속성
        public string Name
        {
            get { return name; }        // 이름 반환
        }

        public int Age
        {
            get { return age; }         // 나이 반환
        }

        public string PhoneNumber
        {
            get { return phoneNumber; } // 전화번호 반환
        }

        public double WorkHours
        {
            get { return workHours; }   // 일하는 시간 반환
        }

        public double Salary
        {
            get { return salary; }      // 월급 반환
        }

        // 생성자
        public Staff(string name, int age, string phoneNumber, double workHours, double salary)
        {
            this.name = name;               // 이름 초기화
            this.age = age;                 // 나이 초기화
            this.phoneNumber = phoneNumber; // 전화번호 초기화
            this.workHours = workHours;     // 일하는 시간 초기화
            this.salary = salary;           // 월급 초기화
        }

        // 추상 메서드
        public abstract void DoWork(); // 하는 일 (자식 클래스마다 다르게 구현)
        public abstract override string ToString(); // 직원 기본 정보 출력

        // protected 멤버
        protected string GetBasicInfo()
        {
            return Name + " / 나이: " + Age + " / 전화번호: " + PhoneNumber; // 기본 정보 반환
        }

        // 메서드 오버라이딩
        public virtual void PrintInfo()
        {
            Console.WriteLine("상세 정보 없음"); // 기본 구현 / 직원 상세 정보
        }
    }
}
