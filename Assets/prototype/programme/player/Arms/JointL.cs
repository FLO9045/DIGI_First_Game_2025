using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointL : MonoBehaviour
{
    public JointL m_childL;


    public JointL GetChild()
    {
        return m_childL;
    }

    public void Rotate(float _angle)
    {
        //transform.Rotate(Vector2.up * _angle);
        transform.Rotate(0, 0, _angle);
    }

}
