using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("A");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayGame1()
    {
        SceneManager.LoadScene("MiniJeu1");
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("MiniJeu2");
    }
    public void PlayGame3()
    {
        SceneManager.LoadScene("MiniJeu3");
    }
}
