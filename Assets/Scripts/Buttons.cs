using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Buttons : MonoBehaviour
{

    public GameObject CreditsPanel;
    public GameObject PausePanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditsOn()
    {
        CreditsPanel.SetActive(true);
    }

    public void CreditsOff()
    {
        CreditsPanel.SetActive(false);
    }

    public void PauseOn()
    {
        PausePanel.SetActive(true);
    }

    public void PauseOff()
    {
        PausePanel.SetActive(false);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
