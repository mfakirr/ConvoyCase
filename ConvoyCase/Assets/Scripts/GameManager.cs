using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    [SerializeField]
    Text UIHealtCounter = default;

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void UIHealtControl(int health)
    {
        UIHealtCounter.text = "" + health;
    }

}
