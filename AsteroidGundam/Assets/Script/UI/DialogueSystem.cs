using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialogueNpc;

    [SerializeField] Sprite npcSprite;
    public string[] dialogue;
    int index;

    [SerializeField] float wordSpeed;

    private void Start()
    {
        Talk();
    }

    public void Talk()
    {
        dialoguePanel.SetActive(true);
        dialogueNpc.GetComponent<Image>().sprite = npcSprite;
        dialogueNpc.GetComponent<Animator>().SetTrigger("In");
        StartCoroutine(Typing());
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        StartCoroutine(Out());
    }

    void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        yield return new WaitForSeconds(1.5f);
        NextLine();
    }

    IEnumerator Out()
    {
        dialogueNpc.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(0.2f);
        dialoguePanel.SetActive(false);
    }
}
