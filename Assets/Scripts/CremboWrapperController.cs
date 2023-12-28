using System;
using UnityEngine;

namespace CremboFactory
{
    public class CremboWrapperController : MonoBehaviour
    {
        [SerializeField] private float wrappingSpeedThreshold = 30f;

        private void Awake()
        {
            MessagingSystem.RotationSpeed += OnRotationSpeed;
        }

        private void OnDestroy()
        {
            MessagingSystem.RotationSpeed -= OnRotationSpeed;
        }

        private void OnRotationSpeed(float rotationSpeed)
        {
            if (rotationSpeed > wrappingSpeedThreshold)
            {
                Debug.Log("Rotation is TOO FAST! FAILED");
            }
        }
    }
}
