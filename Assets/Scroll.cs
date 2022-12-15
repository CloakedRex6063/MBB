using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scroll : MonoBehaviour
{
    ScrollView scroll;
    int currentelement=0;
    List<VisualElement> levels;

    private void Start()
    {
        scroll = GetComponentInChildren<ScrollView>();
        for(int i=0; i<scroll.childCount; i++)
        {
            levels.Add(scroll.ElementAt(i));
        }
        scroll.ScrollTo(levels[0]);
    }
    // Start is called before the first frame update
    public void Next()
    {
        scroll.ScrollTo(levels[currentelement++]);
    }
    public void Back()
    {
        scroll.ScrollTo(levels[currentelement--]);
    }
}
