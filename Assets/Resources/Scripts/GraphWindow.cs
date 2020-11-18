﻿using System.Collections;
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
        // Dummy list of dot to show on the graph
        List<int> dotValueList = new List<int>() {5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33};
        //Calling the method to show the graph on the screen
        ShowGraphOnTheScreen (dotValueList);
    }

    // Start is called before the first frame update
    void Start()
    {
        //For testing purpose
        // CreateDot (new Vector2(200, 200));
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
        //There are 2 types of Methods
        //1. SetParent(Transform p); => with just a parent reference
        //2. SetParent(Transform parent, bool worldPositionStays); =>
        // where the first argument is a parent reference and second arguement is a  worldPositionStays
        // i.e. If true, the parent-relative position, scale and rotation are modified such that the object keeps the same world space position, rotation and scale as before.
        // makes the dotGameObject keep its local orientation rather than its global orientation
        //https://docs.unity3d.com/ScriptReference/Transform.SetParent.html
        dotGameObject.transform.SetParent(graphPoints, false);
        //Assigning a sprite to the dot gameobject
        dotGameObject.GetComponent<Image>().sprite = dotSprite;
        // Get the RectTransform instance of the dotGameObject
        RectTransform rt = dotGameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = _anchoredPosition;
        rt.sizeDelta = new Vector2(11,11);
        rt.anchorMin = new Vector2(0,0);
        rt.anchorMax = new Vector2(0,0);
    }

    private void ShowGraphOnTheScreen (List<int> _valueList) {
        // Distance between two dots in the x axis
        float xSize = 50.0f;
        // maximum height of the dot
        float yMax = 100.0f;
        float graphHeight = graphPoints.sizeDelta.y;

        for(int index = 0; index <_valueList.Count; index++) {
            //Calculate x position of the dot
            float xPos = index * xSize;
            //Calculate y position of the dot
            float yPos = (_valueList[index] / yMax) * graphHeight;
            //Create a vector out of the above positions
            Vector2 position = new Vector2(xPos, yPos);
            //Create a dot on the above calculated position
            CreateDot(position);
        }
    }

    private void CreateDotConnection (Vector2 _dotPostionA, Vector2 _dotPositionB) {
        GameObject dotConGameObject = new GameObject("dotConnection", typeof(Image));
        dotConGameObject.transform.SetParent(graphPoints, false);
        RectTransform rt = dotConGameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = _dotPostionA;
        rt.sizeDelta = new Vector2(100.0f,3.0f);
        rt.anchorMin = new Vector2(0,0);
        rt.anchorMax = new Vector2(0,0);
    }
}
//For Testing
//https://www.youtube.com/watch?v=TyxDg70hc3g
