using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Fsm
{
    public abstract class EnemyState : MonoBehaviour
    {
        protected EnemyStates States => _fsm.States;
        protected Transform Enemy => _fsm.Enemy;
        protected Transform Player => _fsm.Player;
        EnemyFsm _fsm;


        public void SetFsm(EnemyFsm fsm)
        {
            _fsm = fsm;
        }

        protected virtual void Update() { }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }

        protected void ChangeState(EnemyState state) => _fsm.ChangeState(state);
    }
}
