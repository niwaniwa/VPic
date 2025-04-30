using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using la.niri.VPic.Scripts.Entity;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private float rotationDegrees = 15f;
    [SerializeField] private int animeEndPos = 3;
    [SerializeField] private GameObject canvas;
    public VPicAvatar Avatar { get; set; }

    private int count = 0;
    private Animator _animator;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

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
        canvas.SetActive(false);
        string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"ScreenShot_{timestamp}.png";

        string directoryPath = Application.persistentDataPath;
        string filePath = Path.Combine(directoryPath, fileName);
        Debug.Log($"保存: {filePath}");
        ScreenCapture.CaptureScreenshot(filePath);
        
        canvas.SetActive(true);
    }

    public void TogglePose()
    {
        if (_animator == null)
        {
            if (Avatar == null)
            {
                Debug.Log($"null");
                return;
            }
            _animator = Avatar.Instance.gameObject.GetComponent<Animator>() ;
        }
        _animator.SetInteger("pose", count++);
        Debug.Log($"{count} animator {_animator.GetInteger("pose")}");
        if (count >= animeEndPos) count = 0;
    }

    public void LeftKaiten()
    {
        if (Avatar == null) return;
        Avatar.Instance.gameObject.transform.Rotate(0f, -rotationDegrees, 0f, Space.Self);
    }

    public void RightKaiten()
    {
        if (Avatar == null) return;
        Avatar.Instance.gameObject.transform.Rotate(0f, rotationDegrees, 0f, Space.Self);
    }
    
    
}
