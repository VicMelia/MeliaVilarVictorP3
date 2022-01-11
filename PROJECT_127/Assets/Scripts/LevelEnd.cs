using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public bool levelEnd;
    public LayerMask endMask;

    public IQTimer iqTimerScript;
    public PlayerMovement playerMovementScript;
    public GameObject menuFinal;


    // Start is called before the first frame update
    void Start()
    {
        menuFinal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        levelEnd = Physics2D.IsTouchingLayers(playerMovementScript.bc, endMask);

        if(levelEnd == true)
        {
            iqTimerScript.gameOver = true;
            menuFinal.SetActive(true);
        }
    }
}
