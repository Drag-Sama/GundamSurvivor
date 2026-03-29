using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDetection : MonoBehaviour
{
    //Detecte si un objet rentre dans le collider
    [SerializeField] string tagName; //nom du tag de l'objet qu'on veut detecter
    public bool isIn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName))
        {
            isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName))
        {
            isIn = false;
        }
    }
}
