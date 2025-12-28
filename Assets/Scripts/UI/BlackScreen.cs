using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class BlackScreen : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        Hide();
    }

    public void Show(Action callback)
    {
        _image.DOFade(1, 1).OnComplete(() => callback());
    }

    public void Hide()
    {
        _image.DOFade(0, 0.5f);
    }

}
