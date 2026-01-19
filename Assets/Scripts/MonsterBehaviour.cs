using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Transform[] teleportPoints;
    private NavMeshAgent agent;
    private int currentPatrolIndex = 0;
    private int currentTeleportIndex = 0;
    private bool isTeleporting = false;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        GoToNextPatrolPoint();
    }
    void Update()
    {
        Patrol();
        if (!isTeleporting) 
        {
        isTeleporting = true;
        StartCoroutine(Teleport());
        }
    }
    private void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }
    }
    private void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
    IEnumerator Teleport()
    {
        currentTeleportIndex = Random.Range(0, teleportPoints.Length);
        Vector3 randomPosition = teleportPoints[currentTeleportIndex].position;
        agent.Warp(randomPosition);
        int waitTime = Random.Range(5, 20);
        yield return new WaitForSecondsRealtime(waitTime);
        isTeleporting = false;
    }
}
