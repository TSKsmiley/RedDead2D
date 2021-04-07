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
    }
}

