using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Calculate hours, minutes, and seconds
        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Format the time string
        string timeString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        // Update the TMP text component
        clockText.text = timeString;
    }
}
