using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Enemy enemy;
    private Transform wpTarget;
    private int wavepointIndex = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        wpTarget = EnemyWaypoints.waypoints[0];
    }

    private void Update()
    {
        //Move Enemies in the direction of the Waypoints.
        if (GameManager.gameEnded) return;
        Vector3 direction = wpTarget.position - transform.position;
        transform.Translate(direction.normalized * enemy.modifiedSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, wpTarget.position) <= 0.5f)
        {
            ChangeWaypoint();
        }

        enemy.modifiedSpeed = enemy.speed;
    }

    //Change waypoint if you reach the last one
    void ChangeWaypoint()
    {
        if(wavepointIndex >= EnemyWaypoints.waypoints.Length - 1)
        {
            EndOfPath();
            return;
        }
        wavepointIndex++;
        wpTarget = EnemyWaypoints.waypoints[wavepointIndex];
    }

    //Destroy enemy if it reached the end of the Level and didn't Die
    //Give Players -1 Lives and decreses the countdown of enemies
    void EndOfPath()
    {
        Stats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
