using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    //The materials (colors) of the platforms (for the colorblind mode).
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    //Start the game.
	public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
		SceneManager.LoadScene("maze");
    }

    //Exit the game.
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
