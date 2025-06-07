using UnityEngine;
using UnityEngine.XR;

public class SceneSettings : MonoBehaviour
{
    [Range (0.5f, 2f)]
    public float textureResolutionScale = 1f;
    [Tooltip ("0, 2, 4, 8")]
    public int antiAliasing = 2;

    //----------------------------------------------------------------------------------------------------------//
    void Awake()
    {
#if UNITY_ANDROID
        XRSettings.eyeTextureResolutionScale = textureResolutionScale;
#endif
        QualitySettings.antiAliasing = antiAliasing;
    }
}
