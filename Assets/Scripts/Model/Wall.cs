using UnityEngine;

namespace Geekbrains
{
	public class Wall : BaseObjectScene, ISelectObj
	{
		[SerializeField] private KeyCode _keyCode = KeyCode.A;
		public string GetMessage()
		{
			return Name;
		}

		public KeyCode GetKeyCode()
		{
			return _keyCode;
		}
	}
}