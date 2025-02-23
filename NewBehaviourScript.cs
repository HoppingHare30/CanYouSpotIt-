using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timeLeft = 10f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();
    }
}

