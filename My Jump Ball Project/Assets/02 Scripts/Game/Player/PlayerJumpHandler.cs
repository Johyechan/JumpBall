using MyGame.Player;
using UnityEngine;

public class PlayerJumpHandler : MonoBehaviour
{
    // 점프를 구현 하기 위한 rigidbody 변수
    private Rigidbody _rigid;

    // 중복 점프를 막기 위한 변수
    private bool _isJumping = false;

    // rigidbody 초기화
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // 점프 이벤트를 구독할 함수
    public void Jump(float power)
    {
        // power를 받아서 현재 점프 중이 아닐 때 실행
        if(!_isJumping)
        {
            // 현재 점프 중이라고 선언
            _isJumping = true;
            // 받은 힘만큼 점프
            _rigid.AddForce(transform.forward * power, ForceMode.Impulse);
        }
    }

    // 만약 발판에 닿으면 그때 다시 점프 가능해졌다고 선언
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isJumping = false;
        }
    }
}
