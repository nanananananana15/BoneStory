using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClick()
    {
        if(Panel.activeSelf)
        {
            Panel.SetActive(false);
        }
        else
        {
            Panel.SetActive(true);
        }

       
    }
}
