using UnityEngine;

namespace Tokaido
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private Transform pathPoint;
        [SerializeField] private Transform[] standPoints;

        public Transform GetStandPoint()
        {
            return  standPoints[Random.Range(0, standPoints.Length)];
        }
    }
}
