using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITargeter : MonoBehaviour
{
    public GameObject target;

    private Camera mCamera;
    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        mCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        OnGUI();
    }

    void OnGUI()
    {
        var gotTransform = target.GetComponent<Transform>();
        rt.position = mCamera.WorldToScreenPoint(gotTransform.position);
    }
}
