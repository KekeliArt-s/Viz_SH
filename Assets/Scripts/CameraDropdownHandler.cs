using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CameraDropdownHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public CameraController cameraController;
    public ProductManager productManager;
    public Material transparentMaterial;
    public Transform[] viewPoints;
    public GameObject descriptionPanel; // Add this variable
    public TMP_Text descriptionText; // Add this variable

    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    void Start()
    {
        if (dropdown != null && cameraController != null && productManager != null)
        {
            dropdown.ClearOptions();

            List<string> partNames = new List<string>();
            foreach (GameObject part in productManager.parts)
            {
                partNames.Add(part.name);
            }
            dropdown.AddOptions(partNames);

            dropdown.onValueChanged.AddListener(DropdownValueChanged);
        }
        else
        {
            Debug.LogError("Assurez-vous que le dropdown, le cameraController, et le productManager sont assignés dans l'inspecteur.");
        }
    }

    void DropdownValueChanged(int value)
    {
        if (value >= 0 && value < productManager.parts.Count && value < viewPoints.Length)
        {
            cameraController.SetTarget(viewPoints[value]);
            cameraController.SetFollowing(true);

            // Display the description panel and update the description text
            descriptionPanel.SetActive(true);
            descriptionText.text = productManager.parts[value].GetComponent<PartDescription>().description;

            for (int i = 0; i < productManager.parts.Count; i++)
            {
                GameObject obj = productManager.parts[i];
                Renderer renderer = obj.GetComponent<Renderer>();

                if (renderer != null)
                {
                    if (i == value)
                    {
                        if (originalMaterials.ContainsKey(renderer))
                        {
                            renderer.material = originalMaterials[renderer];
                            originalMaterials.Remove(renderer);
                        }
                        productManager.SetPartVisibility(i, true);
                    }
                    else
                    {
                        if (!originalMaterials.ContainsKey(renderer))
                        {
                            originalMaterials[renderer] = renderer.material;
                        }
                        renderer.material = transparentMaterial;
                        productManager.SetPartVisibility(i, false);
                    }
                }
            }
        }
        else
        {
            cameraController.SetTarget(null);
            cameraController.SetFollowing(false);

            // Hide the description panel
            descriptionPanel.SetActive(false);

            foreach (KeyValuePair<Renderer, Material> pair in originalMaterials)
            {
                pair.Key.material = pair.Value;
            }
            originalMaterials.Clear();

            for (int i = 0; i < productManager.parts.Count; i++)
            {
                productManager.SetPartVisibility(i, true);
            }
        }
    }
}
