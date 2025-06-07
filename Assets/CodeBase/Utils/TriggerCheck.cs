using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class TriggerCheck: MonoBehaviour
    {
        public System.Action<Collider> OnTrigger;
        public System.Action<Collider> OnExit;
    
        void OnTriggerEnter(Collider col)
        {
            if (col.isTrigger) return;
            LogHierarchy(col.transform);
            OnTrigger?.Invoke(col);
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.isTrigger) return;
            LogHierarchy(col.transform);
            OnExit?.Invoke(col);
        }

        void LogHierarchy(Transform target)
        {
            if (target == null) return;
            Stack<Transform> stack = new();
            stack.Push(target);
            while(target.parent != null)
            {
                target = target.parent;
                stack.Push(target);
            }
            string Path = stack.Pop().name;
            while(stack.Count > 0)
            {
                Path += "/" + stack.Pop().name;
            }
            Debug.LogWarning(Path);
        }
    }
}