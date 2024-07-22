using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Fsm
{
    public class AttackingState : EnemyState
    {
        [SerializeField] float _attackRange = 2f;
        [SerializeField] GameObject _shootEffectPrefab;

        public float AttackRange => _attackRange;

        float _attackCooldown = 1f;
        float _lastAttackTime;


        protected override void OnEnable()
        {
            _lastAttackTime = -_attackCooldown;
        }

        protected override void Update()
        {
            Enemy.LookAt(Player);

            if (Time.time - _lastAttackTime >= _attackCooldown)
            {
                ShowShot();
                ApplyShotForce();
                Debug.Log("Enemy attacks!");
                _lastAttackTime = Time.time;
            }

            var distToPlayer = Vector3.Distance(Enemy.position, Player.position);
            if (distToPlayer > AttackRange)
                ChangeState(States.Engaging);
        }

        void ShowShot()
        {
            var eff = GameObject.Instantiate(_shootEffectPrefab, parent: Enemy);
            eff.transform.rotation = Enemy.rotation;
            Destroy(eff, t: .3f);
        }

        void ApplyShotForce()
        {
            Vector3 vecToPlayer = Player.position - Enemy.position;
            Vector3 dirToPlayer = vecToPlayer.normalized;
            float forceAmount = 2f;
            Vector3 vecForce = dirToPlayer * forceAmount;
            var playerRb = Player.GetComponent<Rigidbody>();
            playerRb.AddForce(vecForce, ForceMode.Impulse);
        }
    }
}
