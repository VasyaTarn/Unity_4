using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 10;
    
    private int score;

    public int Health
    {
        get => health; 
        set
        {
            health = value;
            OnHealthFieldChanged();
        }
    }

    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreFieldChanged();
        }
    }

    private void Start()
    {
        UIManager.Instance.setHPUI(health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            Score += coin.CoinValue;
        } 
        else if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.Damage < 0)
                return;

            Health -= enemy.Damage;
        }

        if(Health == 0)
        {
            Time.timeScale = 0f;
            UIManager.Instance.getRestartButton().gameObject.SetActive(true);
        }
    }

    private void OnHealthFieldChanged()
    {
        UIManager.Instance.setHPUI(health);
    }

    private void OnScoreFieldChanged()
    {
        UIManager.Instance.setScoreUI(score);
    }
}
