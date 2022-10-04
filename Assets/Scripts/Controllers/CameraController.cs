using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Define.CameraMode mode = Define.CameraMode.QuaterView;
    [SerializeField]
    private Vector3 delta;
    [SerializeField]
    private GameObject player = null;
    void Start()
    {
	
    }

    void LateUpdate()
    {
        if (mode == Define.CameraMode.QuaterView)
        {
            transform.position = player.transform.position + delta;
            transform.LookAt(player.transform);
        }
    }
}
