using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
	public Transform pointPrefab;

	public Transform[] points;
	public float step = 0.2f;
	public float size = 0.2f;
	[Range(10,100)]
	public int resolution = 10;
	void Awake()
	{
		points = new Transform[resolution];
		for (int i = 0; i < points.Length; i++)
		{
			var point = Instantiate<Transform>(pointPrefab);
			point.transform.localPosition = Vector3.right * ((i + 0.5f) * step - 1f);
			point.localScale = Vector3.one * size;
			point.SetParent(transform, false);
			points[i] = point;
		}
	}
	void Update()
	{
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
			point.localPosition = position;
		}
	}
	
}
