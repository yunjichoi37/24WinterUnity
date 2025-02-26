using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;

    private float bgHeight;

    void Start()
    {
        bgHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        transform.position += Vector3.down * (moveSpeed * Time.deltaTime);

        if (transform.position.y <= player.transform.position.y - (bgHeight * 0.8f))
            transform.position += new Vector3(0, bgHeight, 0);
    }
}
