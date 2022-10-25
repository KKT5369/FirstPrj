using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager _interface;
    public static Manager Interface { get { Init(); return _interface;}}

    private UIManager _ui = new UIManager();
    InputManager input = new InputManager();
    private ResourceManager _resource = new ResourceManager();
    
    public static UIManager UI { get {  return Interface._ui;}}
    public static InputManager Input { get {  return Interface.input;}}
    public static ResourceManager Resource { get {  return Interface._resource;}}

    void Start()
    {
	    Init();
        UI.Init();
    }

    void Update()
    {
        input.OnUpdate();
    }

    static void Init()
    {
        GameObject go = GameObject.Find("@Manager");
        if (go == null)
        {
            go = new GameObject() { name = "@Manager" };
        }

        if (go.GetComponent<Manager>() == null)
        {
            go.AddComponent<Manager>();
        }

        DontDestroyOnLoad(go);
        _interface = go.GetComponent<Manager>();
    }

    public void MapperCoroutine(IEnumerator evn)
    { 
        StartCoroutine(evn);
    }
}
