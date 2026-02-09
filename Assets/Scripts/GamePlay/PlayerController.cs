using UnityEngine;

namespace Tokaido
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMover movement;

        public void MoveTo(Vector3 position, System.Action completedCallback)
        {
            movement.MoveTo(position);
            movement.OnArriveDestination += completedCallback;
        }
    }
}
