using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeGroupCell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float width = GetComponent<RectTransform>().rect.width;
        Vector2 newSize = new Vector2(width / 3, width / 3);
        GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}
