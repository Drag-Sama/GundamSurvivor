using TMPro;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
     TMP_Text text;
    PlayerMovement pm;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        int speed = (int)pm.actualSpeed();
        text.text = speed.ToString() + "m/s";
    }
}
