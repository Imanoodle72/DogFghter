using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITargetScript : MonoBehaviour
{
    public GameObject mainTargPrefab;
    protected Image mainImage;

    // Start is called before the first frame update
    void Start()
    {
        mainImage = Instantiate(mainTargPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainTargPrefab.transform != null)
        {
            mainImage.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }
        else
        {
            Destroy(mainTargPrefab);
        }
        
    }
}
