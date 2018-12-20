using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SkillCast : MonoBehaviour
{
    public UnityEvent[] action;
    public GameObject[] loaderBracelet;
    public float[] coolDownTime;

    private float[] lastCast;
    private bool[] able;
    public Color[] initialColor;
    Material[] mat;

    private void Start()
    {
        mat = new Material[loaderBracelet.Length];
        able = new bool[loaderBracelet.Length];

        for (int i = 0; i < loaderBracelet.Length; i++)
        {
            lastCast[i] = Time.time;
            able[i] = true;
            mat[i] = new Material(Shader.Find("Custom/TinterShader"));
            loaderBracelet[i].GetComponent<MeshRenderer>().material = mat[i];
        }
    }


    void SetMask(Material targetMaterial, Color color)
    {
        targetMaterial.SetColor("_Color", color);
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < loaderBracelet.Length; i++)
        {
            if ((lastCast[i] + coolDownTime[i]) < Time.time)
            {
                able[i] = true;
            }
            else
            {
                float progress = (Time.time - lastCast[i]) / coolDownTime[i];
                SetMask(mat[i], Color.Lerp(Color.black, initialColor[i], progress));
                able[i] = false;
            }
        }
    }

    void Wait(int i)
    {
        able[i] = false;
        lastCast[i] = Time.time;
    }
    public void UseSkill(int i)
    {
        if (action[i] != null && able[i])
        {
            switch (i)
            {
                case 1:
                    SetMask(mat[i], Color.black);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            action[i].Invoke();
            Wait(i);
        }
    }
}
