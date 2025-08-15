using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Slider timeslider;
    public Text scoreText;
    public GameObject gameoverUI;
    public GameObject spawn;
    public Text bestscoreText;
    
    private int score = 0;
    private int bestscore;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestscore = PlayerPrefs.GetInt("BestScore");
    }

    // Update is called once per frame
    void Update()
    {
        Best();
        if(timeslider.value>0.0f)
        {
            timeslider.value-=Time.deltaTime;
        }
        else
        {
            gameoverUI.SetActive(true);
            spawn.SetActive(false);
        }

    }
    public void AddScore(int newScore)
    {
        if (timeslider.value > 0.0f)
        {
            score += newScore;
            scoreText.text = "Score: " + score;
        }
    }

    public void Best()
    {
        if (score > bestscore)
        {
            bestscore = score;
            PlayerPrefs.SetInt("BestScore", bestscore);
        }

        bestscoreText.text = "Best Score: " + bestscore;
    }

    public void LoadScene(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }

    public void EndGame()
    {

    #if Unity_3_5
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
        /*#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();

        #endif*/
    }
}