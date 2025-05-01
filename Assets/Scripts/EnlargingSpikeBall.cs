using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnlargingSpikeBall : RotatingSpikeBall
{
    private float scalingFactor = 1f;   // Controls scaling direction
    private float currentScale;        // Current scale value
    [SerializeField] private float scalingSpeed = 5f;   // Speed at which the spike scales
    [SerializeField] private float minScale = 1f;      // Minimum size
    [SerializeField] private float maxScale = 1.5f;      // Maximum size

    private float timer = 0f;

    [SerializeField] private float enlargedBallTimeInterval = 3f;


    // Update is called once per frame
    void Update()
    {
        RotateBall();
        ScaleBall();
    }

    private void ScaleBall()
    {
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime;  // Adjust the scale
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);   // Keep the scale within boundaries

        if (currentScale == maxScale || currentScale == minScale)  // If the spike reaches its limits
        {
            if (timer >= enlargedBallTimeInterval) 
            {
                scalingFactor = -scalingFactor;  // Reverse the scaling direction
                timer = 0f;
            }
            
            else
            {
                timer += Time.deltaTime;
            }
        }

        ApplyCurrentScale();  // Apply the updated scale to the spike
    }

    private void ApplyCurrentScale()
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1);  // Update the spike's size
    }
}
