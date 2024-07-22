using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace W3D1.Fsm
{
    // The enemy cannot attack the player while in this state (using this just
    // for demostration, as you'd probably add reengagement )
    public class DisengagingState : EnemyState
    {
        [SerializeField] float _disengageSpeed = 2.5f;


        protected override void Update()
        {
            var target = States.Patrol.CurTarget;
            Enemy.LookAt(target);

            var curPatrolPos = target.position;
            var distToMoveThisFrame = _disengageSpeed * Time.deltaTime;
            Enemy.position = Vector3.MoveTowards(
                Enemy.position, curPatrolPos, distToMoveThisFrame);

            if (Vector3.Distance(Enemy.position, curPatrolPos) <
                States.Patrol.TargetTouchDist)
            {
                ChangeState(States.Patrol);
                return;
            }

            var distToPlayer = Vector3.Distance(Enemy.position, Player.position);
            if (distToPlayer < States.Engaging.EngageRange)
                ChangeState(States.Engaging);
        }
    }
}
