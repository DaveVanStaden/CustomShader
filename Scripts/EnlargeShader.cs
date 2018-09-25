using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnlargeShader : MonoBehaviour {
    public float shaderSize;
    public Renderer rend;
    /// In the start function i get the renderer component and give my shader to it.
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Unlit/CustomShader");
    }
    /// In the update I  set the shadersize amount to the amount float in my shader
	void Update () {
        rend.material.SetFloat("_Amount", shaderSize);
        if (shaderSize <= -0.5)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    /// in the onTrigerEnter i check if it colided with an object with the tag Food, if so shadersize grows and it destroyes the gameobject
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            shaderSize += 0.25f;
            Destroy(other.gameObject);
        }
    }
    /// In the fixedUpdate i keep lowering the shadersize for the hunger
    void FixedUpdate()
    {
        shaderSize -= 0.001f;
    }
}

