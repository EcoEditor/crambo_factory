using UnityEngine;
using UnityEngine.EventSystems;

namespace CzernyStudio.Utilities {
    public class RotateObjectInput : MonoBehaviour {
        [SerializeField] private float initialRotationSpeed = 2f;
        [SerializeField] private float sensitivity = 5f;

        private TouchInputHandler _touchInputHandler;

        protected void Awake() {
            _touchInputHandler = FindObjectOfType<TouchInputHandler>();
            _touchInputHandler.OnTouchDrag += OnDrag;
        }

        protected void OnDestroy() {
            _touchInputHandler.OnTouchDrag -= OnDrag;
        }

        private void OnDrag(PointerEventData eventData) {
            var direction = new Vector3(eventData.delta.y, -eventData.delta.x, 0f);
            var dragSpeed = eventData.delta.magnitude * initialRotationSpeed * sensitivity;
            transform.Rotate(direction, dragSpeed * Time.deltaTime, Space.World);
        }
    }
}
