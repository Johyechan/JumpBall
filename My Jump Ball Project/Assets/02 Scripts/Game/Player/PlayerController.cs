using UnityEngine;

namespace MyGame.Player
{
    // 플레이어 관련 클래스들을 모아 관리하는 클래스
    public class PlayerController : MonoBehaviour
    {
        // 플레이어에게 들어오는 인풋을 관리하는 클래스 변수
        private PlayerInputHandler _inputHandler;

        // 플레이어가 점프하는 기능을 담당하는 클래스 변수
        private PlayerJumpHandler _jumpHandler;

        // 변수 초기화: PlayerInput과 PlayerJump 컴포넌트를 찾고 할당
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _jumpHandler = GetComponent<PlayerJumpHandler>();
        }

        // 이벤트 구독: 인풋에서 점프가 차징되었을 때, 점프 실행 함수에 연결
        private void OnEnable()
        {
            _inputHandler.OnChargingJump += _jumpHandler.Jump;
        }

        // 이벤트 해제: 더 이상 점프 이벤트가 발생하지 않도록 연결 해제
        private void OnDisable()
        {
            _inputHandler.OnChargingJump -= _jumpHandler.Jump;
        }
    }
}