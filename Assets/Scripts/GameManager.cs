using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public int score = 0;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Awake()
    {
       int numGameSessions = FindObjectsOfType<GameManager>().Length;

       if (numGameSessions > 1)
       {
        Destroy(gameObject);
       } 
       else
       {
        DontDestroyOnLoad(gameObject);
       }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
   
   void ResetGameSession()
   {
        FindObjectOfType<ScenePersist>().ResetScenes();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
   }

   void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }
}
