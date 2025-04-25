using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    public GameObject loadingImagePrefab; // Prefab for loading animation
    public TMP_Text loadingText; // TextMeshPro text for "Loading..."

    private GameObject loadingImageInstance; // Instance of the loading image

    void Start()
    {
        // Instantiate the loading image prefab
        loadingImageInstance = Instantiate(loadingImagePrefab, transform);

        // Start the asynchronous loading of the scene
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // Retrieve the scene name to load from PlayerPrefs
        string sceneToLoad = PlayerPrefs.GetString("SceneToLoad");

        // Start loading the scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        // Ensure the scene does not activate immediately when loaded
        operation.allowSceneActivation = false;

        // Set the loading text
        loadingText.text = "Loading...";

        while (!operation.isDone)
        {
            // Check if the load has finished
            if (operation.progress >= 0.9f)
            {
                // Optionally display a message or animation here
                loadingText.text = "Press any key to continue...";
                // Wait for user input to continue
                if (Input.anyKeyDown)
                {
                    // Allow the scene to activate
                    operation.allowSceneActivation = true;
                }
            }
            else
            {
                // Update loading text with progress
                loadingText.text = "Loading... " + (operation.progress * 100f).ToString("F0") + "%";
            }

            // Rotate the loading image
            loadingImageInstance.transform.Rotate(Vector3.forward * Time.deltaTime * 100);

            yield return null;
        }
    }
}
