using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W3D1.Cinemachine
{
    public class PlayerControllerNoForce : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] bool _lockRotationToCam = false;

        void Update()
        {
            Move();
        }

        void Move()
        {
            var camTr = Camera.main.transform;
            if (_lockRotationToCam)
            {
                var vecCamToPlayer = transform.position - camTr.position;
                vecCamToPlayer.y = 0f; // disable looking up-down
                var dirCamToPlayerXZ = vecCamToPlayer.normalized;
                transform.forward = dirCamToPlayerXZ;
            }

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            var movePerSec = new Vector3(moveHorizontal, 0.0f, moveVertical)
                * _moveSpeed;

            if (movePerSec.magnitude < .1f)
                return;

            var movePerFrame = movePerSec * Time.deltaTime;
            var movePerFrameInCameraSpace = camTr.TransformVector(movePerFrame);
            movePerFrameInCameraSpace.y = 0f; // don't move vertically
            transform.Translate(movePerFrameInCameraSpace, Space.World);

            // Look ahead
            var dir = movePerFrameInCameraSpace.normalized;
            transform.forward = dir;
        }
    }
}
