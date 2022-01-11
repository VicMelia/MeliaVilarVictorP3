using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    public bool pinchos;
    public LayerMask pinchosMask;

    public IQTimer iqTimerScript;
    public PlayerMovement playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pinchos = Physics2D.IsTouchingLayers(playerMovementScript.bc, pinchosMask);

        if(pinchos == true)
        {
            iqTimerScript.gameOver = true;
        }


    }
}
