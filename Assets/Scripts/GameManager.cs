using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}
    [SerializeField] TextMeshProUGUI textGameOver;
    [SerializeField] Button restartButton;
    public bool gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameOver = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOver = true;
        textGameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
