using MyGame.Player;
using UnityEngine;

public class PlayerJumpHandler : MonoBehaviour
{
    // ������ ���� �ϱ� ���� rigidbody ����
    private Rigidbody _rigid;

    // �ߺ� ������ ���� ���� ����
    private bool _isJumping = false;

    // rigidbody �ʱ�ȭ
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // ���� �̺�Ʈ�� ������ �Լ�
    public void Jump(float power)
    {
        // power�� �޾Ƽ� ���� ���� ���� �ƴ� �� ����
        if(!_isJumping)
        {
            // ���� ���� ���̶�� ����
            _isJumping = true;
            // ���� ����ŭ ����
            _rigid.AddForce(transform.forward * power, ForceMode.Impulse);
        }
    }

    // ���� ���ǿ� ������ �׶� �ٽ� ���� ���������ٰ� ����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isJumping = false;
        }
    }
}
