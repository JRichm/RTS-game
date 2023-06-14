using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAI : MonoBehaviour
{
    protected Transform target;
    protected float moveSpeed;

    private void Start()
    {
        moveSpeed = GetComponent<Entity>().moveSpeed;
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            // move entity
            MoveEntity();
        }
        else
        {
            // search for new target    
            FindTarget();
        }
    }

    protected virtual void FindTarget()
    {
        // common logic for finding a target
        // implement this in each of the movable entities classes
    }

    protected void MoveEntity()
    {
        // move towards the target using a simple linear interpolation
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

}
