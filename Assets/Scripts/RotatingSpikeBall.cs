using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpikeBall : MonoBehaviour
{
    [SerializeField] private float rotationAngle = 90f;

    void Update()
    {
        RotateBall();
    }

    protected void RotateBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }
}
