using UnityEngine;
namespace Geekbrains
{
    public class Shootgun : Weapon
    {
        public override void Fire()
        {

            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (Ammunition)
            {
                var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);// Pool object\
                // Не могу понять, как повенрнуть вектор по Y
                temAmmunition.AddForce(_barrel.forward * _force);
                Clip.CountAmmunition-=2;
                _isReady = false;
                Invoke(nameof(ReadyShoot), _rechergeTime);
                //_timer.Start(_rechergeTime);
            }
        }
    }
}