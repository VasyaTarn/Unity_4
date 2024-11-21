using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private TMP_Text hpUI;
    [SerializeField] private Button restartBtn;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setScoreUI(int score)
    {
        scoreUI.text = "Score: " + score;
    }

    public void setHPUI(int hp)
    {
        hpUI.text = "HP: " + hp;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public Button getRestartButton()
    {
        return restartBtn;
    }

}
