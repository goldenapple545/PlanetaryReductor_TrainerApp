using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuContent;
    [SerializeField] private Animator modelAnimator;
    [SerializeField] private GameObject camera;

    [SerializeField] private Transform defaultTarget;
    [SerializeField] private Transform axisTarget;
    [SerializeField] private Transform planetaryGearsTarget;
    [SerializeField] private Transform sunGearTarget;

    private OrbitCamera _orbitCamera;
    private Animator _cameraAnimator;

    private void Start()
    {
        _orbitCamera = camera.GetComponent<OrbitCamera>();
        _cameraAnimator = camera.GetComponent<Animator>();
    }

    public void MenuExpand()
    {
        menuContent.SetActive(!menuContent.activeSelf);
        modelAnimator.SetFloat("Expand", menuContent.activeSelf ? 1 : 0);
    }

    private void ChangeView(string animationName, Transform target)
    {
        bool switchFlag = modelAnimator.GetBool(animationName);
        switchFlag = !switchFlag;
        
        modelAnimator.SetBool(animationName, switchFlag);
        _cameraAnimator.SetBool(animationName, switchFlag);
        
        if (switchFlag)
        {
            _orbitCamera.target = target;
        }
        else
        {
            _orbitCamera.target = defaultTarget;
            target.localEulerAngles = new Vector3(0, 0 ,0);
        }
    }
    
    public void AxisTap()
    {
        if (!modelAnimator.GetBool("PlanetaryGearsLook") && !modelAnimator.GetBool("SunGearLook"))
            ChangeView("AxisLook", axisTarget);
    }
    
    public void PlanetaryGearsTap()
    {
        if (!modelAnimator.GetBool("AxisLook") && !modelAnimator.GetBool("SunGearLook"))
            ChangeView("PlanetaryGearsLook", planetaryGearsTarget);
    }
    
    public void SunGearTap()
    {
        if (!modelAnimator.GetBool("PlanetaryGearsLook") && !modelAnimator.GetBool("AxisLook"))
            ChangeView("SunGearLook", sunGearTarget);
    }

    public void MenuSceneLoad()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
