using System.Collections.Generic;
using UnityEngine;

namespace MyUtil.ObjectPool
{
    // 어디서든 접근할 수 있도록 싱글톤 패턴을 적용한 오브젝트 풀 매니저
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        // 에디터에서 등록한 풀링할 프리팹 리스트
        [SerializeField] private List<ObjectPoolData> _poolList = new();

        // 타입별 풀링 데이터 접근을 위한 맵
        private Dictionary<ObjectPoolType, ObjectPoolData> _poolDataMap = new();
        // 타입별 풀에 실제 게임오브젝트를 담아두는 큐
        private Dictionary<ObjectPoolType, Queue<GameObject>> _pool = new();

        // 싱글톤 초기화 후 풀 데이터 생성
        protected override void Awake()
        {
            base.Awake();

            Init();
        }

        // 오브젝트 풀 초기화
        private void Init()
        {
            // 리스트에 있는 풀링 데이터를 딕셔너리에 등록
            foreach (var data in _poolList)
            {
                _poolDataMap.Add(data.type, data);
            }

            // 딕셔너리를 순회하며 각 타입별 큐와 객체 생성
            foreach (var data in _poolDataMap)
            {
                _pool.Add(data.Key, new Queue<GameObject>());

                ObjectPoolData poolData = data.Value;

                for (int i = 0; i < poolData.prefabCount; i++)
                {
                    GameObject poolObject = CreateObject(data.Key);
                    _pool[data.Key].Enqueue(poolObject);
                }
            }
        }

        // 지정한 타입의 오브젝트를 생성
        private GameObject CreateObject(ObjectPoolType type)
        {
            // 풀 매니저 하위에 생성
            GameObject newObj = Instantiate(_poolDataMap[type].prefab, transform);
            newObj.transform.position = Vector3.zero;
            newObj.transform.rotation = Quaternion.identity;
            newObj.SetActive(false);
            return newObj;
        }

        // 외부에서 오브젝트를 꺼내올 때 호출
        public GameObject GetObject(ObjectPoolType type, Transform trans = null)
        {
            // 풀에 남은 오브젝트가 있다면 꺼내고, 없다면 새로 생성
            if (_pool[type].Count > 0)
            {
                GameObject obj = _pool[type].Dequeue();
                obj.SetActive(true);
                obj.transform.SetParent(trans);
                return obj;
            }
            else
            {
                GameObject newObj = CreateObject(type);
                newObj.SetActive(true);
                newObj.transform.SetParent(trans);
                return newObj;
            }
        }

        // 외부에서 오브젝트를 다시 풀에 반환할 때 호출
        public void ReturnObj(ObjectPoolType type, GameObject obj)
        {
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            _pool[type].Enqueue(obj);
        }
    }
}

