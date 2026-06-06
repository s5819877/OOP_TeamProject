namespace OOP_TeamProject
{
    internal class Program
    {
        static Hotel hotel = new Hotel();
        static void Main(string[] args)
        {
            Console.WriteLine("=== 호텔 시스템 ===");

            bool running = true;

            while (running)
            {
                PrintMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": hotel.PrintAllRooms(); break;       // 객실 목록 보기
                    case "2": MakeReservation(); break;           // 예약하기
                    case "3": CancelReservation(); break;         // 예약 취소
                    case "4": hotel.PrintAllReservations(); break; // 예약 목록 보기
                    case "5": WalkIn(); break;                    // 워크인
                    case "6": CheckIn(); break;                   // 체크인
                    case "7": CheckOut(); break;                  // 체크아웃
                    case "8": PrintStaffs(); break;               // 직원 목록 보기
                    case "0": running = false; break;             // 종료          
                    default: Console.WriteLine("잘못된 입력입니다."); break;
                }
            }

            Console.WriteLine("시스템을 종료합니다.");
        }

        static void PrintMenu()
        {
            Console.WriteLine("\n----- 메뉴 -----");
            Console.WriteLine("1. 객실 목록 보기");
            Console.WriteLine("2. 예약하기");
            Console.WriteLine("3. 예약 취소");
            Console.WriteLine("4. 예약 목록 보기");
            Console.WriteLine("5. 워크인");
            Console.WriteLine("6. 체크인");
            Console.WriteLine("7. 체크아웃");
            Console.WriteLine("8. 직원 목록 보기");
            Console.WriteLine("0. 종료");
            Console.Write("선택: ");
        }

        static void MakeReservation() // 예약하기
        {
            try
            {
                // 1. 객실 목록 보여주기
                Console.WriteLine("\n=== 객실 목록 ===");
                hotel.PrintAllRooms();

                // 2. 예약 날짜 및 인원 입력
                Console.Write("\n체크인 날짜 입력 (yyyy-MM-dd): ");
                DateTime checkInDate = DateTime.Parse(Console.ReadLine());

                Console.Write("체크아웃 날짜 입력 (yyyy-MM-dd): ");
                DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

                Console.Write("인원 입력: ");
                int numberOfGuests = int.Parse(Console.ReadLine());

                // 3. 가능한 객실 목록 보여주기
                Console.WriteLine("\n=== 예약 가능한 객실 ===");
                hotel.PrintAllRooms(numberOfGuests); // 인원 수로 필터링

                // 4. 방 번호 선택
                Console.Write("\n방 번호 선택: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Room room = hotel[roomNumber];

                if (room == null)
                {
                    throw new RoomNotFoundException(roomNumber);
                }
                if (!room.IsAvailable)
                {
                    throw new RoomAlreadyBookedException(roomNumber);
                }

                // 조식 여부 선택
                Console.Write("조식 신청하시겠습니까? (Y/N): ");
                string breakfastInput = Console.ReadLine();
                room.HasBreakfast = (breakfastInput.ToUpper() == "Y"); 

                // 5. 손님 정보 입력
                Console.Write("이름 입력: ");
                string name = Console.ReadLine();

                Console.Write("나이 입력: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("전화번호 입력: ");
                string phoneNumber = Console.ReadLine();

                Guest guest = new Guest(name, age, phoneNumber, numberOfGuests);

                // 6. 손님 유효성 검사
                if (!guest.Validate(out string guestError))
                {
                    Console.WriteLine(guestError);
                    return;
                }

                // 7. 결제 방식 선택
                Console.WriteLine("결제 방식 선택 (1. 일시불 / 2. 할부)");
                Console.Write("선택: ");
                string paymentInput = Console.ReadLine();

                int installment = 0;
                if (paymentInput == "2")
                {
                    Console.Write("할부 개월 입력: ");
                    installment = int.Parse(Console.ReadLine());
                }

                double totalPrice = (checkOutDate - checkInDate).Days * room.Price;
                CardPayment payment = new CardPayment(totalPrice, "예약", installment);
                payment.Pay();

                // 8. 예약 생성
                Reservation reservation = new Reservation(room, guest, checkInDate, checkOutDate, payment);

                // 9. 예약 유효성 검사
                if (!reservation.Validate(out string reservationError))
                {
                    Console.WriteLine(reservationError);
                    return;
                }

                room.Book();
                hotel.AddReservation(reservation);

                // 10. 예약 번호 출력
                NotifyAction notify = message => Console.WriteLine(message); // 알림 델리게이트, 람다식
                notify("예약 완료! 예약 번호: " + reservation.ReservationId);
                reservation.Payment.PrintReceipt(); // 영수증 출력
            }
            catch (RoomNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (RoomAlreadyBookedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("오류 발생: " + e.Message);
            }
            finally
            {
                Console.WriteLine("=========================="); // 구분선
            }
        }
        static void CancelReservation() // 예약 취소
        {
            try
            {
                Console.WriteLine("\n취소 방법 선택");
                Console.WriteLine("1. 예약 번호로 취소");
                Console.WriteLine("2. 이름 + 전화번호로 취소");
                Console.Write("선택: ");
                string input = Console.ReadLine();

                Reservation reservation = null;

                if (input == "1")
                {
                    Console.Write("예약 번호 입력: ");
                    string reservationId = Console.ReadLine();
                    reservation = hotel[reservationId];
                }
                else if (input == "2")
                {
                    Console.Write("이름 입력: ");
                    string name = Console.ReadLine();
                    Console.Write("전화번호 입력: ");
                    string phoneNumber = Console.ReadLine();
                    reservation = hotel.FindReservation(name, phoneNumber);
                }

                if (reservation == null)
                {
                    throw new ReservationNotFoundException("해당");
                }

                // 환불 금액 계산
                hotel.CalculateRefund(reservation, out double refundAmount, out string refundMessage);
                Console.WriteLine(refundMessage + " / 환불 금액: " + refundAmount + "원");

                reservation.Room.Cancel();
                hotel.RemoveReservation(reservation.ReservationId);

                NotifyAction notify = message => Console.WriteLine(message); // 알림 델리게이트, 람다식
                notify("예약이 취소되었습니다.");
            }
            catch (ReservationNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("오류 발생: " + e.Message);
            }
            finally
            {
                Console.WriteLine("=========================="); // 구분선
            }
        }
        static void WalkIn() // 워크인
        {
            try
            {
                // 1. 객실 목록 보여주기
                Console.WriteLine("\n=== 객실 목록 ===");
                hotel.PrintAllRooms();

                // 2. 인원 및 체크아웃 날짜 입력
                Console.Write("\n인원 입력: ");
                int numberOfGuests = int.Parse(Console.ReadLine());

                Console.Write("체크아웃 날짜 입력 (yyyy-MM-dd): ");
                DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

                DateTime checkInDate = DateTime.Today; // 체크인 날짜는 오늘

                // 3. 가능한 객실 목록 보여주기
                Console.WriteLine("\n=== 예약 가능한 객실 ===");
                hotel.PrintAllRooms(numberOfGuests); // 인원 수로 필터링

                // 4. 방 번호 선택
                Console.Write("\n방 번호 선택: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Room room = hotel[roomNumber];

                if (room == null)
                {
                    throw new RoomNotFoundException(roomNumber);
                }
                if (!room.IsAvailable)
                {
                    throw new RoomAlreadyBookedException(roomNumber);
                }

                // 조식 여부 선택
                Console.Write("조식 신청하시겠습니까? (Y/N): ");
                string breakfastInput = Console.ReadLine();
                room.HasBreakfast = (breakfastInput.ToUpper() == "Y");

                // 5. 손님 정보 입력
                Console.Write("이름 입력: ");
                string name = Console.ReadLine();

                Console.Write("나이 입력: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("전화번호 입력: ");
                string phoneNumber = Console.ReadLine();

                Guest guest = new Guest(name, age, phoneNumber, numberOfGuests);

                // 6. 손님 유효성 검사
                if (!guest.Validate(out string guestError))
                {
                    Console.WriteLine(guestError);
                    return;
                }

                // 7. 결제 방식 선택
                Console.WriteLine("결제 방식 선택 (1. 현금 / 2. 카드)");
                Console.Write("선택: ");
                string paymentInput = Console.ReadLine();

                Payment payment;
                double totalPrice = (checkOutDate - checkInDate).Days * room.Price;

                if (paymentInput == "1")
                {
                    Console.Write("받은 금액 입력: ");
                    double receivedAmount = double.Parse(Console.ReadLine());

                    if (receivedAmount < totalPrice)
                    {
                        throw new InvalidPaymentException();
                    }

                    payment = new CashPayment(totalPrice, receivedAmount);
                }
                else
                {
                    Console.WriteLine("할부 방식 선택 (1. 일시불 / 2. 할부)");
                    Console.Write("선택: ");
                    string cardInput = Console.ReadLine();

                    int installment = 0;
                    if (cardInput == "2")
                    {
                        Console.Write("할부 개월 입력: ");
                        installment = int.Parse(Console.ReadLine());
                    }

                    payment = new CardPayment(totalPrice, "워크인", installment);
                }

                payment.Pay();

                // 8. 예약 생성
                Reservation reservation = new Reservation(room, guest, checkInDate, checkOutDate, payment);

                // 9. 예약 유효성 검사
                if (!reservation.Validate(out string reservationError))
                {
                    Console.WriteLine(reservationError);
                    return;
                }

                room.Book();
                hotel.AddReservation(reservation);

                // 10. 완료 출력
                NotifyAction notify = message => Console.WriteLine(message); // 알림 델리게이트, 람다식
                notify("워크인 완료! 예약 번호: " + reservation.ReservationId);
                reservation.Payment.PrintReceipt(); // 영수증 출력
            }
            catch (RoomNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (RoomAlreadyBookedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidPaymentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("오류 발생: " + e.Message);
            }
            finally
            {
                Console.WriteLine("=========================="); // 구분선
            }
        }
        static void CheckIn() // 체크인
        {
            try
            {
                // 1. 예약 번호 입력
                Console.Write("\n예약 번호 입력: ");
                string reservationId = Console.ReadLine();

                // 2. 예약 찾기
                Reservation reservation = hotel[reservationId];
                if (reservation == null)
                {
                    throw new ReservationNotFoundException(reservationId);
                }

                // 3. 체크인 날짜 확인
                if (reservation.CheckInDate.Date != DateTime.Today)
                {
                    throw new InvalidCheckInException();
                }

                // 4. Receptionist가 체크인 처리
                Receptionist receptionist = hotel.FindReceptionist();
                receptionist.CheckIn(reservation);

                // 5. 완료 출력
                NotifyAction notify = message => Console.WriteLine(message); // 알림 델리게이트, 람다식
                notify("체크인 완료!");
            }
            catch (ReservationNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidCheckInException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("오류 발생: " + e.Message);
            }
            finally
            {
                Console.WriteLine("=========================="); // 구분선
            }
        }
        static void CheckOut() // 체크아웃
        {
            try
            {
                // 1. 예약 번호 입력
                Console.Write("\n예약 번호 입력: ");
                string reservationId = Console.ReadLine();

                // 2. 예약 찾기
                Reservation reservation = hotel[reservationId];
                if (reservation == null)
                {
                    throw new ReservationNotFoundException(reservationId);
                }

                // 3. Receptionist가 체크아웃 처리
                Receptionist receptionist = hotel.FindReceptionist();
                receptionist.CheckOut(reservation);

                // 4. 방 상태 변경
                reservation.Room.Cancel(); // 방 다시 비어있음으로 변경

                // 5. 완료 출력
                NotifyAction notify = message => Console.WriteLine(message); // 알림 델리게이트, 람다식
                notify("체크아웃 완료!");
            }
            catch (ReservationNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("오류 발생: " + e.Message);
            }
            finally
            {
                Console.WriteLine("=========================="); // 구분선
            }
        }
        static void PrintStaffs() // 직원 목록 보기
        {
            try
            {
                // 1. 직원 목록 출력
                Console.WriteLine("\n=== 직원 목록 ===");
                List<Staff> staffList = hotel.GetAllStaffs();
                for (int i = 0; i < staffList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + staffList[i].ToString()); // 번호 + 기본 정보
                }

                // 2. 직원 선택
                Console.Write("\n직원 번호 선택: ");
                int index = int.Parse(Console.ReadLine()) - 1;

                if (index < 0 || index >= staffList.Count)
                {
                    Console.WriteLine("잘못된 번호입니다.");
                    return;
                }

                // 3. 상세 정보 출력
                Console.WriteLine("\n=== 상세 정보 ===");
                staffList[index].PrintInfo();
            }
            catch (Exception e)
            {
                Console.WriteLine("오류 발생: " + e.Message);
            }
            finally
            {
                Console.WriteLine("=========================="); // 구분선
            }
        }
    }
}
