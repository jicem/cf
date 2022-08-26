using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image currentHealthbar;
    public Text ratioText;

    private float hitpoint = 100;
    private float maxHitpoint = 100;
    private bool death;
    public Animator anim;
    private float time;


    private void Start()
    {
        UpdateHealthbar();
        anim = GetComponent<Animator>();
    }


    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        //ratioText.text = (ratio*100).ToString("0") + '%';
    }

    private void TakeDamage(float damage)
    {
        hitpoint -= damage;

        if(hitpoint <= 0.0f)
        {
            hitpoint = 0;
            Debug.Log("Dead!");
            anim.SetBool("death", true);
            Invoke("GameOverWinScreen", 3);
        }
        UpdateHealthbar();
    }

    public float getHitpoints()
    {
        return hitpoint;
    }
    
    private void GameOverWinScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }


}
