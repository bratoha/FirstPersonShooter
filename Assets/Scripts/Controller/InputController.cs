using UnityEngine;

namespace Geekbrains
{
	public class InputController : BaseController
	{

		private KeyCode _activeFlashLight = KeyCode.F;
		private KeyCode _cancel = KeyCode.Escape;
		private KeyCode _reloadClip = KeyCode.R;
        private int _currentWeaponID;
        private int _maxAmountOfWeapons;

        public InputController()
		{
			Cursor.lockState = CursorLockMode.Locked;
            _maxAmountOfWeapons = Main.Instance.ObjectManager.Weapons.Length;
		}

		public override void OnUpdate()
		{
			if (!IsActive) return;
			if (Input.GetKeyDown(_activeFlashLight))
			{
				Main.Instance.FlashLightController.Switch();
			}
			// реализовать выбор оружия по колесику мыши

			if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                CheckWeaponID();
                SelectWeapon(_currentWeaponID--);
            }

            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                CheckWeaponID();
                SelectWeapon(_currentWeaponID++);
            }

            if (Input.GetKeyDown(_cancel))
			{
				Main.Instance.WeaponController.Off();
				Main.Instance.FlashLightController.Off();
			}

			if (Input.GetKeyDown(_reloadClip))
			{
				Main.Instance.WeaponController.ReloadClip();
			}
		}

		private void SelectWeapon(int i)
        { 
            Main.Instance.WeaponController.Off();
			var tempWeapon = Main.Instance.ObjectManager.Weapons[i];
			if (tempWeapon != null) Main.Instance.WeaponController.On(tempWeapon);
		}

        private void CheckWeaponID()
        {
            if (_currentWeaponID >= _maxAmountOfWeapons)
            {
                _currentWeaponID = 0;
                return;
            }

            if (_currentWeaponID < 0)
                    _currentWeaponID = _maxAmountOfWeapons - 1;
        }
    }
}