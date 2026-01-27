using UnityEngine;
using UnityEngine.AI;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform monsterSpawnPoint;
    [SerializeField] private GameObject deathScreen;
    public Transform player;
    public NavMeshAgent monsterAgent;
    
    public void PlayerRespawn()
    {
        player.position = spawnPoint.position;
        monsterAgent.Warp(monsterSpawnPoint.position);
        deathScreen.SetActive(false);
    }
}
