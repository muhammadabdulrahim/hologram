using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	public float speed;
	public GameObject objectToFollow;
	public List<Waypoint> waypointList;

	private float lerpTime;
	private int currentWaypointIndex;
	private int NextWaypointIndex
	{
		get
		{
			return currentWaypointIndex < waypointList.Count-1 ? currentWaypointIndex + 1 : waypointList.Count - 1;
		}
	}
	private Waypoint CurrentWaypoint { get { return waypointList[currentWaypointIndex]; } }
	private Waypoint NextWaypoint { get { return waypointList[NextWaypointIndex]; } }
	
	void Awake ()
	{
		transform.localPosition = CurrentWaypoint.position;
		transform.localRotation = Quaternion.Euler(CurrentWaypoint.rotation);
	}
	
	void Update ()
	{
		lerpTime = Mathf.Min(1.0f, lerpTime + speed * Time.deltaTime);

		if( Vector3.Distance(transform.localPosition, NextWaypoint.position) > 0.01f )
		{
			transform.localPosition = Vector3.Lerp(CurrentWaypoint.position, NextWaypoint.position, lerpTime);
			transform.localRotation = Quaternion.Lerp(Quaternion.Euler(CurrentWaypoint.rotation), Quaternion.Euler(NextWaypoint.rotation), lerpTime);
		}
		else
		{
			currentWaypointIndex++;
			lerpTime = 0;
		}
	}
}
