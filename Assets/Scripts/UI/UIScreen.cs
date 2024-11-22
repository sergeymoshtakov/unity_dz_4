using TMPro;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text healthText;

    private void OnEnable()
    {
        player.OnScoreChangeEvent += OnScoreChangeEvent;
        player.OnHealthChangeEvent += OnHealthChangeEvent;
    }

    private void OnDisable()
    {
        player.OnScoreChangeEvent -= OnScoreChangeEvent;
        player.OnHealthChangeEvent -= OnHealthChangeEvent;
    }

    private void OnScoreChangeEvent(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }

    private void OnHealthChangeEvent(int newHealth)
    {
        healthText.text = $"Health: {newHealth}";
    }
}
