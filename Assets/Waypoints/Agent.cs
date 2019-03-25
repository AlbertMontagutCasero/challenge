using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Agent : MonoBehaviour
{
    
    public delegate void Patrol(int idPatrol);
    public static event Patrol PatrolFinished;

    public int idPatrol;

    public List<Transform> waypoints = new List<Transform>();
    public int nextPointIndex = 0;

    public float speed = 1;
    public Boolean IsMoving = false;

    void Update()
    {
        if (IsMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[nextPointIndex].position, speed);
        }
    }

    public void Move()
    {
        IsMoving = true;
    }

    public void Stop()
    {
        IsMoving = false;
    }

    public void SetNextPointIndex()
    {
        nextPointIndex = (nextPointIndex + 1) % waypoints.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        PatrolFinished(idPatrol);
    }
}
