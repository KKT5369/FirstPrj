using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager mg;
    InputManager input = new InputManager();

    public static Manager Mg { get { Init(); return mg;}}
    public static InputManager Input { get {  return Mg.input;}}
    
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
