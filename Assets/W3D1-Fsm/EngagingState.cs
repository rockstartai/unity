using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Fsm
{
    public class EngagingState : EnemyState
    {
        [SerializeField] float _engageRange = 5f;
        [SerializeField] float _moveSpeed = 3f;

        public float EngageRange => _engageRange;


        protected override void Update()
        {
            var distToMoveThisFrame = _moveSpeed * Time.deltaTime;
            var playerPos = Player.position;
            Enemy.position = Vector3.MoveTowards(
                Enemy.position, playerPos, distToMoveThisFrame);
            Enemy.LookAt(Player);

            float distToPlayer = Vector3.Distance(Enemy.position, playerPos);

            if (distToPlayer > EngageRange)
            {
                ChangeState(States.Disengaging);
                return;
            }

            if (distToPlayer <= States.Attacking.AttackRange)
                ChangeState(States.Attacking);
        }
    }
}
