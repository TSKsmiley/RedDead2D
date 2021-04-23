using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inventory
{
    [CreateAssetMenu(fileName = "RangedWeapon", menuName = "Items/RangedWeapon")]
    public class RangedWeaponItem : Item
    {
        [field: SerializeField]
        public int chamberSize { get; set; }
        
        [field: SerializeField]
        public int currAmmo { get; set; }

        [field: SerializeField]
        public AmmoType ammoType { get; set; }

        [field: SerializeField]
        public float travelDistance { get; set; }

        [field: SerializeField]
        public float shootRate { get; set; }

        [field: SerializeField]
        public GameObject bulletPrefab { get; set; }

        private Vector2 firePointPos;

        float nextShootTime = 0;

        // We need to reset the shoottime as a scriptable object is meant as a datacontainer, therefore the variable will be saved if we don't reset it on startup
        private void OnEnable()
        {
            nextShootTime = 0;
            
        }
        
        public override void Use(InputMaster _playerInput, GameObject _caller)
        {
            if (!_caller.GetComponent<PlayerController>().canShoot) return;
            if (currAmmo == 0) return; // Play sound?
            if (Time.time >= nextShootTime)
            {
                firePointPos = (Vector2) _caller.transform.position;
                Vector2 mousePos = _playerInput.Player.Aim.ReadValue<Vector2>();
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                Vector2 direction = mousePos - (Vector2)firePointPos;

                GameObject g = Instantiate(bulletPrefab, firePointPos, Quaternion.identity);
                currAmmo--;
                Inventory.Controller.instance.UpdateAmmo(currAmmo.ToString(), chamberSize.ToString());
                g.GetComponent<Bullet>().MoveBullet(direction.normalized);

                nextShootTime = Time.time + 1f / shootRate;
            }
        }
        
        public override void ControllerUse(InputMaster _playerInput, GameObject _caller)
        {
            if (!_caller.GetComponent<PlayerController>().canShoot) return;
            if (currAmmo == 0) return;
            if (Time.time >= nextShootTime) 
            {   
                firePointPos = _caller.transform.position;
                Vector2 controllerDir = _playerInput.Player.ControllerAim.ReadValue<Vector2>();
                if (controllerDir == new Vector2(0,0)) return;

                GameObject g = Instantiate(bulletPrefab, firePointPos + new Vector2(0f, 0.4f), Quaternion.identity);
                currAmmo--;
                Inventory.Controller.instance.UpdateAmmo(currAmmo.ToString(), chamberSize.ToString());
                g.GetComponent<Bullet>().MoveBullet(controllerDir.normalized);
            
                nextShootTime = Time.time + 1f / shootRate;
            }
        }

        public void Reload()
        {
            int bulletsToFill = chamberSize - currAmmo;
            int removedAmmo = Inventory.Controller.instance.RemoveItems(bulletsToFill , $".{(int)ammoType}");
            currAmmo += removedAmmo;
            Inventory.Controller.instance.UpdateAmmo(currAmmo.ToString(), chamberSize.ToString());
        }
        
        public enum AmmoType
        {
            Revolver = 40,
            Carbine = 44,
        }
    }
}


