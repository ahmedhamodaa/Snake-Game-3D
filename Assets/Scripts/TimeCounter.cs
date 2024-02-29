using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text timeText;
    private float timer = 0f;

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Format the timer as minutes and seconds
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        // Update the UI Text
        timeText.text = minutes + ":" + seconds;
    }
}
