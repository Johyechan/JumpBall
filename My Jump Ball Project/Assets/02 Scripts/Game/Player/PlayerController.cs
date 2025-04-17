using UnityEngine;

namespace MyGame.Player
{
    // �÷��̾� ���� Ŭ�������� ��� �����ϴ� Ŭ����
    public class PlayerController : MonoBehaviour
    {
        // �÷��̾�� ������ ��ǲ�� �����ϴ� Ŭ���� ����
        private PlayerInputHandler _inputHandler;

        // �÷��̾ �����ϴ� ����� ����ϴ� Ŭ���� ����
        private PlayerJumpHandler _jumpHandler;

        // ���� �ʱ�ȭ: PlayerInput�� PlayerJump ������Ʈ�� ã�� �Ҵ�
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _jumpHandler = GetComponent<PlayerJumpHandler>();
        }

        // �̺�Ʈ ����: ��ǲ���� ������ ��¡�Ǿ��� ��, ���� ���� �Լ��� ����
        private void OnEnable()
        {
            _inputHandler.OnChargingJump += _jumpHandler.Jump;
        }

        // �̺�Ʈ ����: �� �̻� ���� �̺�Ʈ�� �߻����� �ʵ��� ���� ����
        private void OnDisable()
        {
            _inputHandler.OnChargingJump -= _jumpHandler.Jump;
        }
    }
}