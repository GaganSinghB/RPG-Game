using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;

    void Start()
    {
        if(CrossfadeController.instance == null)
        {
            CrossfadeController.instance = Instantiate(UIScreen).GetComponent<CrossfadeController>();
        }

        if(PlayerController.instance == null)
        {
            PlayerController.instance = Instantiate(player).GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        
    }
}