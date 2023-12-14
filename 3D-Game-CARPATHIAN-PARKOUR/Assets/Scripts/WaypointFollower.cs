using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    [SerializeField] private float _speed = 2f;
    private int currentWaypointIndex = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= _waypoints.Length)
                currentWaypointIndex = 0;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, _waypoints[currentWaypointIndex].transform.position, _speed * Time.deltaTime);
    }
}
