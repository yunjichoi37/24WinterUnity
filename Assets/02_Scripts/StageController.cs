using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject textTitle;
    [SerializeField] private GameObject textTapToPlay;

    [SerializeField] private TextMeshProUGUI textCurrentScore;
    [SerializeField] private TextMeshProUGUI textBestScore;

    [SerializeField] private GameObject buttonContinue;
    [SerializeField] private GameObject textScoreText;

    private int currentScore = 0;
    private float gameOverDelayTime = 1;

    public bool IsGameOver { private set; get; } = false;

    private IEnumerator Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        textBestScore.text = $"<size=50>BEST</size>\n<size=100>{bestScore}</size>";

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                yield break;
            }
            yield return null;
        }
    }

    private void GameStart()
    {
        textTitle.SetActive(false);
        textTapToPlay.SetActive(false);

        textCurrentScore.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        IsGameOver = true;

        StartCoroutine("OnGameOver");
    }

    private IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(gameOverDelayTime);

        // 디바이스에 "BestScore" 키로 저장되어 있는 최고 점수 데이터를 불러온다.
        int bestScore = PlayerPrefs.GetInt("BestScore");

        // 현재 스테이지에서 획득한 점수가 최고 점수보다 높으면 최고 점수를 갱신해서 저장
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            // 게임화면에 최고 점수 출력
            textBestScore.text = $"<size=50>BEST</size>\n<size=100>{currentScore}</size>";
        }

        buttonContinue.SetActive(true);
        textScoreText.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;
        textCurrentScore.text = currentScore.ToString();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
