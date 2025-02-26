using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] private float xDelta;
    [SerializeField] private float xMoveSpeed;

    [Header("Vertical Movement")]
    [SerializeField] private float yDelta;
    [SerializeField] private float yMoveSpeed;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (xMoveSpeed != 0)
        {
            float x = startPosition.x + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        if (yMoveSpeed != 0)
        {
            float y = startPosition.y + yDelta * Mathf.Sin(Time.time * yMoveSpeed);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
