using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    ASM_MN ASM_MN;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        ASM_MN = FindObjectOfType<ASM_MN>();
    }

    void Start()
    {
        int score = ScoreKeeper.Instance != null ? ScoreKeeper.Instance.GetScore() : 0;
        scoreText.text = "You Scored:\n" + score;

        if (ASM_MN != null && ScoreKeeper.Instance != null)
        {
            int id = ScoreKeeper.Instance.GetID();
            string playerName = ScoreKeeper.Instance.GetUserName();
            int scorePlayer = ScoreKeeper.Instance.GetScore();
            int regionId = ScoreKeeper.Instance.GetIDregion();

            ASM_MN.XuLiDuLieu(id, playerName, scorePlayer, regionId);
        }
        else
        {
            Debug.LogError("LỖI: Không tìm thấy ASM_MN hoặc ScoreKeeper!");
        }
    }
}
