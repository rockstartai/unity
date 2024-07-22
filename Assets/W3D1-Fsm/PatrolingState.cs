using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Fsm
{
    // This is a state with a rudimentary Fsm in itself (switching from point1
    // to point2 etc. is like going through different states), but imagine the
    // enemy might need to chop wood at point1, then move it to point2, then
    // goes eating at point3 and then back to point1. This would be a more
    // realistic use-case, and it's all nicely encapsulated here -- for the main
    // enemy Fsm this here looks just like any other state.
    // And this way you can have any number of nested FSMs (i.e. turning the
    // point3 state into another sub-fsm wher you go through the way he
    // eats, reaches for the food, reaches for the fork etc.)
    public class PatrolingState : EnemyState
    {
        [SerializeField] Transform[] _points;
        [SerializeField] float _speed = 2f;
        [SerializeField] float _targetTouchDist = .8f;

        public Transform CurTarget => _points[_curTargetPoint];
        public float TargetTouchDist => _targetTouchDist;

        int _curTargetPoint;


        protected override void Update()
        {
            var target = CurTarget;

            Enemy.LookAt(target);

            var targetPos = target.position;
            float distanceThisFrame = _speed * Time.deltaTime;
            Enemy.position = Vector3.MoveTowards(
                Enemy.position, targetPos, distanceThisFrame);

            var enemyPos = Enemy.position;
            if (Vector3.Distance(enemyPos, targetPos) < _targetTouchDist)
                _curTargetPoint = (_curTargetPoint + 1) % _points.Length;

            var distToPlayer = Vector3.Distance(enemyPos, Player.position);
            if (distToPlayer < States.Engaging.EngageRange)
                ChangeState(States.Engaging);
        }
    }
}
