using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private variables
    private float speed = 20.0f;
    private float turnSpeed = 15.0f;
    private float horizontaInput;
    private float forwardInput;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public string inputID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(0,0,1);
        //Player Input response
        horizontaInput = Input.GetAxis("Horizontal" +inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);
        // We move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontaInput );
        // Smooth Vehicle rotation
        transform.Rotate(Vector3.up ,Time.deltaTime * turnSpeed * horizontaInput  );
        if(Input.GetKeyDown(switchKey))
        {
         mainCamera.enabled = !mainCamera.enabled;
         hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
