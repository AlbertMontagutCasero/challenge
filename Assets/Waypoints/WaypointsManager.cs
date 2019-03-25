using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public List<Agent> agents = new List<Agent>();


    private void Awake()
    {
        foreach (Agent agent in agents)
        {
            agent.idPatrol = agents.IndexOf(agent);
        }
        Agent.PatrolFinished += Agent_PatrolFinished;
    }

    private void Start()
    {
        agents[0].Move();
    }

    private void Agent_PatrolFinished(int idPatrol)
    {
        Agent currentAgent = agents[idPatrol];
        currentAgent.Stop();
        currentAgent.SetNextPointIndex();
        Debug.Log(currentAgent.idPatrol);
        Agent nextAgent = agents[(idPatrol + 1) % agents.Count];
        nextAgent.Move();
        Debug.Log(nextAgent.idPatrol);
    }
}
