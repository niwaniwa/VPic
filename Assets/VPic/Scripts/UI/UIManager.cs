using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private Animator animator;

    private int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Picture()
    {
        Debug.Log($"Take a picture");
        ScreenCapture.CaptureScreenshot("./ScreenShot.png");
    }

    public void TogglePose()
    {
        animator.SetInteger("pose", count++);
    }
    
    
}
