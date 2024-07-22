using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Fsm
{
    public class EnemyFsm : MonoBehaviour
    {
        [SerializeField] EnemyStates _states;
        [SerializeField] Transform _enemy;
        [SerializeField] Transform _player;

        public EnemyStates States => _states;
        public Transform Enemy => _enemy;
        public Transform Player => _player;

        EnemyState _currentState;


        void Start()
        {
            States.InitAll(this);

            ChangeState(States.Patrol);
        }

        public void ChangeState(EnemyState newState)
        {
            if (_currentState != null)
                _currentState.gameObject.SetActive(false);

            _currentState = newState;
            _currentState.gameObject.SetActive(true);
        }
    }
}
