using System;
using UnityEngine;
using UnityEngine.UI;

public static class Helpers
{
	public static GameObject FindInChildren(this Transform parent, string childName)
	{
		foreach (Transform child in parent)
		{
			if (child.name == childName)
			{
				return child.gameObject;
			}
			
			GameObject found = FindInChildren(child, childName);
			if (found != null)
			{
				return found;
			}
		}

		return null;
	}
	
	public static void SetParentAndReset(this Transform transform, Transform parent, bool scale = false)
	{
		transform.SetParent(parent);
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		if (scale)
		{
			transform.localScale = Vector3.one;
		}
	}

	public static void SetAlpha(this Graphic image, float alpha)
	{
		Color c = image.color;
		c.a = alpha;
		image.color = c;
	}

	public static void SetAlpha(this Material material, float alpha, string property = "")
	{
		if (string.IsNullOrEmpty(property))
		{
			Color color = material.color;
			color.a = alpha;
			material.color = color;
		}
		else
		{
			Color color = material.GetColor(property);
			color.a = alpha;
			material.SetColor(property, color);
		}
	}

	public static void Print(this Vector2 v)
	{
		Debug.Log(v.x + " / " + v.y);
	}

	public static void Print(this Vector3 v)
	{
		Debug.Log(v.x + " / " + v.y + " / " + v.z);
	}

	public static bool AlmostEqual(this Vector3 a, Vector3 b, float precision = 0.0001f)
	{
		return (a - b).sqrMagnitude <= precision;
	}

	public static bool AlmostEqual(this Quaternion a, Quaternion b, float maxAngle = 0.01f)
	{
		return Quaternion.Angle(a, b) <= maxAngle;
	}

	public static bool AlmostEqual(this float a, float b, float precision = 0.0001f)
	{
		return Mathf.Abs(a - b) <= precision;
	}

	public static void SetBit(this ref int value, int bitIndex)
	{
		value |= (1 << bitIndex);
	}

	public static void ClearBit(this ref int value, int bitIndex)
	{
		value &= ~(1 << bitIndex);
	}

	public static bool CheckBit(this int value, int bitIndex)
	{
		return ((value & (1 << bitIndex)) != 0);
	}
	
	public static bool IsLayerInMask (int layer, int mask)
	{
		return mask == (mask | (1 << layer));
	}

	public static Vector3 Bezier (Vector3 start, Vector3 middle, Vector3 end, float t)
	{
		return Mathf.Pow (1f - t, 2f) * start +
		       2f * t * (1f - t) * middle +
		       Mathf.Pow (t, 2f) * end;
	}

    public static float FixAngle(float angle)
    {
        return (angle > 180) ? angle - 360 : angle;
    }

    public static Quaternion RelativeRotation(Quaternion rot1, Quaternion rot2)
    {
        return Quaternion.Inverse(rot1) * rot2;
    }

    public static void Grid3D(int countX, int countY, int countZ, float size, Action<Vector3> onPosition)
    {
        float halfSize = size / 2f;

        float startPosX = (countX % 2 == 0) ? -((countX / 2) * size - halfSize) : -(((countX - 1) / 2) * size);
        float startPosY = (countY % 2 == 0) ? -((countY / 2) * size - halfSize) : -(((countY - 1) / 2) * size);
        float startPosZ = (countZ % 2 == 0) ? -((countZ / 2) * size - halfSize) : -(((countZ - 1) / 2) * size);

        for (int z = 0; z < countZ; z++)
        {
            for (int y = 0; y < countY; y++)
            {
                for (int x = 0; x < countX; x++)
                {
                    Vector3 pos = new Vector3(startPosX + x * size, startPosY + y * size, startPosZ + z * size);
                    onPosition(pos);
                }
            }
        }
    }

	public static float FreyaLerp(float a, float b, float speed, float dt)
	{
		return b + (a - b) * Mathf.Exp(-speed * dt);
	}
}