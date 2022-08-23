using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
    }

    void Update()
    {
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position;
    }
}
