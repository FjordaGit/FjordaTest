using UnityEngine;
using System.Collections;

public class ControlWithSwipe : MonoBehaviour
{
    [SerializeField] private UniformMotionToAnotherPoint UniformMotionComponentOfObjectMove;
    [SerializeField] private float DisplacementOnOneSwipingAlongXAxis;
    [SerializeField] private float SpeedPer20Milliseconds;
    [SerializeField] private Vector3 StartingPositionOfObjectMove;
    [SerializeField] private float FurthestAbscissaMovingLeft;
    [SerializeField] private float FurthestAbscissaMovingRight;
    [SerializeField] private RectTransform RectTransformOfObjectToMove;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        RectTransformOfObjectToMove.anchoredPosition = StartingPositionOfObjectMove;
    }

    public void ActionsWhenSwipeLeft()
    {
        float CurrentAbscissaAnchoredPosition = RectTransformOfObjectToMove.anchoredPosition.x;
        if (CurrentAbscissaAnchoredPosition > FurthestAbscissaMovingLeft)
        {
            UniformMotionComponentOfObjectMove.Move(-DisplacementOnOneSwipingAlongXAxis * Vector3.right, SpeedPer20Milliseconds);
        }
    }

    public void ActionsWhenSwipeRight()
    {
        float CurrentAbscissaAnchoredPosition = RectTransformOfObjectToMove.anchoredPosition.x;
        if (CurrentAbscissaAnchoredPosition < FurthestAbscissaMovingRight)
        {
            UniformMotionComponentOfObjectMove.Move(DisplacementOnOneSwipingAlongXAxis * Vector3.right, SpeedPer20Milliseconds);
        }
    }
}