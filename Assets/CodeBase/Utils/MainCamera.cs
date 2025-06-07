using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public static Transform Transform {
		get
		{
			if (_transform == null)
			{
				var mc = FindObjectOfType<MainCamera>();
				_transform = mc?.transform;
			}

			return _transform;
		}
	}

	public static Camera Camera {
		get
		{
			if (_camera == null)
			{
				_camera = FindObjectOfType<MainCamera>().GetComponent <Camera> ();
			}

			return _camera;
		}
	}

	public static Vector3 flatForward => Vector3.ProjectOnPlane (Transform.forward, Vector3.up).normalized;

	private static Transform _transform;
	private static Camera _camera;
	
	void OnDestroy ()
	{
		_transform = null;
		_camera = null;
	}
}
