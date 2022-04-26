using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParent : MonoBehaviour
{

    private void Update()
    {
        Debug.Log(transform.parent.position);
        transform.parent.position = transform.position;
    }
}
