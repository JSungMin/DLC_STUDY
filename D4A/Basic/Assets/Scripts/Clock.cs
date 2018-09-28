using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	public Transform hoursTransform;
	public Transform minutesTransfrom;
	public Transform secondsTransform;
	public bool continuous = true;
	public float degreePerHour = 30f;
	public float degreePerMinute = 6f;
	public float degreePerSecond = 6f;

	void Update ()
	{
		if (continuous)
			UpdateContinuous();
		else
			UpdateDiscreate();
	}
	void UpdateContinuous ()
	{
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursTransform.localRotation = Quaternion.Euler (0f, (float)time.TotalHours * degreePerHour, 0f);
		minutesTransfrom.localRotation = Quaternion.Euler (0f, (float)time.TotalMinutes * degreePerMinute, 0f);
		secondsTransform.localRotation = Quaternion.Euler (0f, (float)time.TotalSeconds * degreePerSecond, 0f);
	}
	void UpdateDiscreate()
	{
		DateTime time = DateTime.Now;
		hoursTransform.localRotation = Quaternion.Euler (0f, time.Hour * degreePerHour, 0f);
		minutesTransfrom.localRotation = Quaternion.Euler (0f, time.Minute * degreePerMinute, 0f);
		secondsTransform.localRotation = Quaternion.Euler (0f, time.Second * degreePerSecond, 0f);
	}
}
