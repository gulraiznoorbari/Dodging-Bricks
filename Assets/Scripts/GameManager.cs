using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _livesText;
    [SerializeField] private GameObject _gameOverMenu;

    public static GameManager instance;
    private static int life = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        life = 3;
        _livesText.text = life.ToString();
    }

    public void AddLife(int num)
    {
        if (life < 1)
        {
            GameOverMenu();
        }
        else
        {
            life += num;
            _livesText.text = life.ToString();
        }
    }

    public int GetLives()
    {
        return life;
    }

    private void GameOverMenu()
    {
        Time.timeScale = 0f;
        _gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
