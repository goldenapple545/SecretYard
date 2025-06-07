using UnityEngine;

public class MoveUpByAxis : MonoBehaviour
{
    [Header("Этот скрипт перемещает цель в направлении оси, на радиус и только в одной плоскости")]
    [Header("Цель, которую будем перемещать")]
    [SerializeField] private Transform target;
    [Header("Точка вокруг которой будет происходить перемещение")]
    [SerializeField] public Transform axisTransform;
    [SerializeField] private float radius = 1.0f;
    [Header("Выбор оси, которая будет ограничивать движение нашей точки (В координатах axisTransform)")]
    [SerializeField] private Vector3 planeNormal = Vector3.forward;
    [Header("Направление в которое будет стремиться наша цель (В мировых координатах)")]
    [SerializeField] private Vector3 worldNormal = Vector3.up;

    void Update()
    {
        if (target != null && axisTransform != null)
        {
            Vector3 worldPlaneNormal = axisTransform.TransformDirection(planeNormal);
            Vector3 relativePosition = axisTransform.position + worldNormal * radius;
            Vector3 constrainedPosition = ProjectPointOnPlane(relativePosition, axisTransform.position, worldPlaneNormal);
            
            target.position = constrainedPosition;
        }
    }
    
    private Vector3 ProjectPointOnPlane(Vector3 point, Vector3 planePoint, Vector3 planeNormal)
    {
        planeNormal.Normalize();
        Vector3 pointToPlanePoint = point - planePoint;
        float distance = Vector3.Dot(pointToPlanePoint, planeNormal);
        return point - planeNormal * distance;
    }
    
    private void OnDrawGizmos()
    {
        if (axisTransform != null)
        {
            Gizmos.color = Color.red;
            
            Vector3 axisStart = axisTransform.position;
            Vector3 axisEnd = axisTransform.position + axisTransform.up * radius;

            Gizmos.DrawLine(axisStart, axisEnd);
            
            Vector3 worldPlaneNormal = axisTransform.TransformDirection(planeNormal);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(axisTransform.position, worldPlaneNormal * radius);
            
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            DrawPlane(axisTransform.position, worldPlaneNormal, radius);
        }
    }
    
    private void DrawPlane(Vector3 center, Vector3 normal, float size)
    {
        Vector3 v3;

        if (normal.normalized != Vector3.forward)
            v3 = Vector3.Cross(normal, Vector3.forward).normalized * normal.magnitude;
        else
            v3 = Vector3.Cross(normal, Vector3.up).normalized * normal.magnitude;

        var corner0 = center + v3 * size;
        var corner2 = center - v3 * size;

        var q = Quaternion.AngleAxis(90.0f, normal);
        v3 = q * v3;

        var corner1 = center + v3 * size;
        var corner3 = center - v3 * size;

        Gizmos.DrawLine(corner0, corner2);
        Gizmos.DrawLine(corner1, corner3);
        Gizmos.DrawLine(corner0, corner1);
        Gizmos.DrawLine(corner1, corner2);
        Gizmos.DrawLine(corner2, corner3);
        Gizmos.DrawLine(corner3, corner0);
    }
}
