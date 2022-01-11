using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
   
    public IQTimer IQtimerScript;
    private Text texto;
   
    
    void Start()
    {

        texto = GetComponent<Text>();

        
    }

    // Update is called once per frame
    void Update()
    {

        string textoReloj;

        if (IQtimerScript.gameOver == false)
        {
            textoReloj = IQtimerScript.seconds.ToString("00");

            texto.text = textoReloj;
        }
            

        


    }
}
