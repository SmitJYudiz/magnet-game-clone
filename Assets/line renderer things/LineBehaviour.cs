using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviour : MonoBehaviour
{
    //smit's work

    

    LineRenderer myLineRenderer;
    public float fpsCounter;
    int animationStep;

    public Texture[] textures;

    [SerializeField]
    private float fps = 30;

    private void Awake()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fpsCounter += Time.deltaTime;

        if(fpsCounter>= 1f/fps)
        {
            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }            
            myLineRenderer.material.SetTexture("_MainTex", textures[animationStep]);
            animationStep++;
            fpsCounter = 0;
            
        }
    }
}
