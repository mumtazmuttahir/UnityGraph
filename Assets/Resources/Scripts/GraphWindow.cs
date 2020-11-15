using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphWindow : MonoBehaviour
{

    #region public_variables
    public RectTransform graphPoints;
    #endregion

    #region private_variables
    #endregion

    //Using the SerializeField attribute causes Unity to serialize any private variable. 
    //This doesn't apply to static variables and properties in C#.
    //You use the SerializeField attribute when you need your variable to be private but also want it to show up in the Editor.
    #region serialized_fields
    [SerializeField]
    private Sprite dotSprite;
    #endregion

    //Awake is called as soon as the scene starts
    private void Awake() {
        if(graphPoints == null) {
            //transform.Find
            //Finds a child by n and returns it.
            //If no child with n can be found, null is returned
            //n	= Name of child to be found.
            //https://docs.unity3d.com/ScriptReference/Transform.Find.html

            //.GetComponent
            //Gets the component of the in the < > brackets.
            //If the targetted component is not available, null is returned
            //https://docs.unity3d.com/ScriptReference/Component.GetComponent.html
            graphPoints = transform.Find("GraphPoints").GetComponent<RectTransform>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //For testing purpose
        CreateDot (new Vector2(200, 200));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateDot (Vector2 _anchoredPosition) {
        //There are 3 types of constructor for a GameObject instance
        //1. GameObject(); => without any arguements
        //2. GameObject(string name); => with name only
        //3. GameObject(string name, params Type[] components) => Component Types
        //https://docs.unity3d.com/ScriptReference/GameObject-ctor.html
        GameObject dotGameObject = new GameObject("dot", typeof(Image));
        dotGameObject.transform.SetParent(graphPoints, false);
        dotGameObject.GetComponent<Image>().sprite = dotSprite;
        RectTransform rt = dotGameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = _anchoredPosition;
        rt.sizeDelta = new Vector2(11,11);
        rt.anchorMin = new Vector2(0,0);
        rt.anchorMax = new Vector2(0,0);
    }
}
