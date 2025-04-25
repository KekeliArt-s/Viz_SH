using UnityEngine;

public class PartDescription : MonoBehaviour
{
    public string description;

    void Start()
    {
        // Load the description dynamically based on the part's name
        description = LoadDescription(gameObject.name);
    }

    string LoadDescription(string partName)
    {
        // Replace this with your own logic to load the description dynamically
        // For example, you can use a text file or a database to store the descriptions
        switch (partName)
        {
            case "Part1":
                return "This is the description of Part 1";
            case "Part2":
                return "This is the description of Part 2";
            case "Part3":
                return "This is the description of Part 3";
            default:
                return "Description not available";
        }
    }
}
