using UnityEngine;
using System;

public class ScoreZone : MonoBehaviour
{
    private int score;

    #region EVENTS

    public static event Action<int> OnScoreChanged;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
            score++;
            OnScoreChanged?.Invoke(score);
        }
    }
}
