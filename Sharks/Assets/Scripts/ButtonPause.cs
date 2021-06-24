using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{
    private bool Pauseeeed = false;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Pausee()
    {
        Time.timeScale = 0;
        Pauseeeed = true;
        panel.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        Pauseeeed = false;
        panel.SetActive(false);
    }

    public void Exiit()
    {
        Application.Quit();
    }

    public void ReStart()
    {
        SceneManager.LoadScene("LevelScene");
        Time.timeScale = 1;
    }
}
