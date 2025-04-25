using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

[SerializeField]
private float speed = 4f ;

private Vector3 deplacement=Vector3.zero ;
   
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.UpArrow)) 
       {
        deplacement = Vector3.forward ;
               } 
                if (Input.GetKey(KeyCode.DownArrow)) 
       {
        deplacement = Vector3.back ;
               } 
                if (Input.GetKey(KeyCode.LeftArrow)) 
       {
        deplacement = Vector3.left ;
               } 
                if (Input.GetKey(KeyCode.RightArrow)) 
       {
        deplacement = Vector3.right ;
               } 
               transform.Translate (deplacement * speed * Time.deltaTime) ; 
    }
}
