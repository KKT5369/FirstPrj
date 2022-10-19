using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager mg;
    static Manager Mg { get { Init(); return mg;}}

    private CanvasManager _canvas = new CanvasManager();
    InputManager input = new InputManager();
    private ResourceManager _resource = new ResourceManager();
    
    public static CanvasManager Canvas { get {  return Mg._canvas;}}
    public static InputManager Input { get {  return Mg.input;}}
    public static ResourceManager Resource { get {  return Mg._resource;}}
    
    void Start()
    {
	    Init();
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
        mg = go.GetComponent<Manager>();
        
    }
}
