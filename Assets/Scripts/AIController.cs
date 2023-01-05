using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] Transform f1;
    [SerializeField] Transform f2;
    [SerializeField] Transform f3;
 
    [SerializeField] float speed = 3.0f;
    [SerializeField] float acceleration = 8.0f;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.acceleration = acceleration;
        agent.SetDestination(f1.position);

        if(agent.transform.position.z <= f1.position.z)
        {
           
            
            agent.SetDestination(f2.position);
        }
        if(agent.transform.position.z <= f2.position.z)
        {
           
            
            agent.SetDestination(f3.position);
        }
    }
}
