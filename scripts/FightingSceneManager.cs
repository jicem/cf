using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingSceneManager : MonoBehaviour {

    private float remainingTime;
    public Transform canvas;

    // Use this for initialization
    void Start () {
        remainingTime = 90.0f;
        canvas.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            remainingTime -= Time.deltaTime;

            //if(GameObject.Find("P1")..getHitpoints())
        }
	}

    void OnGUI()
    {
        if (remainingTime <= 0.0f)
        {
            Tie();
        }
        GUI.Box(new Rect(Screen.width / 2 - 25, 20, 50, 50), "" + (int) remainingTime);
    }

    void Tie()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Draw");
    }
    public void Win()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }

    public float getRemainingTime()
    {
        return remainingTime;
    }
}
