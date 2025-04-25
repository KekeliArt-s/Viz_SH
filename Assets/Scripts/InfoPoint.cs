using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using TMPro;

public class InfoPoint : MonoBehaviour
{
    [TextArea]
    public string TxtInfoPoint ;

    [SerializeField] TextMeshProUGUI txt ;

    [SerializeField] GameObject panel ;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = TxtInfoPoint ;
    }
     
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true) ;
        }
    }

     private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false) ;
        }
    }
}
