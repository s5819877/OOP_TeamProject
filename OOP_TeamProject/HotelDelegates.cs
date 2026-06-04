using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    delegate bool RoomFilter(Room room); // 방 필터링 조건
}

/*
// 클래스 안에 넣으면
class HotelDelegates
{
    delegate bool RoomFilter(Room room); // HotelDelegates.RoomFilter 로 접근해야 함
}

// 네임스페이스에 바로 넣으면
delegate bool RoomFilter(Room room); // 그냥 RoomFilter 로 바로 접근 가능
*/