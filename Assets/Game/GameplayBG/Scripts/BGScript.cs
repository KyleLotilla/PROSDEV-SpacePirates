using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public float scroll_Speed = 1f;
    public MeshRenderer mesh_Renderer;
    public Material[] materials;
    public Animator fadeAnim;
    public SpriteRenderer fadeRender;

    private float x_Scroll;
    private int curMat = 0;
    private Vector2 offset;

    void Start()
    {
        StartCoroutine(changeBG());
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        x_Scroll = Time.time * scroll_Speed;
        offset = new Vector2(x_Scroll, 0f);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    IEnumerator changeBG()
    {
        while(true)
        {
            yield return new WaitForSeconds(50);
            fadeAnim.SetTrigger("change");
            yield return new WaitUntil(()=> fadeRender.color.a > 0.9);
            mesh_Renderer.material = materials[(curMat + 1) % materials.Length];
            mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
            curMat = (curMat + 1) % materials.Length;
        }
    }

}
