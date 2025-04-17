namespace MyUtil.FSM
{
    // ��� ���� Ŭ������ �ݵ�� �����ؾ� �� �������̽�
    // ���� ���� �� ȣ��Ǵ� �⺻ �޼������ ������
    public interface IState
    {
        public void Enter(); // ���¿� ó�� ������ �� ȣ��

        public void Execute(); // ���°� �����Ǵ� ���� �� ������ ȣ��

        public void Exit(); // ���¸� ���� �� ȣ��
    }
}

