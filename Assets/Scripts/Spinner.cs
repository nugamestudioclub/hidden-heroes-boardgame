using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private GameObject _pivot;

    [SerializeField]
    private float _rotationSpeedMultiplier = 100.0f;

    [SerializeField]
    private float _decelerationSpeed = 1.0f;

    private float _rotationSpeed;

    private bool _spinFinished = true;

    // Start is called before the first frame update
    void Start()
    {
        // For testing
        // Spin(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_spinFinished)
        {
            _pivot.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
            _rotationSpeed -= _decelerationSpeed * Time.deltaTime;
            if (_rotationSpeed < 0)
            {
                _spinFinished = true;
            }
        }
    }

    void Spin(float power)
    {
        _spinFinished = false;
        _rotationSpeed = _rotationSpeedMultiplier * power;
    }

    bool IsSpinFinished()
    {
        return _spinFinished;
    }

    int GetSegment()
    {
        float rotation = _pivot.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        int segment = Mathf.Abs(Mathf.FloorToInt(rotation / (Mathf.PI / 3)) - 6) % 6 + 1;
        return segment;
    }
}