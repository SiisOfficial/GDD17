using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

using S = System;

[HelpURL("https://docs.unity3d.com/ScriptReference/HelpURLAttribute.html")]

[AddComponentMenu("Useful Scripts/General Usefulness")]
public class generalAttributes : MonoBehaviour {

    [S.NonSerializedAttribute]
    public bool isActive = false;

    [HideInInspector]
    public bool isSpecial = false;

    [Header("Very Useful Variables")]
    [Space(8)]

    [TooltipAttribute("Where will the cube be created at?")]
    [SerializeField]
    Vector3 cubePosition = Vector3.one;
    [TooltipAttribute("What will be the scale of this cube?")]
    [SerializeField]
    [Range(0, 3)]
    float cubeScale = 1f;

    [Header("These Are Useful Variables Too")]
    [Space(8)]

    [SerializeField]
    AnimationCurve transition = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    [Range(0, 5)]
    [SerializeField]
    float transitionTime = 1f;
    [TooltipAttribute("Where will the cube go?")]
    [SerializeField]
    Vector3 cubeTargetPosition = Vector3.one * 2f;

    [Header("This Is A Less Useful Variable")]
    [Space(8)]

    public bool useGradient = true;

    [Header("Wow! Much Usefulness! Such Easier Life!")]
    [Space(8)]

    [SerializeField]
    Gradient gradientColor;
    [ContextMenuItem("Generate A Color", "GenerateColor")]
    [SerializeField]
    Color color;

    [Space(12)]

    [SerializeField]
    [MultilineAttribute(4)]
    string iHaveTooManyThingsToWrite;

    [SerializeField]
    [TextAreaAttribute]
    string butIAmMuchMoreUsable;

    [Space(12)]

    [SerializeField]
    UnityEvent OnClick;

    [ContextMenu("Translate My GameObject")]
    void TranslateMyGameObject() {
        if(EditorApplication.isPlaying) {
            Debug.Log("Hello Translate My GameObject");
            StartCoroutine(translateGameObject());
        }
    }

    void OnValidate() {
        if(useGradient) {
            GetComponent<Renderer>().sharedMaterial.color = gradientColor.Evaluate(Random.Range(0f, 1f));
        } else {
            GetComponent<Renderer>().sharedMaterial.color = color;
        }
    }

    void Start() {
        transform.position = cubePosition;
        transform.localScale = transform.localScale * cubeScale;
    }

    void GenerateColor() {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        OnValidate();
    }

    IEnumerator translateGameObject() {
        float passedTime = 0f;

        while(passedTime < transitionTime) {
            passedTime += Time.deltaTime;
            float lerpValue = transition.Evaluate(passedTime / transitionTime);

            transform.position = Vector3.LerpUnclamped(cubePosition, cubeTargetPosition, lerpValue);

            yield return null;
        }

    }

    void OnMouseDown() {
        OnClick.Invoke();
    }
}
