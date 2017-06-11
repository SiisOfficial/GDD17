using UnityEditor;
using UnityEngine;

[HelpURLAttribute("https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html")]

[ExecuteInEditMode]

[AddComponentMenu("Useful Scripts/Execute In Edit Mode")]
public class executeInEditMode : MonoBehaviour {

    [SerializeField]
    Material material;

    public Color color = Color.white;

    void OnValidate() {
        if(!EditorApplication.isPlaying) Debug.Log("Hello OnValidate");

        if(material == null)
            material = GetComponent<Renderer>().sharedMaterial;

        material.color = color;
    }

    void Awake() {
        if(!EditorApplication.isPlaying) Debug.Log("Hello Awake");

        if(material == null)
            material = GetComponent<Renderer>().sharedMaterial;
    }

    void Start() {
        if(!EditorApplication.isPlaying) Debug.Log("Hello Start");
    }

    void OnDisable() {
        if(!EditorApplication.isPlaying) Debug.LogWarning("Hello OnDisable");
    }

    void OnEnable() {
        if(!EditorApplication.isPlaying) Debug.Log("Hello OnEnable");
    }

    void Update() {
        if(!EditorApplication.isPlaying) Debug.Log("Hello Update");
    }
}