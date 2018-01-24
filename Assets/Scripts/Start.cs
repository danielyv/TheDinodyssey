using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("MiniJeu1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
