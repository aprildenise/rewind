using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Fire>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

}
