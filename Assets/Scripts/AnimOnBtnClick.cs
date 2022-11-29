using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimOnBtnClick : MonoBehaviour
{
    public Animator BtnAnim;
    public Image TextModelImage;
    public Sprite NewTextModelImage;

    void OnMouseDown()
    {
        BtnAnim.enabled = true;
        TextModelImage.sprite = NewTextModelImage;
    }


}
