using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tutorial.Graph;

public class Graph02 : MonoBehaviour {
	public Transform pointPrefab;

	public Transform[] points;
	[Range(10,100)]
	public int resolution = 10;
	public GraphFunctionName functionName;
	void Awake()
	{
		float step = 2f / resolution;
		points = new Transform[resolution * resolution];
		Vector3 scale = Vector3.one * step;
		for (int i = 0; i < points.Length; i++)
		{
			var point = Instantiate<Transform>(pointPrefab);
			point.localScale = scale;
			point.SetParent(transform, false);
			points[i] = point;
		}
	}
	void Update()
	{
		float t = Time.time;
		GraphFunction f = GraphExtention.functions[(int)functionName];
		float step = 2f / resolution;
		for (int i = 0, z = 0; z < resolution; z++)
		{
			float v = (z + 0.5f) * step - 1f;
			for (int x = 0; x < resolution; x++, i++)
			{
				float u = (x + 0.5f) * step - 1f;
				points[i].localPosition = f (u, v ,t);
			}
		}
	}
}
