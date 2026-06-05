using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_TeamProject
{
    class Repository<T>
    {
        private List<T> items = new List<T>(); // 컬렉션

        public void Add(T item)
        {
            items.Add(item); // 항목 추가
        }

        public void Remove(T item)
        {
            items.Remove(item); // 항목 삭제
        }

        public T Get(int index)
        {
            return items[index]; // 인덱스로 항목 가져오기
        }

        public List<T> GetAll()
        {
            return items; // 전체 목록 반환
        }

        public int Count()
        {
            return items.Count; // 항목 수 반환
        }

        public T Find(Func<T, bool> condition)
        {
            foreach (T item in items)
            {
                if (condition(item)) // 조건에 맞으면
                {
                    return item; // 해당 항목 반환
                }
            }
            return default(T); // 못 찾으면 null 반환
        }

    }
}
