using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OOP_TeamProject
{
    class Receptionist : Staff
    {
        // 필드
        private string language;  // 사용 가능 언어
        private string shift;     // 근무 교대 (오전, 오후, 야간)

        // 속성
        public string Language
        {
            get { return language; } // 사용 가능 언어 반환
        }

        public string Shift
        {
            get { return shift; }    // 근무 교대 반환
        }

        // 생성자
        public Receptionist(string name, int age, string phoneNumber, double workHours, double salary, string language, string shift)
            : base(name, age, phoneNumber, workHours, salary) // Staff 생성자 호출
        {
            this.language = language; // 사용 가능 언어 초기화
            this.shift = shift;       // 근무 교대 초기화
        }

        // 추상 메서드
        public override void DoWork() // 너무 간단함
        {
            Console.WriteLine(Name + " 직원이 프런트 데스크에서 근무합니다."); // 프런트 근무
        }

        // 메서드
        public void CheckIn(Reservation reservation)
        {
            Console.WriteLine(reservation.Guest.Name + " 손님 체크인 처리 완료"); // 체크인 처리
            // TODO : 체크인 과정 채우기
        }

        public void CheckOut(Reservation reservation)
        {
            Console.WriteLine(reservation.Guest.Name + " 손님 체크아웃 처리 완료"); // 체크아웃 처리
            // TODO : 체크아웃 과정 채우기
        }

        // 추상 메서드
        public override string ToString()
        {
            return "리셉션니스트 / 이름: " + Name +
                   " / 나이: " + Age +
                   " / 전화번호: " + PhoneNumber +
                   " / 근무시간: " + WorkHours +
                   " / 월급: " + Salary +
                   " / 언어: " + language +
                   " / 근무교대: " + shift; // 리셉션니스트 정보 출력
        }
    }
}
