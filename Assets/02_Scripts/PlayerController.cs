using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    [SerializeField] private StageController stageController;
    [SerializeField] private GameObject playerDieEffect; // �÷��̾� ��� ȿ��(Particle)
    [SerializeField] private bool cheat;

    private Animator animator;
    private Movement2D movement;

    public CameraShakeEffect cameraShake;

    private void Awake()
    {
        movement = GetComponent<Movement2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (stageController.IsGameOver == true) return;

        movement.MoveToX(); // x�� �̵�

        if (Input.GetMouseButton(0)) // y�� �̵�(���콺 ���� ��ư�� ������ ���� ��)
        {
            movement.MoveToY();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cheat)
            return;

        if (collision.tag.Equals("Item")){
            //Debug.Log("Score +1");
            stageController.IncreaseScore(1);

            animator.SetTrigger("GetItem");

            // Delete Item object
            Destroy(collision.gameObject);
        }
        else if (collision.tag.Equals("Obstacle"))
        {
            // �÷��̾� ��� ȿ�� ���(Particle)
            Instantiate(playerDieEffect, transform.position, Quaternion.identity);

            GetComponent<AudioSource>().Play();

            cameraShake.Shake();

            Destroy(GetComponent<Rigidbody2D>());
            stageController.GameOver();
        }
    }
}
