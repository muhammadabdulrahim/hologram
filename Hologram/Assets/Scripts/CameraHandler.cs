using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	public GameObject objectToFollow;
	public float speed;
	public List<Waypoint> waypointList;
	private int currentWaypointIndex;

	private Waypoint CurrentWaypoint { get { return waypointList[currentWaypointIndex]; } }
	
	void Awake ()
	{
		transform.localPosition = CurrentWaypoint.position;
		transform.localRotation = Quaternion.Euler(CurrentWaypoint.rotation);
	}
	
	void Update ()
	{
		
	}
}
