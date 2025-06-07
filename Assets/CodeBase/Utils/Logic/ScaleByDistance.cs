using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleByDistance : MonoBehaviour
{
    [Header("Цель")]
    [SerializeField] public Transform target;
    
    [Header("Диапазоны для изменения масштаба")]
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2f;
    [SerializeField] private float minDistance = 10f;
    [SerializeField] private float maxDistance = 100f;
    
    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget < 7)
                gameObject.SetActive(false);
        
            float scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minDistance, maxDistance, distanceToTarget));
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            target = FindAnyObjectByType<MainCamera>().transform;
        }
    }
}
