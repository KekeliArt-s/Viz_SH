using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public List<GameObject> parts = new List<GameObject>();

    public void SetPartVisibility(int index, bool visible)
    {
        if (index >= 0 && index < parts.Count)
        {
            parts[index].SetActive(visible);
        }
    }
}
