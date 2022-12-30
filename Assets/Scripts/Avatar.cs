using UnityEngine;

public class Avatar : MonoBehaviour
{
	public float speed = 10;
	public float maxDirRot = 360;
	Vector3 currentDir;

	void Start()
	{
		currentDir = transform.forward;
	}

	void Update()
	{
		float pow = Input.GetAxis("Speed");
		Vector3 inputDirection = new Vector3(Input.GetAxis("Horzontal"), 0, Input.GetAxis("Vertical"));

		Vector3 desiredDir = inputDirection.normalized;
		float desiredAngleChange = Vector3.Angle(desiredDir,  currentDir);
		if(desiredAngleChange > 90)
		{
			// turn on drift mechanic
		}
		currentDir = Vector3.RotateTowards(currentDir, desiredDir, maxDirRot * Time.deltaTime, 0);

		if(currentDir.magnitude > 1)
		{
			Debug.LogWarning("Shouldn't have a non normalized direction");
		}

		Vector3 deltaMove = pow * currentDir * Time.deltaTime;
	}
}