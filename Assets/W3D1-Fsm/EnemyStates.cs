using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Fsm
{
    [System.Serializable] // so it'll show in inspector
    public class EnemyStates
    {
        public PatrolingState Patrol;
        public EngagingState Engaging;
        public AttackingState Attacking;
        public DisengagingState Disengaging;


        public void InitAll(EnemyFsm enemy)
        {
            EnemyState[] states = { Patrol, Engaging, Attacking, Disengaging };
            foreach (var state in states)
            {
                state.SetFsm(enemy);
                state.gameObject.SetActive(false);
            }
        }
    }
}
