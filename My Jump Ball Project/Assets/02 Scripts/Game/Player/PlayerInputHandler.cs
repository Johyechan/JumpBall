using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyGame.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        // 현재 차징된 값
        private float _currentchargingPower;
        // 최대 차징 값
        private float _maxChargingPower = 10f;
        // 차징 속도
        private float _chargingSpeed = 2f;

        // 점프 이벤트
        public event Action<float> OnChargingJump;

        // 인풋을 받는 함수
        public void OnJump(InputAction.CallbackContext context)
        {
            // 인풋이 처음 시작되었을 때 (버튼이 눌렸을 때)
            if (context.started)
            {
                // 차징 값 초기화 (차징 시작)
                _currentchargingPower = 0;
            }

            // 인풋이 지속적으로 들어오고 있는 상태 (버튼을 누르고 있을 때)
            if (context.performed)
            {
                // 현재 차징 값이 최대 차징 값보다 작을 때
                if (_currentchargingPower < _maxChargingPower)
                {
                    // 차징 속도에 따라 차징 값 증가
                    _currentchargingPower += Time.deltaTime * _chargingSpeed;
                }
            }

            // 인풋이 끝났을 때 (버튼을 뗐을 때)
            if (context.canceled)
            {
                // 차징 값을 0과 최대 차징 값 사이로 클램프
                _currentchargingPower = Mathf.Clamp(_currentchargingPower, 0, _maxChargingPower);
                // 차징된 값으로 점프 이벤트 실행
                OnChargingJump?.Invoke(_currentchargingPower);
                // 차징 값 초기화
                _currentchargingPower = 0;
            }
        }
    }
}

