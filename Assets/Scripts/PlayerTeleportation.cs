using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    public List<Transform> teleportationZones;
    public KeyCode teleportKey = KeyCode.T;
    public FadeTransition fadeTransition;

    private int currentTeleportationIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(teleportKey))
        {
            StartCoroutine(TeleportWithFade());
        }
    }

    private IEnumerator TeleportWithFade()
    {
        if (teleportationZones.Count == 0)
        {
            Debug.LogWarning("Aucune zone de t�l�portation n'est d�finie !");
            yield break;
        }

        fadeTransition.StartFadeInOut();

        // Attendre que le fade in soit termin�
        yield return new WaitForSeconds(fadeTransition.fadeDuration / 2);

        currentTeleportationIndex = (currentTeleportationIndex + 1) % teleportationZones.Count;
        Transform targetZone = teleportationZones[currentTeleportationIndex];
        Vector3 newPosition = targetZone.position;

        // Met � jour la position et l'orientation du joueur
        transform.position = newPosition;
        transform.rotation = targetZone.rotation;

        // Attendre que le fade out soit termin�
        yield return new WaitForSeconds(fadeTransition.fadeDuration / 2);
    }
}
