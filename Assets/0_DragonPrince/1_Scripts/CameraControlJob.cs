using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

public struct CameraControlJob : IJobParallelForTransform
{
	NativeArray<Quaternion> cameraRotation;

	public void Execute(int index, TransformAccess transform)
	{
		
	}
}
