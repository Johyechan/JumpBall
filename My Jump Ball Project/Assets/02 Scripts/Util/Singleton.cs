using UnityEngine;

namespace MyUtil
{
    // MonoBehaviour�� ����ϴ� ���׸� �̱��� Ŭ����
    // T�� �ݵ�� MonoBehaviour�� ����� Ÿ���̾�� �ϸ�,
    // �پ��� ������Ʈ�� �̱��� ����� �ս��� ������ �� �ֵ��� �����
    // where T : MonoBehaviour�� as �����ڿ� FindFirstObjectByType ����� ����
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // �ܺο��� ���� ������ �� ���� ���� �ν��Ͻ�
        private static T _instance;

        // �ܺο��� ���� ������ �̱��� �ν��Ͻ�
        public static T Instance
        {
            get
            {
                // �ν��Ͻ��� ���� �������� �ʾҴٸ�
                if (_instance == null)
                {
                    // ���� ������ T Ÿ���� ������Ʈ�� ���� ã�´�
                    _instance = FindFirstObjectByType<T>();

                    // �׷��� �� ã�Ҵٸ� ���� ����
                    if (_instance == null)
                    {
                        // ���ο� ��ü�� ����� �װ��� T Ŭ������ �־��ְ� �װ��� �ν��Ͻ��� �Ҵ�
                        GameObject obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                    }
                }

                // �ν��Ͻ� ��ȯ
                return _instance;
            }
        }

        // ����Ƽ �����ֱ� �� Awake���� �ߺ� ���� ó��
        protected virtual void Awake()
        {
            // �ν��Ͻ��� ���� ���ٸ� �� ������Ʈ�� �ν��Ͻ��� ����
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                // �ߺ� �ν��Ͻ��� �ı�
                Destroy(gameObject);
            }
        }
    }
}

