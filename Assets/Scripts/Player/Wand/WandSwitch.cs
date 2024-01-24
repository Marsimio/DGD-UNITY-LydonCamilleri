using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSwitch : MonoBehaviour
{
    public int currentWand = 0;
    void Start()
    {
        SwitchWand();
    }

    void Update()
    {
        int tempWand = currentWand;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            if (currentWand >= transform.childCount - 1)
                currentWand= 0;
            else
                currentWand++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWand <= 0)
                currentWand = transform.childCount - 1;
            else
                currentWand--;
        }
        if (tempWand != currentWand)
        {
            SwitchWand();
        }
    }

    void SwitchWand()
    {
        int i = 0;
        foreach (Transform wand in transform)
        {
            if (i == currentWand)
                wand.gameObject.SetActive(true);
            else
                wand.gameObject.SetActive(false);
            i++;
        }    
    }
}
