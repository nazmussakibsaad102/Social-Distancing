using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMaster : MonoBehaviour
{
    public GameObject restartPanel;
    public Text Score = null;
    private bool aslost;
    private void Update()
    {
        if (aslost == false)
        {
            Score.text = "Score: " +  Time.time.ToString("f0");
        }
       
    }
    public void GameOver()
    {
        aslost = true;

        Invoke("delay", .4f);
    }
    public void delay()
    {
        restartPanel.SetActive(true);

    }
   public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
