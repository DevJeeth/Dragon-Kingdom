using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoltStudios.Utils
{

	public enum eCameraUpdateType
	{
		Update,
		FixedUpdate,
		LateUpdate
	}

	public class Utilities
	{
		public static bool s_IsCameraTouchActive = false;
	}
}
