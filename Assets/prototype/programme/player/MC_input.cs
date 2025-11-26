using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MC_input : MonoBehaviour
{
    public Vector2 inputHorizontal { get => _inputHorizontal; set => _inputHorizontal = value; }
    public Vector2 inputVertical { get => _inputVertical; set => _inputVertical = value; }
    public bool inputJump { get => _inputJump; set => _inputJump = value; }
    public bool inputRun { get => _inputRun; set => _inputRun = value; }
    public Vector3 mousePosition { get => _mousePosition;}

    private Vector2 _inputHorizontal;
    private Vector2 _inputVertical;
    private bool _inputJump;
    private bool _inputRun;
    private Vector3 _mousePosition;

    private void Update()
    {
        _inputHorizontal = new Vector2(Input.GetAxis("Horizontal"), 0);
        _inputVertical = new Vector2(0, Input.GetAxis("Vertical"));
        _inputJump = Input.GetButtonDown("Jump");
        _inputRun = Input.GetKey(KeyCode.LeftShift);


        _mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        _mousePosition.z = 10;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        
        _mousePosition = worldMousePosition;
    }
    
}
