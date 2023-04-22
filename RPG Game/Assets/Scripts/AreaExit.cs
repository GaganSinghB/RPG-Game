using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransName;
    public AreaEntrance entrance;
    public float waitToLoad = 1f;
    private bool shouldFadeAfterFade;

    void Start()
    {
        entrance.areaTransName = areaTransName;
    }

    void Update()
    {
        if(shouldFadeAfterFade == true)
        {
            waitToLoad = waitToLoad - Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldFadeAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            shouldFadeAfterFade = true;
            CrossfadeController.instance.FadeToBlack();
            PlayerController.instance.areaTransName = areaTransName;
        }
    }
}