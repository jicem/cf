using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieSceneManager : MonoBehaviour {

    public Texture2D bg;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bg);
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "DRAW!");
        if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "REMATCH!"))
            UnityEngine.SceneManagement.SceneManager.LoadScene("BasicArena");
        if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Character Select!"))
            UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
        if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 100, 100, 50), "Home" + ""))
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
