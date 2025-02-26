using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    private TextMeshProUGUI textFade;

    private void Awake()
    {
        textFade = GetComponent<TextMeshProUGUI>();

        // Fade In <-> Fade Out ���� �ݺ�
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            // ���� ���� 1���� 0����, text�� ������ �ʴ´�.
            yield return StartCoroutine(Fade(1, 0));

            // ���� ���� 0���� 1��, text�� ���δ�.
            yield return StartCoroutine(Fade(0, 1));
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = textFade.color;
            color.a = Mathf.Lerp(start, end, percent);
            textFade.color = color;

            yield return null;
        }
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
