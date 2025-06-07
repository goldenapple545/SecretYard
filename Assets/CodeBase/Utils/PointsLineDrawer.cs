using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer)), ExecuteAlways]
public class PointsLineDrawer : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private LineRenderer _lineRenderer;

    public LineRenderer LineRenderer
    {
        get
        {
            if (_lineRenderer == null)
                _lineRenderer = GetComponent<LineRenderer>();

            return _lineRenderer;
        }
    }

    private void Awake()
    {
        SetPoints();
    }

    private void Update()
    {
        SetPoints();
    }

    private void SetPoints()
    {
        var positions = _points.Select(x => LineRenderer.transform.InverseTransformPoint(x.position)).ToArray();
        LineRenderer.positionCount = positions.Length;
        LineRenderer.SetPositions(positions);
    }


    private void OnValidate()
    {
        if (_points.Length > 0)
        {
            SetPoints();
        }
    }
}