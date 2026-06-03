namespace OOP_TeamProject
{
    internal class Program
        static Hotel hotel = new Hotel();
    {
        static void Main(string[] args)
    {
        Console.WriteLine("=== 호텔 예약 시스템 ===");

        bool running = true;

        while (running)
        {
            PrintMenu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": hotel.PrintAllRooms(); break;      // ← 연결
                case "2": MakeReservation(); break;          // ← 연결
                case "3": CancelReservation(); break;        // ← 연결
                case "4": hotel.PrintAllReservations(); break; // ← 연결
                case "5": running = false; break;
                default: Console.WriteLine("잘못된 입력입니다."); break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("\n--- 메뉴 ---");
        Console.WriteLine("1. 객실 목록 보기");
        Console.WriteLine("2. 예약하기");
        Console.WriteLine("3. 예약 취소");
        Console.WriteLine("4. 예약 목록 보기");
        Console.WriteLine("5. 종료");
        Console.Write("선택: ");
    }

    static void MakeReservation()
    {
        // 나중에 채울 예정
    }

    static void CancelReservation()
    {
        // 나중에 채울 예정
    }
}
}
