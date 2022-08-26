using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMenu : MonoBehaviour {

    public Texture2D background;
    public Texture2D bg;
    public string btnText = "";
    public string nextScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),bg);
        if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 + 100,200,50), btnText))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
