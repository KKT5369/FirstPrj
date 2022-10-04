using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Audio;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 tagetPos;

    private Define.State state = Define.State.Idle;
    
    void Start()
    {
        Manager mg = Manager.Mg;
        Manager.Input.mouseAction -= OnMouseClickd;
        Manager.Input.mouseAction += OnMouseClickd;
    }

    private float waitRunRatio = 0;
    void Update()
    {
        switch (state)
        {
            case Define.State.Idle:
                Wait();
                break;
            case Define.State.Moving:
                    Moving();
                break;
            
        }
    }

    void Wait()
    {
        Animator animator = GetComponent<Animator>();
        waitRunRatio = Mathf.Lerp(waitRunRatio, 0, 10.0f * Time.deltaTime);
        animator.SetFloat("Wait_Run_Ratio", waitRunRatio);
    }
    
    void Moving()
    {
        Animator animator = GetComponent<Animator>();
        Vector3 dir = tagetPos - transform.position;

        if (dir.magnitude < 0.001f)
        {
            state = Define.State.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(speed * Time.deltaTime,0,dir.magnitude);
            transform.position += dir.normalized * moveDist;
                
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            waitRunRatio = Mathf.Lerp(waitRunRatio, 1, 10.0f * Time.deltaTime);
            animator.SetFloat("Wait_Run_Ratio", waitRunRatio);
        }


        
    }

    void OnMouseClickd(Define.MouseEvent evn)
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction , Color.blue,0.5f);
        int mask = 1 << LayerMask.NameToLayer("wall");
        if (Physics.Raycast(ray, out hit,100.0f, mask))
        {
            tagetPos = hit.point;
            state = Define.State.Moving;
        }
        
    }
}
