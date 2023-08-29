using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubActionPanel : MonoBehaviour
{
    public ACTION action;
    public GameObject panel;

    private void Start()
    {
        _refreshOptions();
    }

    private void _refreshOptions()
    {
        switch (action)
        {
            case ACTION.EAT:
            case ACTION.DRINK:
                // to do - get food/drink inventory?
                break;
            case ACTION.ENTERTAIN:
                // to do - everyone has different entertainment options?
                break;
            default: break;
        }
    }

    public void Open()
    {
        panel.SetActive(true);
    }

    public void Close()
    {
        panel.SetActive(false);
    }
}
