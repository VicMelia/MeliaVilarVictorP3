using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IQTimer : MonoBehaviour
{
    public GameObject Cronometro;
    public bool gameOver;
    public float seconds;
    public MenuTutorial menuTutorialScript;
    void Start()
    {

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false && menuTutorialScript.menu_tutorial == false)
            seconds += Time.deltaTime;

        if (seconds >= 127f)
        {
            gameOver = true;
        }


    }
}
