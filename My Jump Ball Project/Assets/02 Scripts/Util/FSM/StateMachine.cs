using UnityEngine;

namespace MyUtil.FSM
{
    // 상태 기반 로직을 관리하는 유한 상태 머신(FSM) 클래스
    public class StateMachine
    {
        // 현재 활성화된 상태
        private IState _currentState;

        // 상태를 전환하는 함수
        public void ChangeState(IState nextState)
        {
            // 이전 상태에서 벗어나는 처리 (Exit 호출)
            _currentState?.Exit();

            // 새로운 상태로 변경
            _currentState = nextState;

            // 새로운 상태 진입 시 처리 (Enter 호출)
            _currentState?.Enter();
        }

        // 현재 상태를 매 프레임마다 실행
        public void UpdateExecute()
        {
            _currentState?.Execute();
        }
    }
}