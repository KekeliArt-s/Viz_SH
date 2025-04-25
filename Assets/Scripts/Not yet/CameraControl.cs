using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player ;
    private Vector3 offset;
    [SerializeField] int rotationSpeed = 2;
    [SerializeField] bool rotationCam = true ;

    public Camera mainCamera;
    public Camera hoodCamera1;
    public Camera hoodCamera2;
    public Camera hoodCamera3;
    public Camera hoodCamera4;
    public Camera hoodCamera5;
    public Camera hoodCamera6;
    public KeyCode switchKey1;
    public KeyCode switchKey2;
    public KeyCode switchKey3;
    public KeyCode switchKey4;
    public KeyCode switchKey5;
    public KeyCode switchKey6;

    // Start is called before the first frame update
    void Start()
    {
     offset = transform.position - player.transform.position ;   
    }
    private void Update () 
    {
       //if(Input.GetKeyDown(switchKey1))
        //{
        // mainCamera.enabled = !mainCamera.enabled;
        // hoodCamera.enabled = !hoodCamera.enabled;
       // }
       if (Input.GetKeyDown(switchKey1))
{
     mainCamera.enabled = !mainCamera.enabled;
     hoodCamera1.enabled = !hoodCamera1.enabled;
}
else if (Input.GetKeyDown(switchKey2))
{
    mainCamera.enabled = !mainCamera.enabled;
    hoodCamera2.enabled = !hoodCamera2.enabled;
}
else if (Input.GetKeyDown(switchKey3))
{
    mainCamera.enabled = !mainCamera.enabled;
    hoodCamera3.enabled = !hoodCamera3.enabled;
}
else if (Input.GetKeyDown(switchKey4))
{
    mainCamera.enabled = !mainCamera.enabled;
    hoodCamera4.enabled = !hoodCamera4.enabled;
}
else if (Input.GetKeyDown(switchKey5))
{
    mainCamera.enabled = !mainCamera.enabled;
    hoodCamera5.enabled = !hoodCamera5.enabled;
}
else if (Input.GetKeyDown(switchKey6))
{
    mainCamera.enabled = !mainCamera.enabled;
    hoodCamera6.enabled = !hoodCamera6.enabled;
}
// Ajoutez d'autres conditions avec des "else if" si nécessaire
else
{
    // Code à exécuter si aucune des conditions précédentes n'est vraie
}

    }
 private void LateUpdate ()
  {
    transform.position = player.transform.position + offset ;
  
  if (rotationCam)
  {
    Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed ,Vector3.up );
    offset = turnAngle * offset ;

    transform.LookAt(player.transform);
  }
  
}
}
