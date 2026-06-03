using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class Hotel
    {
        // 필드 (클래스가 가지고 있는 데이터)
        private List<Room> rooms;           // 객실 목록
        private List<Reservation> reservations; // 예약 목록

        // 생성자 (객체 만들 때 실행되는 초기화 코드)
        public Hotel()
        {
            this.rooms = new List<Room>();              // 객실 리스트 초기화
            this.reservations = new List<Reservation>(); // 예약 리스트 초기화

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
        }

        // 메서드 (예약 가능한 방 찾기)
        public Room FindRoom(int roomNumber)
        {
            foreach (Room room in rooms) // 객실 목록을 순서대로 확인
            {
                if (room.RoomNumber == roomNumber) // 방 번호가 일치하면
                {
                    return room; // 해당 방 반환
                }
            }
            return null; // 못 찾으면 null 반환
        }

        // 메서드 (예약하기)
        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation); // 예약 목록에 추가
        }

        // 메서드 (예약 취소)
        public void RemoveReservation(int reservationId)
        {
            foreach (Reservation reservation in reservations) // 예약 목록 순서대로 확인
            {
                if (reservation.ReservationId == reservationId) // 예약번호 일치하면
                {
                    reservations.Remove(reservation); // 예약 목록에서 삭제
                    return;
                }
            }
        }

        // 메서드 (타입 별 방 정보 출력)
        public void PrintAllRooms()
        {
            foreach (Room room in rooms) // 객실 목록 순서대로 출력
            {
                Console.WriteLine(room); // 각 방 정보 출력
            }
        }

        // 메서드 (예약 정보 출력)
        public void PrintAllReservations()
        {
            foreach (Reservation reservation in reservations) // 예약 목록 순서대로 출력
            {
                Console.WriteLine(reservation); // 각 예약 정보 출력
            }
        }

    }
}
