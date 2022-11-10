using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyMyaaaaa : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, -4f * Time.deltaTime * 4);
    }
}
