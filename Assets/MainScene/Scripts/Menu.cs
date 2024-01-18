using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuContent;
    [SerializeField] private Animator modelAnimator;
    
    public void MenuExpand()
    {
        menuContent.SetActive(!menuContent.activeSelf);
        modelAnimator.SetFloat("Expand", menuContent.activeSelf ? 1 : 0);
    }
}
