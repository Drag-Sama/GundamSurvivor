using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZone : MonoBehaviour
{
    [SerializeField] GameObject nextDialogueZone;
    [SerializeField] string[] dialogue;
    GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.GetComponent<LevelManager>().OpenDialogue(dialogue);
            if(nextDialogueZone != null)
            {
                nextDialogueZone.gameObject.SetActive(true);
            }
            Destroy(this.gameObject);
        }
        
    }

}
