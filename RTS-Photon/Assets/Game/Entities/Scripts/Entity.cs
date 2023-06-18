using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    protected Vector3 target;

    private float distanceToTarget;
    private float waitTime;
    private bool hasTarget;

    protected virtual void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target);

        if (hasTarget && distanceToTarget <= 0.01f)
        {
            hasTarget = false;
        }

        if (hasTarget)
        {
            MoveEntity();
        }

        if (!hasTarget)
        {
            int random = Random.Range(1, 20);
            waitTime += Time.deltaTime * random;
            Debug.Log(waitTime);
            if (waitTime >= 5) FindTarget();
        }
    }

    protected virtual void FindTarget()
    {
        // common logic for finding a target
        // implement this in each of the movable entities classes

        // find random location if no target is found.
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate the target position based on the random angle and distance of 5 units
        Vector3 randomDirection = new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle));
        target = transform.position + randomDirection * 2f;
        hasTarget = true;
    }

    protected void MoveEntity()
    {
        // move towards the target using a simple linear interpolation
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        waitTime = 0;
    }
}
