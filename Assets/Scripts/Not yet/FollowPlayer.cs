using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player ;
    private Vector3 offset = new Vector3 (0, (float)6.3,-10);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
        //Offset the camera behind the player 
        //transform.position = player.transform.position + offset ;
   // }

    // To smooth the camera's transform
    void LateUpdate()
    {
        //Offset the camera behind the player 
        transform.position = player.transform.position + offset ; 
    }
}
