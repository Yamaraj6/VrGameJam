using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SkillCast : MonoBehaviour
{
    public UnityEvent[] action;
    public GameObject[] loaderBracelet;
    public float[] coolDownTime;
    public float timeBetweenSkills = 0.5f;

    private float[] lastCast;
    private bool[] able;
    public Color[] initialColor;
    Material[] mat;

    private void Start()
    {
        mat = new Material[loaderBracelet.Length];
        able = new bool[loaderBracelet.Length];
        lastCast = new float[loaderBracelet.Length];

        for (int i = 0; i < loaderBracelet.Length; i++)
        {
            lastCast[i] = Time.time;
            able[i] = true;
            mat[i] = new Material(Shader.Find("Custom/TinterShader"));
            loaderBracelet[i].GetComponent<MeshRenderer>().material = mat[i];
        }
    }
    
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
        for (int i = 0; i < loaderBracelet.Length; i++)
        {
            if ((lastCast[i] + timeBetweenSkills > Time.time))
            {
                able = new bool[loaderBracelet.Length];
            }

        }
    }

    void SetMask(Material targetMaterial, Color color)
    {
        targetMaterial.SetColor("_Color", color);
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
		Debug.Log("skill " + i + " casted");
            action[i].Invoke();
            Wait(i);
        }
	else {
	Debug.Log("skill " +i+ " couldn't be casted");
	}
    }
}
