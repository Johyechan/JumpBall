using System;
using UnityEngine;

// 오브젝트 풀에서 사용할 프리팹 데이터를 직렬화하여 인스펙터에서 설정 가능하게 함
namespace MyUtil.ObjectPool
{
    [Serializable] // Unity 인스펙터에 표시되도록 직렬화
    public class ObjectPoolData
    {
        public ObjectPoolType type; // 풀 타입 식별자
        public int prefabCount; // 초기 생성할 프리팹 수
        public GameObject prefab; // 풀링할 프리팹
    }
}

