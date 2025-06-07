// using System.Collections.Generic;
// using HurricaneVR.Framework.Shared;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.XR;
//
// namespace Utils
// {
//     public class XRButtonLink : MonoBehaviour
//     {
//         [Space]
//         public HVRHandSide side;
//         public HVRButtons button;
//         [Space]
//         public UnityEvent onPress;
//
//         InputDevice device;
//         List<InputDevice> devices;
//
//         private bool _pressed;
//         private HVRController _controller;
//
//         void Start()
//         {
//             devices = new List<InputDevice>();
//         }
//
//         void Update()
//         {
//             //InputDevices.GetDevicesAtXRNode(side, devices);
//             //_controller = HVRInputManager.Instance.GetController(side);
//
//             var buttonState = HVRController.GetButtonState(side, button);
//
//             if (buttonState.Active && !_pressed)
//             {
//                 onPress.Invoke();
//                 _pressed = true;  // Фиксируем, что кнопка была нажата
//             }
//             else if (!buttonState.Active && _pressed)
//             {
//                 // Обнуляем состояние при отпускании кнопки
//                 _pressed = false;
//             }
//
//             // if (devices.Count > 0)
//             //     device = devices[0];
//                 // if (HVRController.GetButtonState(side, button))
//                 // {
//                 //     if(pressed && !_pressed)
//                 //     {
//                 //         onPress.Invoke();
//                 //     }
//                 //
//                 //     _pressed = pressed;
//                 // }
//         }
//     }
// }
