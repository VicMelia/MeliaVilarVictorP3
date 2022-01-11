using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public bool gravSwap;
    bool gravRot;
    bool gravFlip;
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {




        if (gravSwap == true)
        {

            mainCamera.transform.rotation = Quaternion.Euler(0, 0, 180);
            playerMovementScript.rb.gravityScale = -1;

            gravRot = true;



            //PERSONAJE MIRA IZQUIERDA
            if (gravRot == true && playerMovementScript.facingRight == false)
            {
                playerMovementScript.Player.transform.rotation = Quaternion.Euler(0, 0, 180);
                playerMovementScript.rb.gravityScale = 0;

            }

            //PERSONAJE MIRA DERECHA
            if (gravRot == true && playerMovementScript.facingRight == true)
            {
                playerMovementScript.Player.transform.rotation = Quaternion.Euler(0, 180, 180);
                playerMovementScript.rb.gravityScale = 0;

            }

        }
        else
        {
            mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gravSwap = true;







        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gravSwap = false;
            playerMovementScript.Player.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }


}