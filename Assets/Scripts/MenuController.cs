using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Ajoutez cette ligne
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public AudioSource clickSound; 
    // Assurez-vous d'attacher ce script à un objet vide dans votre scène de menu

    // Méthode appelée lorsque l'utilisateur clique sur un bouton
    public void LoadMachineScene(string machineName)
    {
        // Charge la scène correspondant au nom de la machine
        PlayerPrefs.SetString("SceneToLoad", machineName);
        StartCoroutine(LoadSceneAsync(machineName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Affiche la scène de chargement
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LoadingScene");

        // Attend que la scène de chargement soit complètement chargée
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Charge la scène de la machine de manière asynchrone
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Attend que la scène de la machine soit complètement chargée
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        // Quitte le jeu
        Application.Quit();
    }

    public void clickEffect()
    {
        clickSound.Play();
    }

}
