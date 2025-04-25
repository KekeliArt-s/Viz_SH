using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightController : MonoBehaviour
{
    public TMP_Dropdown objectDropdown; // Reference to the UI Dropdown
    public List<GameObject> selectableObjects = new List<GameObject>(); // List of selectable game objects
    public Material highlightMaterial; // Reference to the highlight Material
    private List<Material[]> originalMaterials = new List<Material[]>(); // Store original materials

    private void Start()
    {
        // Populate the dropdown options with game object names
        List<string> objectNames = new List<string>();
        foreach (GameObject obj in selectableObjects)
        {
            objectNames.Add(obj.name);
           // originalMaterials.Add(obj.GetComponent<Renderer>().materials); // Store original materials
        }
        objectDropdown.ClearOptions();
        objectDropdown.AddOptions(objectNames);

        // Set the initial selection (optional)
        objectDropdown.value = 0; // Select the first option by default
        OnObjectSelectionChanged(0); // Call the method to handle the initial selection
    }

    // Called when the dropdown selection changes
    public void OnObjectSelectionChanged(int selectedIndex)
    {
        // Remove highlight from all game objects
        for (int i = 0; i < selectableObjects.Count; i++)
        {
            GameObject obj = selectableObjects[i];
            var renderers = obj.GetComponentsInChildren<Renderer>();
            foreach (var renderer in renderers)
            {
                renderer.materials = originalMaterials[i]; // Reset materials
            }
        }

        // Highlight the selected game object
        if (selectedIndex >= 0 && selectedIndex < selectableObjects.Count)
        {
            GameObject selectedObject = selectableObjects[selectedIndex];
            var selectedRenderers = selectedObject.GetComponentsInChildren<Renderer>();
            foreach (var renderer in selectedRenderers)
            {
                Material[] materials = renderer.materials;
                Material[] newMaterials = new Material[materials.Length + 1];
                materials.CopyTo(newMaterials, 0);
                newMaterials[materials.Length] = highlightMaterial;
                renderer.materials = newMaterials;
            }
        }
    }
}
