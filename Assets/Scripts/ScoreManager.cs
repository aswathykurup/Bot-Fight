using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] private int score = 0;
    public TextMeshProUGUI scoretext;

    [SerializeField] private int playerHealth = 100;
    public TextMeshProUGUI healthtext;

    public TextMeshProUGUI gametext;
    private bool isPaused = false;

    public GameObject pauseMenu;

    public GameObject GameOverMenu;

    [SerializeField] private PlayerController player;

    [SerializeField] private float bulletSpeed = 20;


    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Otherwise, set this as the only instance.
            Instance = this;
            // Optional: Prevents the GameObject from being destroyed when loading new scenes.
           // DontDestroyOnLoad(this.gameObject);
        }

        GameOverMenu.SetActive(false);
        gametext.gameObject.SetActive(false);

        pauseMenu.SetActive(false);
    }

    public void UpdateScore()
    {
        score ++;
        scoretext.text = score.ToString();
        if(score == 20)
        {
            GameOver();
        }
    }
    public void UpdateHealth(int damage, bool restore)
    {

        if (restore)
        {
            playerHealth = 100;
        }
        else
        {
            playerHealth -= damage;
            if (playerHealth <= 0)
            {
                GameOver();
            }
        }
           
        healthtext.text = playerHealth.ToString();
        

    }
    private void GameOver()
    {
        GameOverMenu.SetActive(true);
        gametext.gameObject.SetActive(true);
        Time.timeScale = 0f;

        if (score == 20)
        {
            gametext.text = "You win";
        }

    }

    public void PauseGame()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void Quit()
    {
        Application.Quit(); 

    }
    public void UpdateSpeed()
    {
        player.moveSpeed += 3;
    }
    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
    public void UpdatebulletSpeed()
    {
        bulletSpeed += 10;
    }
}
