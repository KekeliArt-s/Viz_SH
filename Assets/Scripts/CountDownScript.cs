using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    [SerializeField]
    private int startCountDown = 60;
    
    
    [SerializeField]
    TextMeshProUGUI TxtCountDown ;
    void Start()
    {
        TxtCountDown.text = "Temps restant : " + startCountDown;
        StartCoroutine(Pause()) ;
    }

    IEnumerator Pause()
    {
        while (startCountDown>0)
        {
            yield return new WaitForSeconds(1f) ;
            startCountDown--;
            TxtCountDown.text = "Temps restant : " + startCountDown;     
        }
        SceneManager.LoadScene("Choice_Menu");
       // GameObject.Find("Player").GetComponent<PlayerController1>().GameOver();
        
    }
}
