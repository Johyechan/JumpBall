using UnityEngine;

namespace MyUtil.FSM
{
    // ���� ��� ������ �����ϴ� ���� ���� �ӽ�(FSM) Ŭ����
    public class StateMachine
    {
        // ���� Ȱ��ȭ�� ����
        private IState _currentState;

        // ���¸� ��ȯ�ϴ� �Լ�
        public void ChangeState(IState nextState)
        {
            // ���� ���¿��� ����� ó�� (Exit ȣ��)
            _currentState?.Exit();

            // ���ο� ���·� ����
            _currentState = nextState;

            // ���ο� ���� ���� �� ó�� (Enter ȣ��)
            _currentState?.Enter();
        }

        // ���� ���¸� �� �����Ӹ��� ����
        public void UpdateExecute()
        {
            _currentState?.Execute();
        }
    }
}