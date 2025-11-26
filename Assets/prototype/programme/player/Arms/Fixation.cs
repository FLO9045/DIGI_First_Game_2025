using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Fixation : MonoBehaviour
{
    public MC_Mouvement1 m_Mouvement1;

    public Transform R_Fixation;
    public Transform L_Fixation;

    public Transform R_Arm;
    public Transform L_Arm;


    void Update()
    {
        if (m_Mouvement1.isFacingRight)
        {

            R_Arm.position = R_Fixation.position;
            L_Arm.position = L_Fixation.position;
        }
        else
        {

            
            R_Arm.position = L_Arm.position;
            L_Arm.position = R_Arm.position;
            
        }
            

    }

}
