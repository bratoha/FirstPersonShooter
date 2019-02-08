﻿using UnityEngine;

namespace Geekbrains
{
	public class UiInterface
	{
        /*private FlashLightUiText _flashLightUiText;

		public FlashLightUiText LightUiText
		{
			get
			{
				if (!_flashLightUiText)
					_flashLightUiText = MonoBehaviour.FindObjectOfType<FlashLightUiText>();
				return _flashLightUiText;
			}
		}*/

        private FlashLightUiScrollbar _flashLightUiScrollbar;

        public FlashLightUiScrollbar LightUiScrollbar
        {
            get
            {
                if (!_flashLightUiScrollbar)
                    _flashLightUiScrollbar = MonoBehaviour.FindObjectOfType<FlashLightUiScrollbar>();
                return _flashLightUiScrollbar;
            }
        }

        private WeaponUiText _weaponUiText;

		public WeaponUiText WeaponUiText
		{
			get
			{
				if (!_weaponUiText)
					_weaponUiText = MonoBehaviour.FindObjectOfType<WeaponUiText>();
				return _weaponUiText;
			}
		}
	}
}