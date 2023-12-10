using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace test.Assets.Scripts.Ninja
{
    public class NinjaLife : HealtBase
    {
        public static Action EventNinjaDeath;
        public bool canBeHealed => Healt < maxHealt;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                TakeDamage(10);
            }
            if(Input.GetKeyDown(KeyCode.Y))
            {
                Incresehealt(10);
            }
        }
        public void Incresehealt(float healt)
        {
            if(canBeHealed)
            {
                Healt += healt;
                if(Healt > maxHealt)
                    Healt = maxHealt;
                UpdateLifeValue(Healt, maxHealt);
            }
        }
        protected override void UpdateLifeValue(float healt, float maxHealt)
        {
            throw new NotImplementedException();
        }
        protected override void Die()
        {
            EventNinjaDeath?.Invoke();
        }
    }
}