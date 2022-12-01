using UnityEngine;

public class ReadingTheSwipes : MonoBehaviour
{
    [SerializeField] private ControlWithSwipe ControlWithSwipeComponent;

    private Vector3 MousePositionWhenMouseButtonDown;
    private Vector3 MousePositionWhenMouseButtonUp;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MousePositionWhenMouseButtonDown = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            MousePositionWhenMouseButtonUp = Input.mousePosition;
            Vector3 MouseDisplacement = MousePositionWhenMouseButtonUp - MousePositionWhenMouseButtonDown;
            if(MouseDisplacement.x >= 0)
            {
                ControlWithSwipeComponent.ActionsWhenSwipeRight();
            }
            else
            {
                ControlWithSwipeComponent.ActionsWhenSwipeLeft();
            }
        }
    }
}