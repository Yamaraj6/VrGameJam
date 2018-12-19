using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SkillCast : MonoBehaviour
{
    public UnityEvent action;
    public GameObject loaderBracelet;
    public float coolDownTime;

    private float lastCast;
    private bool able = false;
    public Color initialColor;
    Material mat;

    private void Start()
    {
        lastCast = Time.time;
        able = true;
        mat = new Material(Shader.Find("Custom/TinterShader"));
        loaderBracelet.GetComponent<MeshRenderer>().material = mat;
    }


    void SetMask(Material targetMaterial, Color color)
    {
        targetMaterial.SetColor("_Color", color);
    }
    // Update is called once per frame
    void Update()
    {
        if ((lastCast + coolDownTime) < Time.time)
        {
            able = true;
        }
        else
        {
            float progress = 1 - (Time.time - lastCast) / coolDownTime;
            SetMask(mat, Color.Lerp(Color.black, initialColor, progress));
            able = false;
        }
    }

    void Wait()
    {
        able = false;
        lastCast = Time.time;
    }
    public void UseSkill()
    {
        if (action != null && able)
        {
            action.Invoke();
            Wait();
        }
    }
}
