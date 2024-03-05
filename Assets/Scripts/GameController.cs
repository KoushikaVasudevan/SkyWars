using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    //[SerializeField] private HelicopterController helicopterController;
    [SerializeField] private GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void HelicopterCrashed()
    {
        gameOverCanvas.SetActive(true);
    }

    public void IncreaseScore(int s)
    {
        score += s;
        scoreText.text = "Score: " + score;
    }

    public void RestartScene()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);

        gameOverCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenuScene()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);

        gameOverCanvas.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
