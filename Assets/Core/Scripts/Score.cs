using R3;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TMP_Text scoreText;
    
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        GameState.Instance.Score.Subscribe(OnScoreChanged).AddTo(this);
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = score.ToString();
    }
}
