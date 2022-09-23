using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerController : ControllerModel
{
    [SerializeField] DraggableModel selectedArea;
    public static PointerController Instance;

    private RaycastHit hit;
    private Ray ray;

    public override void Initialize()
    {
        base.Initialize();
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            pointerUpdate();
        }
    }

    private void pointerUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (selectedArea = hit.transform.GetComponent<DraggableModel>()) { }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (selectedArea != null)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    selectedArea.transform.position = new Vector3(hit.point.x, hit.point.y, 0);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedArea = null;
        }
    }
}