using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager
{
    public Action<Define.MouseEvent> mouseAction = null;
    private bool pressed = false;

    public void OnUpdate()
    {
        if (mouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                mouseAction.Invoke(Define.MouseEvent.Press);
                pressed = true;
            }
            else
            {
                if (pressed)
                {
                    mouseAction.Invoke(Define.MouseEvent.Click);
                    pressed = false;
                }
            }
        }
    }


}
