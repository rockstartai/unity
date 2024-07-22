using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace W3D1.Cinemachine
{
    public class CinemachineCamSwitcherByProximity : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera[] _cams;
        [SerializeField] Transform _target;


        void Update()
        {
            if (_cams.Length == 0)
                return;

            CinemachineVirtualCamera closestCamera = null;
            float shortestDistance = float.MaxValue;

            foreach (var vCam in _cams)
            {
                float distance =
                    Vector3.Distance(_target.position, vCam.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestCamera = vCam;
                }
            }

            ActivateCamera(closestCamera);
        }

        void ActivateCamera(CinemachineVirtualCamera cameraToActivate)
        {
            foreach (var vCam in _cams)
            {
                vCam.Priority = vCam == cameraToActivate ? 10 : 0;
            }
        }
    }
}
