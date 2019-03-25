using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsBadCube : MonoBehaviour
{
    public WaypointsBadCube otherCube;
    public GameObject patrolPoint;
    public GameObject patrolPoint2;
    public GameObject nextPatrolPoint;

    public bool canMove = false;
    public int speed = 1;

    void Start()
    {
        nextPatrolPoint = patrolPoint;
        otherCube.GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPatrolPoint.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canMove = false;
        otherCube.canMove = true;
        if (nextPatrolPoint == patrolPoint)
        {
            nextPatrolPoint = patrolPoint2;
            otherCube.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            nextPatrolPoint = patrolPoint;
            otherCube.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
