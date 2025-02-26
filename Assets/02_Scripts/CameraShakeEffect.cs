using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeEffect : MonoBehaviour
{
    private Vector3 originalPosition;
    private float shakeAmount = 0.3f;
    private float shakeDuration = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void Shake()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float timer = 0;
        while (timer < shakeDuration)
        {
            timer += Time.deltaTime;
            float x = Random.Range(-shakeAmount, shakeAmount);
            float y = Random.Range(-shakeAmount, shakeAmount);
            transform.position = originalPosition + new Vector3(x, y, 0);
            yield return null;
        }
        transform.position = originalPosition;
    }
}
