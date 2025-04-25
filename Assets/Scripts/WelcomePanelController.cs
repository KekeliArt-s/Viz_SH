using UnityEngine;
using UnityEngine.UI;

public class WelcomePanelController : MonoBehaviour
{
    public GameObject welcomePanel; // Référence au panel de bienvenue
    public Button okButton; // Référence au bouton OK
    public GameObject[] elementsToActivate; // Les éléments de la scène à activer après avoir cliqué sur OK

    void Start()
    {
        // S'assurer que le panel est actif au démarrage
        if (welcomePanel != null)
        {
            welcomePanel.SetActive(true);
        }

        // Désactiver les éléments de la scène au démarrage
        foreach (GameObject element in elementsToActivate)
        {
            element.SetActive(false);
        }

        // Ajouter un écouteur pour le bouton OK
        if (okButton != null)
        {
            okButton.onClick.AddListener(StartScene);
        }
    }

    void StartScene()
    {
        // Désactiver le panel de bienvenue
        if (welcomePanel != null)
        {
            welcomePanel.SetActive(false);
        }

        // Activer les éléments de la scène
        foreach (GameObject element in elementsToActivate)
        {
            element.SetActive(true);
        }
    }
}
