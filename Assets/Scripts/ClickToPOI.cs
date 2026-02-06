using UnityEngine;

public class ClickToPOI : MonoBehaviour
{
    public LayerMask poiMask;   
    public PlayerMover player;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 2000f, poiMask))
        {
            var poi = hit.collider.GetComponentInParent<ClickablePOI>();
            if (poi == null) return;

            Vector3 dest = (poi.Destination != null) ? poi.Destination.position : poi.transform.position;
            player.MoveTo(dest);
            player.OnArriveDestination += () =>
            {
                Debug.Log("Arrived at POI: " + poi.name);
            };
        }
    }
}
