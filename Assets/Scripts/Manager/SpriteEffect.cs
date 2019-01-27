using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpriteEffect : MonoBehaviour
{
    private bool effectStart = true;
    private float degree;
    private float speed;
    private EffectType effect;
    public enum EffectType
    {
        NoEffect,
        FadeImage,
        ShowImage,
        ShowSomeImage,
    }

    public void numberAssignment(float inputSpeed=3.0f, EffectType inputEffect=EffectType.NoEffect, float inputDegree = 0.5f)
    {
        degree = inputDegree;
        speed = inputSpeed;
        effect = inputEffect;
    }
    private void Update()
    {
        if (effectStart)
        {
            if (effect == EffectType.FadeImage)
            {
                FadeImage(speed);
            }

            if (effect == EffectType.ShowImage)
            {
                ShowImage(speed);
            }
            
            if (effect == EffectType.ShowSomeImage)
            {
                ShowSomeImage(speed, degree);
            }
        }
    }

    public void FadeImage(float speed)
    {
        Color newColor = this.GetComponent<SpriteRenderer>().color;
        newColor.a = Mathf.Lerp(newColor.a, 0f, speed * Time.deltaTime);
        this.GetComponent<SpriteRenderer>().color = newColor;
        if (newColor.a < 0.01f)
        {
            newColor.a = 0f;
            this.GetComponent<SpriteRenderer>().color = newColor;
            effectStart = !effectStart;
            Destroy(this);
        }
    }
    
    public void ShowImage(float speed)
    {
        Color newColor = this.GetComponent<SpriteRenderer>().color;
        newColor.a = Mathf.Lerp(newColor.a, 1f, speed * Time.deltaTime);
        this.GetComponent<SpriteRenderer>().color = newColor;
        if (newColor.a >0.99f)
        {
            newColor.a = 1f;
            this.GetComponent<SpriteRenderer>().color = newColor;
            effectStart = !effectStart;
            Destroy(this);
        }
    }
    
    public void ShowSomeImage(float speed, float degree)
    {
        Color newColor = this.GetComponent<SpriteRenderer>().color;
        newColor.a = Mathf.Lerp(newColor.a, degree, speed * Time.deltaTime);
        this.GetComponent<SpriteRenderer>().color = newColor;
        if (Mathf.Abs(degree-newColor.a)<0.01f)
        {
            newColor.a = degree;
            this.GetComponent<SpriteRenderer>().color = newColor;
            effectStart = !effectStart;
            Destroy(this);
        }
    }
}
