using System;
using UnityEngine;

namespace Geekbrains
{
	public class Aim : MonoBehaviour, ISetDamage
	{
        [SerializeField] uint _armor = 5;

        public event Action OnPointChange;
		public float Hp = 100;
		private bool _isDead;
		// дописать поглащение урона
		public void SetDamage(InfoCollision info)
		{
			if (_isDead) return;
			if (Hp > 0)
			{
				Hp -= CalculateDamage(info.Damage);
			}

			if (Hp <= 0)
			{
				var tempRigidbody = GetComponent<Rigidbody>();
				if (!tempRigidbody)
				{
					tempRigidbody = gameObject.AddComponent<Rigidbody>();
				}
				tempRigidbody.velocity = info.Dir;
				Destroy(gameObject, 10);

				OnPointChange?.Invoke();
				_isDead = true;
			}
		}
     
        private float CalculateDamage(float damage)
        {
            if (damage - _armor < 0)
                return 0;
            return damage - _armor;
        }
    }
}