using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3f;
        var y = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3f;

        transform.Rotate(0, y, 0);
        transform.Translate(0, 0, z);
    }
}
