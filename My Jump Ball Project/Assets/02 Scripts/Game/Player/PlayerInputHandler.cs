using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyGame.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        // ���� ��¡�� ��
        private float _currentchargingPower;
        // �ִ� ��¡ ��
        private float _maxChargingPower = 10f;
        // ��¡ �ӵ�
        private float _chargingSpeed = 2f;

        // ���� �̺�Ʈ
        public event Action<float> OnChargingJump;

        // ��ǲ�� �޴� �Լ�
        public void OnJump(InputAction.CallbackContext context)
        {
            // ��ǲ�� ó�� ���۵Ǿ��� �� (��ư�� ������ ��)
            if (context.started)
            {
                // ��¡ �� �ʱ�ȭ (��¡ ����)
                _currentchargingPower = 0;
            }

            // ��ǲ�� ���������� ������ �ִ� ���� (��ư�� ������ ���� ��)
            if (context.performed)
            {
                // ���� ��¡ ���� �ִ� ��¡ ������ ���� ��
                if (_currentchargingPower < _maxChargingPower)
                {
                    // ��¡ �ӵ��� ���� ��¡ �� ����
                    _currentchargingPower += Time.deltaTime * _chargingSpeed;
                }
            }

            // ��ǲ�� ������ �� (��ư�� ���� ��)
            if (context.canceled)
            {
                // ��¡ ���� 0�� �ִ� ��¡ �� ���̷� Ŭ����
                _currentchargingPower = Mathf.Clamp(_currentchargingPower, 0, _maxChargingPower);
                // ��¡�� ������ ���� �̺�Ʈ ����
                OnChargingJump?.Invoke(_currentchargingPower);
                // ��¡ �� �ʱ�ȭ
                _currentchargingPower = 0;
            }
        }
    }
}

