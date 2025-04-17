using System.Collections.Generic;
using UnityEngine;

namespace MyUtil.ObjectPool
{
    // ��𼭵� ������ �� �ֵ��� �̱��� ������ ������ ������Ʈ Ǯ �Ŵ���
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        // �����Ϳ��� ����� Ǯ���� ������ ����Ʈ
        [SerializeField] private List<ObjectPoolData> _poolList = new();

        // Ÿ�Ժ� Ǯ�� ������ ������ ���� ��
        private Dictionary<ObjectPoolType, ObjectPoolData> _poolDataMap = new();
        // Ÿ�Ժ� Ǯ�� ���� ���ӿ�����Ʈ�� ��Ƶδ� ť
        private Dictionary<ObjectPoolType, Queue<GameObject>> _pool = new();

        // �̱��� �ʱ�ȭ �� Ǯ ������ ����
        protected override void Awake()
        {
            base.Awake();

            Init();
        }

        // ������Ʈ Ǯ �ʱ�ȭ
        private void Init()
        {
            // ����Ʈ�� �ִ� Ǯ�� �����͸� ��ųʸ��� ���
            foreach (var data in _poolList)
            {
                _poolDataMap.Add(data.type, data);
            }

            // ��ųʸ��� ��ȸ�ϸ� �� Ÿ�Ժ� ť�� ��ü ����
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

        // ������ Ÿ���� ������Ʈ�� ����
        private GameObject CreateObject(ObjectPoolType type)
        {
            // Ǯ �Ŵ��� ������ ����
            GameObject newObj = Instantiate(_poolDataMap[type].prefab, transform);
            newObj.transform.position = Vector3.zero;
            newObj.transform.rotation = Quaternion.identity;
            newObj.SetActive(false);
            return newObj;
        }

        // �ܺο��� ������Ʈ�� ������ �� ȣ��
        public GameObject GetObject(ObjectPoolType type, Transform trans = null)
        {
            // Ǯ�� ���� ������Ʈ�� �ִٸ� ������, ���ٸ� ���� ����
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

        // �ܺο��� ������Ʈ�� �ٽ� Ǯ�� ��ȯ�� �� ȣ��
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

