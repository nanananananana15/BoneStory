using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// メイン
public class Main : MonoBehaviour 
{
   [SerializeField] Joystick joystick = null;
    void Start()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector2 direction = joystick.Direction;
    }
}