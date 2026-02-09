using UnityEngine;

namespace Tokaido
{
    public class GameManager : TSingleton<GameManager>
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private InputManager inputManager;
        [SerializeField] private PlayerController[] players;
        [SerializeField] private CheckPoint[] checkPoints;
        
        public void MoveCharacterToPoint(CheckPoint checkPoint)
        {
            Debug.Log($"[Player] Moving to {checkPoint.gameObject.name}");
            players[0].MoveTo(checkPoint.GetStandPoint().position, OnCharacterArrived);
        }

        private void OnCharacterArrived()
        {
            Debug.Log("[Player] Arrived to check point");
        }
    }
}