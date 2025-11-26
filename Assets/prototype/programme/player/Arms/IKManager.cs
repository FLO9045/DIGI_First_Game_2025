using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    public MC_input m_input;

    public Joint m_root;
    public Joint m_end;


    public Vector3  m_target;
    //public GameObject m_debugTarget;


    public float m_threshold = 0.05f;

    public float m_rate = 5.0f;

    public int m_steps = 10;


    float CalculateSlope(Joint _joint)
    {
        float deltaTheta = 0.01f;

        float distance1 = GetDistance(m_end.transform.position, m_target);
        _joint.Rotate(deltaTheta);

        float distance2 = GetDistance(m_end.transform.position, m_target);
        _joint.Rotate(-deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }


    // Update is called once per frame
    void Update()
    {
        m_target = m_input.mousePosition;
        //m_debugTarget.transform.position = m_target;

        for (int i = 0; i < m_steps; i++)
        {
            if (GetDistance(m_end.transform.position, m_target) > m_threshold)
            {
                Joint current = m_root;
                while (current != null)
                {
                    float slope = CalculateSlope(current);
                    current.Rotate(-slope * m_rate);
                    current = current.GetChild();
                }

            }
        }
        
        

    }

    float GetDistance(Vector3 _a, Vector3 _b)
    {
        return Vector3.Distance(_a, _b);
    }

}
