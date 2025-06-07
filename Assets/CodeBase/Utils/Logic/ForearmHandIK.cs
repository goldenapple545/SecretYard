using System;
using UnityEngine;

[DefaultExecutionOrder(20000)] // После FinalIK
public class ForearmHandIK : MonoBehaviour
{
    [Space]
    public Transform transForearm;
    public Transform transHand;
    [Tooltip("Должен иметь ту же ориентацию что и предплечье")]
    public Transform transElbowTarget;
    public Vector3 twistAxis = Vector3.up;

    void LateUpdate()
    {
        Vector3 posHand = transHand.position;
        Quaternion rotHand = transHand.rotation;

        var relativeEulerAngles = RelativeRotation(transElbowTarget.rotation, transHand.rotation).eulerAngles;
        float angle = Vector3.Scale(relativeEulerAngles,twistAxis).magnitude;
        
        transForearm.rotation = transElbowTarget.rotation;

        // Подкручиваем за кистью
        transForearm.rotation = Quaternion.AngleAxis(angle, transForearm.rotation * twistAxis) * transForearm.rotation;

        transHand.rotation = rotHand;

        transForearm.Translate(posHand - transHand.position, Space.World);
    }
    
    Quaternion RelativeRotation(Quaternion rot1, Quaternion rot2)
    {
        return Quaternion.Inverse (rot1) * rot2;
    }

}
