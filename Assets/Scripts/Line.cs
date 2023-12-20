using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    
    private int _currentPosition;

    private void Awake()
    {
        _line.positionCount = 0;
    }

    public void SetNextPoint(Vector3 position)
    {
        if (_currentPosition == 0)
        {
            _line.transform.position = position;
        }
        
        _line.positionCount++;
        _line.SetPosition(_currentPosition, position);
        _currentPosition++;
    }
}
