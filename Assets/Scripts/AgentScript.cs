using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] bool isPatrolling = true;
    [SerializeField] float arrivalDistance = 1;
    [SerializeField] Animator anim;
    [SerializeField] float velocity;
    [SerializeField] Transform currentDestination;
    [SerializeField] int currentPatrolPointIndex;
    [SerializeField] RaycastSight rayCastSight;
    [SerializeField] Transform playerTR;
    float countdown = 2;
    bool detectado = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentDestination = patrolPoints[0];
        currentPatrolPointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayCastSight.raycastHit == "Player")
        {
            agent.destination = playerTR.position;
            detectado = true;
            countdown = 2;
        }
        else if (agent.remainingDistance > 2 && countdown >= 0 && detectado)
        {
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
        }
        else if(countdown <= 0 || !detectado)
        {
            detectado = false;
            if (agent.hasPath && agent.remainingDistance <= arrivalDistance)
            {
                if (currentPatrolPointIndex < patrolPoints.Length - 1)
                {
                    currentPatrolPointIndex++;
                }
                else
                {
                    currentPatrolPointIndex = 0;
                }

                currentDestination = patrolPoints[currentPatrolPointIndex];
            }
            agent.destination = currentDestination.position;
            velocity = agent.velocity.magnitude;
            anim.SetFloat("Speed", velocity);
        }
    }
    }
