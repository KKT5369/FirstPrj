using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 _tagetPos;
    private Define.State state = Define.State.Idle;
    private Animator _anim;
    void Start()
    {
        Manager.Input.mouseAction -= OnMouseClickd;
        Manager.Input.mouseAction += OnMouseClickd;
        _anim = GetComponent<Animator>();
    }
    
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
        //애니메이션 처리
        _anim.SetFloat("speed" , 0);
    }
    
    void Moving()
    {
        Vector3 dir = _tagetPos - transform.position;
        //Moving if - 목표지점에 도착 했을때  else - 목표 지점으로 이동

        bool isBlocked = Physics.Raycast(transform.position + Vector3.up * 1.5f, dir.normalized,
            0.8f, LayerMask.GetMask("Block"));

        if (dir.magnitude < 0.001f || isBlocked)
        {
            state = Define.State.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(speed * Time.deltaTime,0,dir.magnitude);
                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }
        
        //애니메이션 처리
        _anim.SetFloat("speed" , speed);
    }

    void OnMouseClickd(Define.MouseEvent evn)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction , Color.blue,0.5f);
        int mask = 1 << LayerMask.NameToLayer("wall");
        if (Physics.Raycast(ray, out hit,100.0f, mask))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                _tagetPos = hit.point;
                state = Define.State.Moving;    
            }
        }
        
    }
}
