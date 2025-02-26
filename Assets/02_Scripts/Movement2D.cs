using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] private float xMoveSpeed = 2; // �¿� �̵� �ӵ�
    [SerializeField] private float xDelta = 2; // �¿� ���� ��(�̵� ����)
    private float xStartPosition; // x�� ���� ��ġ

    [Header("Vertical Movement")]
    [SerializeField] private float yMoveSpeed = 0.5f; // ���� �̵� �ӵ�
    private Rigidbody2D rigid2D; // AddForce() ����� ���� Rigidbody2D ������Ʈ

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        xStartPosition = transform.position.x;
    }

    public void MoveToX()
    {
        // x�� �̵� �� ���(x�� ���� ��ġ + ���� ��)
        float x = xStartPosition + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
        // x�� �̵�
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveToY()
    {
        // AddForce()�� �̿��� ���� �̵��ϴ� ���� �ش�
        // Updata(), FixedUpdata() ȣ��Ǵ� �̺�Ʈ �޼ҵ忡 ���� �̵� ���� ũ�� �ٲ��
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
