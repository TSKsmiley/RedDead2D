using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "RangedWeapon", menuName = "Items/RangedWeapon")]
    public class RangedWeaponItem : ScriptableObject, Interfaces.IItem, Interfaces.IRangedWeapon
    {
        // ITEM INTERFACE
        [field: SerializeField]
        public new string name {get;set;}

        [field: SerializeField]
        public string description {get;set;}

        [field: SerializeField]
        public int goldValue {get;set;}

        [field: SerializeField]
        public Sprite sprite {get;set;}

        [field: SerializeField]
        public bool stackable {get;set;}
        
        
        
        public void Equip() {

        }
        
        // IRANGEDWEAPON INTERFACE
        [field: SerializeField]
        public int chamberSize { get; set; }
        
        [field: SerializeField]
        public float travelDistance { get; set; }

        [field: SerializeField]
        public float shootRate { get; set; }

        public GameObject bulletPrefab { get; set; }

        public Transform firePointPos { get; set; }

        private float nextShootTime = 0;
        
        public void Use(InputMaster _playerInput)
        {
            if (Time.time >= nextShootTime) 
            {
                Vector2 mousePos = _playerInput.Player.Aim.ReadValue<Vector2>();
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                Vector2 direction = mousePos - (Vector2)firePointPos.position;

                GameObject g = Instantiate(bulletPrefab, firePointPos.position, Quaternion.identity);
                g.GetComponent<Bullet>().MoveBullet(direction.normalized);

                nextShootTime = Time.time + 1f / shootRate;
            }
        }
        
        public void ControllerUse(InputMaster _playerInput)
        {
            if (Time.time >= nextShootTime) 
            {   
                Vector2 controllerDir = _playerInput.Player.ControllerAim.ReadValue<Vector2>();
                if (controllerDir == new Vector2(0,0)) return;

                GameObject g = Instantiate(bulletPrefab, firePointPos.position, Quaternion.identity);
                g.GetComponent<Bullet>().MoveBullet(controllerDir.normalized);
            
                nextShootTime = Time.time + 1f / shootRate;
            }
        }

        public void Reload()
        {
            
        }
    }
}


