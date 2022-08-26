using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public Texture2D bg;
    public string btnText = "";
    public string nextScene;
    public Texture2D character1;
    private bool p1 = false;
    private bool p2 = false;
    public Texture2D player1;
    public Texture2D player2;
    private bool C1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bg);
        if(p1)
            GUI.DrawTexture(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 120, 140, 140), player1);
        if(p2)
            GUI.DrawTexture(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 110, 120, 120), player2);
        C1 = GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 100), character1);
        if (C1 && !p1)
        {
            p1 = true;
            OnGUI();
        }
        else if (C1 && p1)
        {
            p2 = true;
            OnGUI();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 50), btnText) && p1 && p2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
