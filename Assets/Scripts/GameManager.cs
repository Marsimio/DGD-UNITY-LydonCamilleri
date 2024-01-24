using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Button easyButton, mediumButton, hardButton;
    public int Difficulty;
    public TextMeshProUGUI healthText;
    private int totalEnemies;
    private int enemiesDefeated;

    protected override void Awake()
    {
        base.Awake();
        MaintainOne();
        AddListeners();
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        findHP();
    }

    private void MaintainOne()
    {
        int numOfGameManager = FindObjectsOfType<GameManager>().Length;
        if (numOfGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            this.gameObject.SetActive(true);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void AddListeners()
    {
        if (easyButton != null)
            easyButton.onClick.AddListener(() => {
                SetDifficulty(1);
                LoadScene("Level 1");
            });

        if (mediumButton != null)
            mediumButton.onClick.AddListener(() => {
                SetDifficulty(2);
                LoadScene("Level 1");
            });

        if (hardButton != null)
            hardButton.onClick.AddListener(() => {
                SetDifficulty(3);
                LoadScene("Level 1");
            });
    }

    public void SetDifficulty(int difficulty)
    {
        Difficulty = difficulty;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void findHP()
    {
        GameObject hpGameObject = GameObject.Find("Canvas/HP");
        if (hpGameObject != null)
        {
            healthText = hpGameObject.GetComponent<TextMeshProUGUI>();
            PlayerDamage();
        }
        else
        {
            Debug.Log("HP GameObject not found in scene.");
        }
    }

    public void SetTotalEnemies(int number)
    {
        totalEnemies = number;
        enemiesDefeated = 0;
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        CheckForLevelCompletion();
    }

    private void CheckForLevelCompletion()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" && enemiesDefeated >= totalEnemies)
        {
            GameData.enemyCount = 0;
            LoadScene("Level 2");
        }
        if (SceneManager.GetActiveScene().name == "Level 2" && enemiesDefeated >= totalEnemies)
        {
            LoadScene("Game End");
        }
    }
    public void PlayerDamage()
    {
        if (GameData.PlayerHealth <= 0 && SceneManager.GetActiveScene().name != "Game End")
        {
            LoadScene("Game End");
        }
        else
        {
            healthText.text = "Health: " + GameData.PlayerHealth.ToString();
        }

    }
}