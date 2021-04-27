using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private CanvasGroup gameOverPanel;
    [SerializeField] private CanvasGroup gameWinPanel;


    private void OnEnable()
    {
        ScoreZone.OnScoreChanged += ScoreZone_OnScoreChanged;
    }

    private void OnDisable()
    {
        ScoreZone.OnScoreChanged -= ScoreZone_OnScoreChanged;
    }

    private void ScoreZone_OnScoreChanged(int score)
    {
        scoreText.text = "Cubes : " + score;
    }

    public void FadeGameOverScreen(float time)
    {
        gameOverPanel.DOFade(1, time);
    }

    public void FadeGameWinScreen(float time)
    {
        gameWinPanel.DOFade(1, time);
    }

}
