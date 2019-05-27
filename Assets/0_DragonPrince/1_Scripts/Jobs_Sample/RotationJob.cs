using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;


public struct RotationJob : IJobParallelForTransform
{
	public NativeArray<Vector3> m_vec3RotationAxis;

	public void Execute(int index, TransformAccess transform)
	{
		transform.localRotation *= Quaternion.Euler(m_vec3RotationAxis[index]);
	}
}
