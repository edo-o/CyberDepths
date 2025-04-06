using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthSystem playerHealth;
    public GameObject gameOverPanel;

    public static GameManager instance;
    private bool isGameOver = false;

    void Start()
    {

    }


    void Update()
    {

    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayerDefeated()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            GameOver();
        }
    }
}
