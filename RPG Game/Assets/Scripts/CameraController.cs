using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public Tilemap Map;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    private float halfheight;
    private float halfwidth;

    void Start()
    {
        if (PlayerController.instance == null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
        else
        {
            target = PlayerController.instance.transform;
        }
        halfheight = Camera.main.orthographicSize;
        halfwidth = halfheight * Camera.main.aspect;

        bottomLeftLimit = Map.localBounds.min + new Vector3(halfwidth, halfheight, 0f);
        topRightLimit = Map.localBounds.max - new Vector3(halfwidth, halfheight,0f);

        FindObjectOfType<PlayerController>().SetBounds(Map.localBounds.min, Map.localBounds.max);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
