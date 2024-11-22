using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;

    private int score;

    public event UnityAction<int> OnScoreChangeEvent;
    public event UnityAction<int> OnHealthChangeEvent;

    private void Start()
    {
        OnHealthChangeEvent?.Invoke(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            score += coin.CoinValue;
            OnScoreChangeEvent?.Invoke(score);
        }
        else if (collision.TryGetComponent(out Enemy enemy))
        {
            if (enemy.Damage < 0)
            {
                return;
            }

            health -= enemy.Damage;
            OnHealthChangeEvent?.Invoke(health);
        }
    }
}
