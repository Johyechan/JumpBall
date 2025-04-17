namespace MyUtil.FSM
{
    // 모든 상태 클래스가 반드시 구현해야 할 인터페이스
    // 상태 전이 시 호출되는 기본 메서드들을 정의함
    public interface IState
    {
        public void Enter(); // 상태에 처음 진입할 때 호출

        public void Execute(); // 상태가 유지되는 동안 매 프레임 호출

        public void Exit(); // 상태를 떠날 때 호출
    }
}

