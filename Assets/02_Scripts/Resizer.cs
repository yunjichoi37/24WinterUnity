using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    private Vector3 startSize;
    [SerializeField] private Vector3 endSize;
    [SerializeField] private float resizeTime;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        startSize = transform.localScale;

        while (true)
        {
            yield return StartCoroutine(Resize(startSize, endSize, resizeTime));
            yield return StartCoroutine(Resize(endSize, startSize, resizeTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Resize(Vector3 start, Vector3 end, float time)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            transform.localScale = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}
