using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

public class CollisionEvents : MonoBehaviour
{
	[Space(10)]
	public bool checkLayer = false;
	public LayerMask layerMask = 0;
	[Space(10)]
	public bool checkTag = false;
	public string _tag;
	[Space(10)]
	public bool checkName;
	public string _name;

	public UnityEvent onEnter;
	public UnityEvent onStay;
	public UnityEvent onExit;

	public Action<Collision> onCollisionEnter;
	public Action<Collision, object> onCollisionEnterParam;
	public Action<Collision> onCollisionStay;
	public Action<Collision, object> onCollisionStayParam;
	public Action<Collision> onCollisionExit;
	public Action<Collision, object> onCollisionExitParam;

	[HideInInspector] public object param = null;

	void OnCollisionEnter (Collision collision)
	{
		if (Checks (collision.gameObject)) {
			if (onCollisionEnter != null) {
				onCollisionEnter (collision);
			}
			if (onCollisionEnterParam != null) {
				onCollisionEnterParam (collision, param);
			}

			onEnter.Invoke ();
		}
	}

	void OnCollisionStay (Collision collision)
	{
		if (Checks (collision.gameObject)) {
			if (onCollisionStay != null) {
				onCollisionStay (collision);
			}
			if (onCollisionStayParam != null) {
				onCollisionStayParam (collision, param);
			}

			onStay.Invoke ();
		}
	}

	void OnCollisionExit (Collision collision)
	{
		if (Checks (collision.gameObject)) {
			if (onCollisionExit != null) {
				onCollisionExit (collision);
			}
			if (onCollisionExitParam != null) {
				onCollisionExitParam (collision, param);
			}

			onExit.Invoke ();
		}
	}

	bool Checks (GameObject go)
	{
		if (checkLayer && !CheckLayerInMask (go.layer, layerMask)) {
			return false;
		}

		if (checkTag && !go.CompareTag (_tag)) {
			return false;
		}

		if (checkName && (go.name != _name)) {
			return false;
		}

		return true;
	}

    bool CheckLayerInMask(int layer, int mask)
    {
        return mask == (mask | (1 << layer));
    }
}
