using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Line _line;
    [SerializeField] private LayerMask _layer;
    
    private Camera _camera;
    private Line _currentLine;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryDestroyPreviousLine();
            CreateNewLine();
        }

        if (Input.GetMouseButton(0))
        {
            DrawingLine();
        }
    }

    private void CreateNewLine()
    {
        _currentLine = Instantiate(_line);
    }

    private void DrawingLine()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, 50, _layer))
        {
            var position = hitInfo.point;
            position.z -= 1;
            
            _currentLine.SetNextPoint(position);
        }
    }

    private void TryDestroyPreviousLine()
    {
        if (_currentLine != null)
        {
            Destroy(_currentLine.gameObject);
        }
    }
}
