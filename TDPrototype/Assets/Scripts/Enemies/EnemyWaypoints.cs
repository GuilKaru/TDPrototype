using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [Header("Waypoints List")]
    public static Transform[] waypoints;

    //Make an Array of the Waypoints in the map (the order is set by the order of the childs)
    private void Awake()
    {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
