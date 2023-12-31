using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player") other.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player") other.gameObject.transform.SetParent(null);
    }
}
