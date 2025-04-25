using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class PanelController : MonoBehaviour
{
    public GameObject panel; // Référence au panneau à afficher/masquer

    void Start()
    {
        // Assurez-vous que le panneau est désactivé au début
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Méthode pour afficher le panneau
    public void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    // Méthode pour masquer le panneau
    public void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Méthode pour basculer l'affichage du panneau
    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
