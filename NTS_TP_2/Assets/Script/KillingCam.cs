using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingCam : MonoBehaviour
{

    public GameObject particleEffect;

//The last position where we touch our screen //Last raycast from the camera to it's environment

    private Vector2 touchpos;

    private RaycastHit hit;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchCount <= 0)
            return;

        touchpos = Input.GetTouch(0).position;
        Ray ray = cam.ScreenPointToRay(touchpos);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.tag == "Enemy")
            {
                var clone = Instantiate(particleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);
            }
        }
    }
}
