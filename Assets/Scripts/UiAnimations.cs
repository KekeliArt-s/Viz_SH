using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using DentedPixel;
using UnityEngine.UI;
public class UiAnimations : MonoBehaviour
{
    [SerializeField]
    GameObject playButton, quitButton, optionsButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayButton();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    [SerializeField]
    void PlayButton()
    {
        LeanTween.scale(playButton, new Vector3(1f, 1f, 1f), 2f).setDelay(.8f).setEase(LeanTweenType.easeOutElastic);
    }
}
