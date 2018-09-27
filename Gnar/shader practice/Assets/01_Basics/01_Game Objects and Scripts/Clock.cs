using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform hourTransform, minutesTransform, secondsTransform;
    public bool continuous;

    private float degreePerHour = 30f;
    private float degreePerMinutes = 6f;
    private float degreePerSeconds = 6f;

    private void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreePerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreePerMinutes, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreePerSeconds, 0f);
    }

    private void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        hourTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreePerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreePerMinutes, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreePerSeconds, 0f);
    }
	
	void Update ()
    {
        if (continuous)
            UpdateContinuous();
        else
            UpdateDiscrete();
    }
}
