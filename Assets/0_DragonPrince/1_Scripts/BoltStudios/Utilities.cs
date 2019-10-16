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

	public enum eMenuState
	{
		None,
		Menu,
		Settings,
		Store,
		LevelSelection
	}

	public class Utilities
	{
		public static bool s_IsCameraTouchActive = false;

		private static eMenuState m_eMenuState;
		public static eMenuState MenuState
		{
			get { return m_eMenuState;}
			set { m_eMenuState = value; }
		}
	}
}
