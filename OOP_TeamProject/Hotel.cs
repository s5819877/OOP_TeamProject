using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class Hotel
    {
        // 필드 (클래스가 가지고 있는 데이터)
        private Repository<Room> rooms;                // 객실 목록
        private Repository<Reservation> reservations;  // 예약 목록
        private Repository<Staff> staffs;              // 직원 목록

        // 생성자 (객체 만들 때 실행되는 초기화 코드)
        public Hotel()
        {
            this.rooms = new Repository<Room>();               // 객실 저장소 초기화
            this.reservations = new Repository<Reservation>(); // 예약 저장소 초기화
            this.staffs = new Repository<Staff>();             // 직원 저장소 초기화

            // 스탠다드룸 등록 (101 ~ 204호)
            rooms.Add(new StandardRoom(101, false, "더블", "샤워부스"));
            rooms.Add(new StandardRoom(102, false, "더블", "욕조"));
            rooms.Add(new StandardRoom(103, false, "트윈", "샤워부스"));
            rooms.Add(new StandardRoom(104, false, "트윈", "욕조"));
            rooms.Add(new StandardRoom(201, false, "더블", "샤워부스"));
            rooms.Add(new StandardRoom(202, false, "더블", "욕조"));
            rooms.Add(new StandardRoom(203, false, "트윈", "샤워부스"));
            rooms.Add(new StandardRoom(204, false, "트윈", "욕조"));

            // 디럭스룸 등록 (301 ~ 502호)
            rooms.Add(new DeluxeRoom(301, false, "킹", "샤워부스", true));   // 샤워부스 + 자쿠지
            rooms.Add(new DeluxeRoom(302, false, "킹", "욕조", false));      // 욕조
            rooms.Add(new DeluxeRoom(501, false, "트윈", "샤워부스", true)); // 샤워부스 + 자쿠지
            rooms.Add(new DeluxeRoom(502, false, "트윈", "욕조", false));    // 욕조
            // 스위트룸 등록 (601, 701호)
            rooms.Add(new SuiteRoom(601, false, false));
            rooms.Add(new SuiteRoom(701, false, true));

            staffs.Add(new Receptionist("김철수", 30, "010-1234-5678", 8, 3000000, "한국어", "오전"));
            staffs.Add(new Receptionist("이영희", 25, "010-9876-5432", 8, 2800000, "한국어,영어", "오후"));
            staffs.Add(new Receptionist("정수민", 27, "010-5555-6666", 8, 2800000, "한국어", "야간"));
            staffs.Add(new HouseKeeper("박민준", 35, "010-1111-2222", 8, 2500000, "방 청소"));
            staffs.Add(new HouseKeeper("최지우", 28, "010-3333-4444", 8, 2500000, "빨래"));
        }

        // 메서드 (예약 가능한 방 찾기 / 메서드 오버로딩 1)
        // 1. 방 번호로 찾기 (람다식)
        public Room FindRoom(int roomNumber)
        {
            return rooms.Find(r => r.RoomNumber == roomNumber); // 방 번호로 찾기
        }

        // 2. 방 타입으로 찾기 (람다식)
        public Room FindRoom(string roomType)
        {
            return rooms.Find(r => r.RoomType == roomType && r.IsAvailable); // 방 타입으로 찾기
        }

        // 메서드 (예약하기)
        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation); // 예약 목록에 추가
        }

        // 메서드 (예약 취소)
        public void RemoveReservation(string reservationId)
        {
            foreach (Reservation reservation in reservations.GetAll()) // 예약 목록 순서대로 확인
            {
                if (reservation.ReservationId == reservationId) // 예약번호 일치하면
                {
                    reservations.Remove(reservation); // 예약 목록에서 삭제
                    return;
                }
            }
        }

        // 메서드 (환불) / out 키워드
        public void CalculateRefund(Reservation reservation, out double refundAmount, out string refundMessage)
        {
            int daysUntilCheckIn = (reservation.CheckInDate - DateTime.Today).Days; // 체크인까지 남은 일수

            if (daysUntilCheckIn >= 7)
            {
                refundAmount = reservation.TotalPrice;        // 100% 환불
                refundMessage = "100% 환불";
            }
            else if (daysUntilCheckIn >= 3)
            {
                refundAmount = reservation.TotalPrice * 0.5;  // 50% 환불
                refundMessage = "50% 환불";
            }
            else
            {
                refundAmount = 0;                             // 환불 불가
                refundMessage = "환불 불가";
            }
        }

        // 메서드 (방 출력 / 메서드 오버로딩 2)
        // 1. 전체 방 출력
        public void PrintAllRooms()
        {
            foreach (Room room in rooms.GetAll())
            {
                Console.WriteLine(room);            // 기본 정보
                Console.WriteLine(room.GetInfo());  // 상세 정보
            }
        }

        // 2. 방 타입으로 필터링
        public void PrintAllRooms(string roomType)
        {
            foreach (Room room in rooms.GetAll())
            {
                if (room.RoomType == roomType)
                {
                    Console.WriteLine(room);            // 기본 정보
                    Console.WriteLine(room.GetInfo());  // 상세 정보
                }
            }
        }

        // 3. 인원 수로 필터링
        public void PrintAllRooms(int numberOfGuests)
        {
            foreach (Room room in rooms.GetAll())
            {
                if (room.IsAvailable && room.MaxGuests >= numberOfGuests) // 예약 가능하고 인원 수 맞는 방만 출력
                {
                    Console.WriteLine(room);            // 기본 정보
                    Console.WriteLine(room.GetInfo());  // 상세 정보
                }
            }
        }

        // 메서드 (예약 정보 출력)
        public void PrintAllReservations()
        {
            foreach (Reservation reservation in reservations.GetAll()) // 예약 목록 순서대로 출력
            {
                Console.WriteLine(reservation); // 각 예약 정보 출력
            }
        }

        // 메서드 (예약 찾기 / 메서드 오버로딩 3)
        // 1. 예약 번호로 찾기 (람다식)
        public Reservation FindReservation(string reservationId)
        {
            return reservations.Find(r => r.ReservationId == reservationId); // 예약 번호로 찾기
        }

        // 2. 손님 이름과 전화번호로 예약 찾기 (람다식)
        public Reservation FindReservation(string name, string phoneNumber)
        {
            return reservations.Find(r => r.Guest.Name == name && r.Guest.PhoneNumber == phoneNumber); // 이름+전화번호로 찾기
        }

        // 메서드 (직원 목록)
        public List<Staff> GetAllStaffs()
        {
            return staffs.GetAll(); // 직원 목록 반환
        }

        // 메서드 (프론트 직원 찾기 / 람다식)
        public Receptionist FindReceptionist()
        {
            int hour = DateTime.Now.Hour;
            string currentShift;

            if (hour >= 6 && hour < 14) currentShift = "오전";
            else if (hour >= 14 && hour < 22) currentShift = "오후";
            else currentShift = "야간";

            return (Receptionist)staffs.Find(s => s is Receptionist && ((Receptionist)s).Shift == currentShift); // 현재 교대 근무자 찾기
        }

        // 방 번호로 방 찾기 (인덱서, 람다식)
        public Room this[int roomNumber]
        {
            get { return rooms.Find(r => r.RoomNumber == roomNumber); } // 방 번호로 방 찾기
        }

        // 예약 번호로 예약 찾기 (인덱서, 람다식)
        public Reservation this[string reservationId]
        {
            get { return reservations.Find(r => r.ReservationId == reservationId); } // 예약 번호로 예약 찾기
        }
    }
}