using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject Platforms;
    public float platformSpeed;
    private BoxCollider2D bc;
    private Vector3 platformDirection;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        platformSpeed = -0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            platformDirection = new Vector3(platformSpeed, 0, 0);
        }

    }

    void FixedUpdate()
    {
         if (Time.timeScale != 0)
        {
            Platforms.transform.position += platformDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BorderMax")
        {
            //Debug.Log("collision detecté");
            Destroy(this.gameObject);
        }
    }

}
