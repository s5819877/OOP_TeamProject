using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    delegate void NotifyAction(string message); // 알림 출력
}

/*
// 클래스 안에 넣으면
class HotelDelegates
{
    delegate void NotifyAction(string message); // HotelDelegates.NotifyAction 로 접근해야 함
}

// 네임스페이스에 바로 넣으면
delegate void NotifyAction(string message); // 그냥 NotifyAction 로 바로 접근 가능
*/