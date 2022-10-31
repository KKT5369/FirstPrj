using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ImotikonController : MonoBehaviour
{
    private GameObject _panel;
    private Button _btnImoticon;
    private bool _panleStatus = false;

    private void Start()
    {
        _panel = transform.Find("Panel").gameObject;
        _btnImoticon = transform.GetComponent<Button>();
        _btnImoticon.onClick.AddListener(PanelSwich);

        for (int i = 0; i < _panel.transform.childCount ; i++)
        {
            GameObject imoticon = _panel.transform.GetChild(i).gameObject;
            BtnImotikonStatus bis = imoticon.AddComponent<BtnImotikonStatus>();
            bis._imotikonNum = i + 1;
            imoticon.GetComponent<Button>().onClick.AddListener(bis.Test);
        }
    }

    public void PanelSwich()
    {
        if (_panleStatus)
        {
            _panel.SetActive(_panleStatus);
            _panleStatus = false;
        }
        else
        {
            _panel.SetActive(_panleStatus);
            _panleStatus = true;
        }
    }
}
