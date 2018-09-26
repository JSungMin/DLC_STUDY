using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.Graph
{
	public delegate Vector3 GraphFunction(float u, float v, float t);
	public class GraphExtention {
		const float pi = Mathf.PI;
		public static GraphFunction[] functions = {
			SineFunction,
			Sine2DFunction,
			MultiSineFunction,
			MultiSine2DFunction,
			Ripple,
			Cylinder,
			CylinderPulsing,
			Sphere,
			SpherePulsing,
			Torus,
			TorusPulsing
		};
		public static Vector3 SineFunction(float x, float z, float t)
		{
			Vector3 p;
			p.x = x;
			p.y = Mathf.Sin(pi * (x + t));
			p.z = z;
			return p;
		}
		public static Vector3 Sine2DFunction(float x, float z, float t)
		{
			Vector3 p;
			p.x = x;
			p.y = Mathf.Sin(pi * (x + t)) + Mathf.Sin(pi * (z + t));
			p.y *= 0.5f;
			p.z = z;
			return p;
		}
		public static Vector3 MultiSineFunction (float x, float z, float t)
		{
			Vector3 p;
			p.x = x;
			p.y = Mathf.Sin(pi * (x + t));
			p.y += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
			p.y *= 2f / 3f;
			p.z = z;
			return p;
		}
		public static Vector3 MultiSine2DFunction (float x, float z, float t)
		{
			Vector3 p;
			p.x = x;
			p.y = 4f * Mathf.Sin (pi * (x + z + t / 2f));
			p.y += Mathf.Sin(pi * (x + t));
			p.y += Mathf.Sin(2f * pi * (z + 2f * t));
			p.y *= 1f / 5.5f;
			p.z = z;
			return p;
		}
		public static Vector3 Ripple (float x, float z, float t)
		{
			Vector3 p;
			float d = Mathf.Sqrt(x * x + z * z);
			p.x = x;
			p.y = Mathf.Sin(pi * (4f * d - t));
			p.y /= 1f + 10f * d;
			p.z = z;
			return p;
		}
		public static Vector3 Cylinder (float u, float v, float t)
		{
			float r = 0.8f;
			Vector3 p;
			p.x = r * Mathf.Sin(pi * u);
			p.y = v;
			p.z = r * Mathf.Cos(pi * u);
			return p;
		}
		public static Vector3 CylinderPulsing (float u, float v, float t)
		{
			float r = 0.8f + Mathf.Sin(pi * (6f * u + 2f * v + t)) * 0.2f;
			Vector3 p;
			p.x = r * Mathf.Sin(pi * u);
			p.y = v;
			p.z = r * Mathf.Cos(pi * u);
			return p;
		}
		public static Vector3 Sphere (float u, float v, float t)
		{
			Vector3 p;
			float r = Mathf.Cos(pi * 0.5f * v);
			p.x = r * Mathf.Sin(pi * u);
			p.y = Mathf.Sin(pi * 0.5f * v);
			p.z = r * Mathf.Cos(pi * u);
			return p;
		}
		public static Vector3 SpherePulsing (float u, float v, float t)
		{
			Vector3 p;
			float r = 0.8f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
			r += Mathf.Sin(pi * (4f * v + t)) * 0.1f;
			float s = r * Mathf.Cos(pi * 0.5f * v);
			p.x = s * Mathf.Sin(pi * u);
			p.y = r * Mathf.Sin(pi * 0.5f * v);
			p.z = s * Mathf.Cos(pi * u);
			return p;
		}
		public static Vector3 Torus (float u, float v, float t) 
		{
			Vector3 p;
			float r1 = 1f;
			float r2 = 0.5f;
			float s = r2 * Mathf.Cos(pi * v) + r1;
			p.x = s * Mathf.Sin(pi * u);
			p.y = r2 * Mathf.Sin(pi * v);
			p.z = s * Mathf.Cos(pi * u);
			return p;
		}
		public static Vector3 TorusPulsing (float u, float v, float t)
		{
			Vector3 p;
			float r1 = 0.65f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
			float r2 = 0.2f + Mathf.Sin(pi * (4f * v + t)) * 0.05f;
			float s = r2 * Mathf.Cos(pi * v) + r1;
			p.x = s * Mathf.Sin(pi * u);
			p.y = r2 * Mathf.Sin(pi * v);
			p.z = s * Mathf.Cos(pi * u);
			return p;
		}
	}
}
