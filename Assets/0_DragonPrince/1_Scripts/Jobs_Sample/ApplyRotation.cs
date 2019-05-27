using UnityEngine;
using Unity.Collections;
using UnityEngine.Jobs;
using Unity.Jobs;

public class ApplyRotation : MonoBehaviour
{
	private JobHandle jobHandler;
	private TransformAccessArray transformArray;
	private NativeArray<Vector3> rotationAxis;

	RotationJob job = new RotationJob();

	private void Start()
	{
		rotationAxis = new NativeArray<Vector3>(1,Allocator.Persistent);
		this.rotationAxis[0] = Vector3.up;
		Transform[] transforms = {transform};
		transformArray = new TransformAccessArray(transforms);
	}

	private void OnDisable()
	{
		transformArray.Dispose();
		rotationAxis.Dispose();
	}

	private void Update()
	{
		job.m_vec3RotationAxis = this.rotationAxis;
		jobHandler = job.Schedule(transformArray, jobHandler);
	}

	private void LateUpdate()
	{
		jobHandler.Complete();
	}

}
