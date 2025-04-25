using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform target; // L'asset cible que la flèche doit pointer
    //public Transform player; // Le joueur (FPS)
    //public Camera playerCamera; // La caméra du joueur pour orienter la flèche correctement

    void Update()
    {
       /*  if (target != null && player != null)
        {
            // Calculer la direction de la cible par rapport au joueur
            Vector3 directionToTarget = target.position - player.position;
            directionToTarget.y = 0; // Garder uniquement la direction horizontale

            // Calculer l'angle de rotation nécessaire pour que la flèche pointe vers la cible
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Appliquer la rotation à la flèche
            transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y - playerCamera.transform.eulerAngles.y, 0);
        } */
        transform.LookAt(target.transform.position) ;
    }

}

