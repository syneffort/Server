﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServerCore
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public int Count { get { return _heap.Count; } }

        public void Push(T data)
        {
            // 힙 마지막에 데이터 삽입
            _heap.Add(data);

            int now = _heap.Count - 1;
            // 도장깨기 시작
            while (now > 0)
            {
                // 도장깨기 시도
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                // 두 값 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                now = next;
            }
        }

        public T Pop()
        {
            // 반환할 데이터 저장
            T ret = _heap[0];

            // 마지막 데이터를 루트로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 역방향 도장깨기 시도
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // 왼쪽 값이 현재값보다 크면 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                // 오른쪽 값이 현재값보다 크면 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // 왼쪽 오른쪽 모두 현재 값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                now = next;
            }

            return ret;
        }

        public T Peek()
        {
            if (_heap.Count == 0)
                return default(T);

            return _heap[0];
        }
    }
}
