using UnityEngine;

namespace Tokaido
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask pointMask;
        [SerializeField] private bool enableTouch = true;
        [SerializeField] private bool enableFollow = true;

        void Update()
        {
            if (enableFollow)
            {
                //TODO: Move Camera by mouse
            }
 
            if (enableTouch && Input.GetMouseButtonDown(0))
            {
                OnTouchDown();
            }
        }

        private void OnTouchDown()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 2000f, pointMask))
            {
                var poi = hit.collider.GetComponentInParent<CheckPoint>();
                if (poi != null)
                {
                    GameManager.Instance.MoveCharacterToPoint(poi);
                }
            }  
        }
    }
}
