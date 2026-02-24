using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    int lastScore = -1;

    void Awake()
    {
        scoreKeeper = ScoreKeeper.Instance != null ? ScoreKeeper.Instance : FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        if (scoreKeeper == null) scoreKeeper = ScoreKeeper.Instance;
        int currentScore = scoreKeeper != null ? scoreKeeper.GetScore() : 0;
        if (currentScore != lastScore)
        {
            scoreText.text = currentScore.ToString("000000000");
            lastScore = currentScore;
        }
    }
}
