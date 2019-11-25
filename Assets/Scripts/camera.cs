using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;


    private Vector3 offset;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        Cursor.visible = false;
    }

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
