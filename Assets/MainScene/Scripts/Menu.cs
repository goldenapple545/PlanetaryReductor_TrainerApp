using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuContent;
    [SerializeField] private Animator modelAnimator;
    [SerializeField] private OrbitCamera orbitCamera;

    [SerializeField] private Transform defaultTarget;
    [SerializeField] private Transform axisTarget;

    private bool axisLook = false;
    public void MenuExpand()
    {
        menuContent.SetActive(!menuContent.activeSelf);
        modelAnimator.SetFloat("Expand", menuContent.activeSelf ? 1 : 0);
    }

    public void AxisTap()
    {
        axisLook = !axisLook;
        modelAnimator.SetBool("AxisLook", axisLook);
        
        if (axisLook)
        {
            orbitCamera.target = axisTarget;
        }
        else
        {
            orbitCamera.target = defaultTarget;
            axisTarget.localEulerAngles = new Vector3(0, 0 ,0);
        }
    }
}
