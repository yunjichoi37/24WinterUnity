using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] private float xMoveSpeed = 2; // 좌우 이동 속도
    [SerializeField] private float xDelta = 2; // 좌우 변동 값(이동 범위)
    private float xStartPosition; // x축 시작 위치

    [Header("Vertical Movement")]
    [SerializeField] private float yMoveSpeed = 0.5f; // 전진 이동 속도
    private Rigidbody2D rigid2D; // AddForce() 사용을 위한 Rigidbody2D 컴포넌트

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        xStartPosition = transform.position.x;
    }

    public void MoveToX()
    {
        // x축 이동 값 계산(x축 시작 위치 + 변위 값)
        float x = xStartPosition + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
        // x축 이동
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveToY()
    {
        // AddForce()를 이용해 위로 이동하는 힘을 준다
        // Updata(), FixedUpdata() 호출되는 이벤트 메소드에 따라 이동 폭이 크게 바뀐다
        rigid2D.AddForce(transform.up * yMoveSpeed, ForceMode2D.Impulse);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
