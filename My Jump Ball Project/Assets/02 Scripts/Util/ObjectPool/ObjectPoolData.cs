using System;
using UnityEngine;

// ������Ʈ Ǯ���� ����� ������ �����͸� ����ȭ�Ͽ� �ν����Ϳ��� ���� �����ϰ� ��
namespace MyUtil.ObjectPool
{
    [Serializable] // Unity �ν����Ϳ� ǥ�õǵ��� ����ȭ
    public class ObjectPoolData
    {
        public ObjectPoolType type; // Ǯ Ÿ�� �ĺ���
        public int prefabCount; // �ʱ� ������ ������ ��
        public GameObject prefab; // Ǯ���� ������
    }
}

