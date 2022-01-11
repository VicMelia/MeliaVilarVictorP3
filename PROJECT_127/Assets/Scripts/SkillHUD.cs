using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHUD : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public IQTimer IQTimerScript;
    public GameObject sprint_disabled;
    public GameObject jump_disabled;
    public GameObject doubleJump_disabled;
    public GameObject wallJump_disabled;
    public GameObject dash_disabled;


    // Start is called before the first frame update
    void Start()
    {
        sprint_disabled.SetActive(true);
        jump_disabled.SetActive(true);
        doubleJump_disabled.SetActive(true);
        wallJump_disabled.SetActive(true);
        dash_disabled.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(IQTimerScript.seconds < 15f || playerMovementScript._sprint == true)
        {
            sprint_disabled.SetActive(true);
        }


        if (IQTimerScript.seconds >= 15f && playerMovementScript._sprint == false)
        {
            sprint_disabled.SetActive(false);
        }
       

        if (IQTimerScript.seconds >= 30f && playerMovementScript.jumped == false)
        {
            jump_disabled.SetActive(false);
        }

        else
        {
            jump_disabled.SetActive(true);
        }

        if (IQTimerScript.seconds >= 45f && playerMovementScript.doubleJumped == false)
        {
            doubleJump_disabled.SetActive(false);
        }

        else
        {
            doubleJump_disabled.SetActive(true);
        }

        if (IQTimerScript.seconds >= 60f && playerMovementScript.wallstucked == false)
        {
            wallJump_disabled.SetActive(false);
        }
        else
        {

            wallJump_disabled.SetActive(true);
        }

        if (IQTimerScript.seconds >= 75f && playerMovementScript.canTP == true)
        {
            dash_disabled.SetActive(false);
        }

        else
        {
            dash_disabled.SetActive(true);
        }




    }
}
