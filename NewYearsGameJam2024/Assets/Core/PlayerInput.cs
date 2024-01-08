using UnityEngine;
using UnityEngine.Events;


namespace Core
{
    public class PlayerInput : MonoBehaviour
    {
        public UnityEvent OnLeftMouseButtonDown;
        public UnityEvent OnLeftMouseButtonUp;
        
        public Vector2 cursorPosition => Input.mousePosition;


		private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnLeftMouseButtonDown?.Invoke();
            
            if (Input.GetMouseButtonUp(0))
                OnLeftMouseButtonUp?.Invoke();
        }
    }
}