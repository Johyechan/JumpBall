using UnityEngine;

namespace MyUtil
{
    // MonoBehaviour를 상속하는 제네릭 싱글톤 클래스
    // T는 반드시 MonoBehaviour를 상속한 타입이어야 하며,
    // 다양한 컴포넌트에 싱글톤 기능을 손쉽게 적용할 수 있도록 설계됨
    // where T : MonoBehaviour는 as 연산자와 FindFirstObjectByType 사용을 위함
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // 외부에서 직접 접근할 수 없는 정적 인스턴스
        private static T _instance;

        // 외부에서 접근 가능한 싱글톤 인스턴스
        public static T Instance
        {
            get
            {
                // 인스턴스가 아직 생성되지 않았다면
                if (_instance == null)
                {
                    // 현재 씬에서 T 타입의 오브젝트를 먼저 찾는다
                    _instance = FindFirstObjectByType<T>();

                    // 그래도 못 찾았다면 새로 생성
                    if (_instance == null)
                    {
                        // 새로운 객체를 만들어 그곳에 T 클래스를 넣어주고 그것을 인스턴스로 할당
                        GameObject obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                    }
                }

                // 인스턴스 반환
                return _instance;
            }
        }

        // 유니티 생명주기 중 Awake에서 중복 방지 처리
        protected virtual void Awake()
        {
            // 인스턴스가 아직 없다면 이 오브젝트를 인스턴스로 지정
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                // 중복 인스턴스는 파괴
                Destroy(gameObject);
            }
        }
    }
}

