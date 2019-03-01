using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentWorker : MonoBehaviour
{

    public List<Transform> destinations = new List<Transform>();
    Transform currentTarget;

    NavMeshAgent agent;

    int i = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < .5f)
            GotoNextPoint();

    }

    void GotoNextPoint()
    {
        if (destinations.Count == 0)
            return;

        agent.destination = destinations[i].position;

        i = (i + 1) % destinations.Count;
    }

}
