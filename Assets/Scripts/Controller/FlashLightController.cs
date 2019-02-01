using UnityEngine;

namespace Geekbrains
{
	public class FlashLightController : BaseController
	{
		private FlashLightModel _flashLight;
        private FlashLightUiScrollbar _flashLightScrollbar;

		public FlashLightController()
		{
			_flashLight = MonoBehaviour.FindObjectOfType<FlashLightModel>();
            _flashLightScrollbar = MonoBehaviour.FindObjectOfType<FlashLightUiScrollbar>();
            Off();
        }

		public override void OnUpdate()
		{
            if (!IsActive)
             { 
                _flashLight.Charging();
                _flashLightScrollbar.Scrollbar = _flashLight.GetCurrentCharge();
                return;
            }

			if (_flashLight == null)return;
			_flashLight.Rotation();
			if (_flashLight.EditBatteryCharge())
			{
                _flashLightScrollbar.Scrollbar = _flashLight.GetCurrentCharge();
			}
			else
			{
				Off();
			}
		}

		public override void On()
		{
			if (IsActive)return;
			base.On();
            _flashLight.Switch(true);
		}

		public sealed override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_flashLight.Switch(false);

        }
	}
}