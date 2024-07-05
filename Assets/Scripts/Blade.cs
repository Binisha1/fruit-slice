using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;

    Camera cam;

    public GameObject bladetrail;

    bool isCutting = false;

    GameObject currentbladetrail;

    CircleCollider2D circlecollider;

    Vector3 previouspos, currentpos;

    float maxvelocity = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circlecollider = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
       
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        float velocity = (previouspos - Input.mousePosition).magnitude;
        if (velocity >maxvelocity)
        {
            circlecollider.enabled = true;
        }
        else
        {
            circlecollider.enabled = false;
        }
    }
    void StartCutting()
    {
        isCutting = true;
        currentbladetrail= Instantiate(bladetrail,transform);
        circlecollider.enabled = false;
        previouspos = Input.mousePosition;
    }
    void StopCutting()
    {
        isCutting = false;
        currentbladetrail.transform.SetParent(null);
        Destroy(currentbladetrail, 2f);
        circlecollider.enabled = false;
    }

}
