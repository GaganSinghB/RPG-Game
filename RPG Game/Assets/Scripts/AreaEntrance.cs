using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string areaTransName;

    void Start()
    {
        if(areaTransName == PlayerController.instance.areaTransName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
        CrossfadeController.instance.FadeFromBlack();
    }

    void Update()
    {
        
    }
}