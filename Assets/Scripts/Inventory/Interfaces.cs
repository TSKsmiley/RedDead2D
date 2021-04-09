using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory {
    public class Interfaces {
        public interface IItem
        {
            string name {get;set;}
            string description {get;set;}
            int goldValue {get;set;}
            
            Sprite sprite { get; set; }
            
            bool stackable { get; set; }

            void Equip();
        }

        public interface IConsumerable
        {
            int healthRegen {get;set;}
            
            void ApplyHealthRegen();
        }

        public interface IQuestItem
        {
            void TurnIn();
        }

        public interface IRangedWeapon
        {
            int chamberSize { get; set; }
            float travelDistance { get; set; }
            float shootRate { get; set; }
            GameObject bulletPrefab { get; set; }
            Vector2 firePointPos { get; set; }
            void Use(InputMaster _playerInput);
            void ControllerUse(InputMaster _playerInput);
            void Reload();
        }
    }
}

