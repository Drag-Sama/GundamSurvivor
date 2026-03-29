using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndPage : MonoBehaviour
{
    [SerializeField] TMP_Text destroyedText;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] GameObject page;

    public void InitUI(int score, int nbDestroy)
    {
        page.SetActive(true);
        pointsText.text = score.ToString();
        destroyedText.text = "x" + nbDestroy.ToString();
    }
}
