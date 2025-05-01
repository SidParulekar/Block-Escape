using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrollingSpikeBall : RotatingSpikeBall
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float startPos;
    [SerializeField] private float endPos;

    [SerializeField] private float verticalPatrol = 0f;
    [SerializeField] private float horizontalPatrol = 0f;

    // Update is called once per frame
    void Update()
    {
        RotateBall();
        Patrol();
    }

    private void Patrol()
    {
        /*Vector3 position  = transform.position;

        if (horizontalPatrol != 0f)
        {       
            if (position.x >= endPos || position.x <= startPos)
            {
                horizontalPatrol *= -1f;
            }
        }

        else if(verticalPatrol != 0f) 
        {        
            if (position.y >= endPos || position.y <= startPos)
            {
                verticalPatrol *= -1f;
            }
        }

        Vector3 moveDirection = new Vector3(horizontalPatrol, verticalPatrol, 0);

        Vector3 moveAmount = moveDirection * speed * Time.deltaTime;

        position += moveAmount;

        transform.position = position;*/

        if (horizontalPatrol != 0f)
        {
            PatrolHorizontal();
        }

        else if (verticalPatrol != 0f)
        {
            PatrolVertical();            
        }

    }

    private void PatrolHorizontal()
    {
        Vector3 position = transform.position;
        if (position.x <= startPos)
        {
            horizontalPatrol = 1f;
        }

        else if (position.x >= endPos)
        {
            horizontalPatrol = -1f;
        }

        position.x = position.x + horizontalPatrol * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PatrolVertical()
    {
        Vector3 position = transform.position;
        if (position.y <= startPos)
        {
            verticalPatrol = 1f;
        }

        else if (position.y >= endPos)
        {
            verticalPatrol = -1f;
        }

        position.y = position.y + verticalPatrol * speed * Time.deltaTime;
        transform.position = position;
    }

}
