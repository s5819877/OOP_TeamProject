using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    interface IValidatable
    {
        bool Validate(out string errorMessage); // 유효성 검사 + 오류 메시지 반환 / out 키워드
    }
}
