using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string entityName;
    public Texture2D entityIcon;
    public int health;
    public float moveSpeed;
    protected Vector3 target;

    private float distanceToTarget;
    private bool hasTarget;

    private void Start()
    {
        if (entityName == null || entityName == "")
        {
            entityName = gameObject.name;
        }
    }

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
    }


    protected void MoveEntity()
    {
        // move towards the target using a simple linear interpolation
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    public virtual void OnClick()
    {
        Debug.Log("I am a " + this.entityName);
    }
}
