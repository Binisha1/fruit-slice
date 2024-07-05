using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedmelon;
    public GameObject initmelon;

    private Rigidbody2D rb;
    public float upforce= 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * upforce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="blade")
        {
            Vector3 direction=(collision.transform.position-transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            initmelon=Instantiate(slicedmelon,transform.position,rotation);
            Destroy(gameObject);
            Destroy(initmelon, 2f);
        }
    }
}
