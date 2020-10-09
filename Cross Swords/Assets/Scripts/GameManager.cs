using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    void QuitButton()
    {
        Application.Quit();
    }

    public void ToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ToLose()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
