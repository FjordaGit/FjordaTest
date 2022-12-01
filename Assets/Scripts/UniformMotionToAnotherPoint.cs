using UnityEngine;

public class UniformMotionToAnotherPoint : MonoBehaviour
{
    private float _SpeedPerTimeFixedDetlaTime;
    private Vector3 _Displacement;
    private float _QuantityOfTheIterationsOnThePath;
    private Vector3 _SegmentOfTheWayForOneIteration;
    private int _NumberOfTheCurrentIteration;
    private bool _IsMoving;
    private Vector3 _StartingPosition;

    public void Move(Vector3 displacement, float speedPerTimeFixedDetlaTime)
    {
        if (_IsMoving == false)
        {
            _StartingPosition = transform.position;
            _SpeedPerTimeFixedDetlaTime = speedPerTimeFixedDetlaTime;
            _Displacement = displacement;
            _QuantityOfTheIterationsOnThePath = _Displacement.magnitude / _SpeedPerTimeFixedDetlaTime;
            _SegmentOfTheWayForOneIteration = _Displacement / _QuantityOfTheIterationsOnThePath;
            _NumberOfTheCurrentIteration = 0;
            _IsMoving = true;
        }
    }

    private void FixedUpdate()
    {
        if (_IsMoving)
        {
            transform.position += _SegmentOfTheWayForOneIteration;
            _NumberOfTheCurrentIteration++;
            if (_NumberOfTheCurrentIteration >= _QuantityOfTheIterationsOnThePath)
            {
                _IsMoving = false;
                transform.position = _StartingPosition + _Displacement;
            }
        }
    }
}