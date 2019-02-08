using UnityEngine;

namespace Geekbrains
{
	public class FlashLightController : BaseController
	{
		private FlashLightModel _flashLight = Main.Instance.ObjectManager.FlashLight;
		
		public override void OnUpdate()
		{

            if (!IsActive)
            {
                UiInterface.LightUiScrollbar.Scrollbar = 
                    _flashLight.GetBatteryCharge();
                _flashLight.Charge();
                return;
            }

			if (_flashLight == null)return;
			_flashLight.Rotation();
			if (_flashLight.EditBatteryCharge())
			{
                UiInterface.LightUiScrollbar.Scrollbar = 
                     _flashLight.GetBatteryCharge();
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