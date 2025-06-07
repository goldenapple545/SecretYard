using UnityEngine;

[DefaultExecutionOrder(20000)]
public class CopyMovement : MonoBehaviour
{
	public enum UpdateType { Update, LateUpdate }
	
	[Space(10)]
	public Transform target;

	[Space(10)]
	public bool copyPosition = true;
	public bool copyRotation = false;

	[Space(10)]
	public float smoothPosition = 0f;
	public float smoothRotation = 0f;

	[Space(10)]
	public bool usePositionOffset = false;
	public Vector3 positionOffset;

	[Space(10)]
	public bool useRotationOffset = false;
	public Vector3 rotationOffset;

	[Space(10)]
	public UpdateType copyIn; 

	private Transform _transform;

	void Awake()
	{
		_transform = transform;
	}

	void Update()
	{
		if (copyIn == UpdateType.Update)
		{
			Copy();
		}
	}

	void LateUpdate()
	{
		if (copyIn == UpdateType.Update)
		{
			Copy();
		}
	}

	void Copy()
	{
		if (null == target)
		{
			return;
		}

		if (copyPosition)
		{
			CopyPosition();
		}

		if (copyRotation)
		{
			CopyRotation();
		}
	}

	void CopyPosition()
	{
		Vector3 position = Vector3.zero;

		if (usePositionOffset)
		{
			position = target.position + target.TransformDirection(positionOffset);
		}
		else
		{
			position = target.position;
		}

		_transform.position = (smoothPosition != 0)
			? Vector3.Lerp(_transform.position, position, Time.deltaTime * smoothPosition)
			: position;
	}

	void CopyRotation()
	{
		Quaternion rotation = Quaternion.identity;

		if (useRotationOffset)
		{
			rotation = target.rotation * Quaternion.Euler(rotationOffset);
		}
		else
		{
			rotation = target.rotation;
		}

		_transform.rotation = (smoothRotation != 0)
			? Quaternion.Slerp(_transform.rotation, rotation, Time.deltaTime * smoothRotation)
			: rotation;
	}
}