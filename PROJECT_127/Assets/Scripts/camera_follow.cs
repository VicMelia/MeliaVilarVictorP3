using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{

    public GameObject follow;
    public Vector2 minCamPos;
    public Vector2 maxCamPos;
    public float smoothTime;

    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
        float y = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(Mathf.Clamp(x, minCamPos.x, maxCamPos.x), Mathf.Clamp(y, minCamPos.y, maxCamPos.y), transform.position.z);
    }
}
