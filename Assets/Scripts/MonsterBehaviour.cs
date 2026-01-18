using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int currentPatrolIndex = 0;
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
    private void Teleport()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-50f, 50f),
            0f,
            Random.Range(-50f, 50f)
        );
        agent.Warp(randomPosition);
    }
}
