using System.IO;
using la.niri.VPic.Scripts.Entity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace la.niri.VPic.Scripts.Infra
{
    public class VPicUserInput : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1.0f;
        [SerializeField] private float rotationSpeed = 1.0f;
        [SerializeField] private GameObject targetCamera, canvas;
        private VPicAvatar _avatar;
        private CharacterController _characterController;
        
        public void SetAvatar(VPicAvatar avatar)
        {
            _avatar = avatar;
        }
        
        public void Update()
        {
            if (_avatar == null) return;
            if (_characterController == null)
            {
                _characterController = _avatar.Instance.gameObject.GetComponent<CharacterController>();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (Cursor.visible)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                canvas.SetActive(!canvas.activeSelf);
            }
            
            if (Input.GetKeyDown(KeyCode.F12))
            {
                
                string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"ScreenShot_{timestamp}.png";

                string directoryPath = Application.persistentDataPath;
                string filePath = Path.Combine(directoryPath, fileName);
                Debug.Log($"保存: {filePath}");
                ScreenCapture.CaptureScreenshot(filePath);
            }
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput);

            Vector3 cameraForward = targetCamera.transform.forward;
            Vector3 cameraRight = targetCamera.transform.right;
            
            cameraForward.Normalize();
            cameraRight.Normalize();
            
            Vector3 moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;

            _characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            
           
        }
        
        private void LateUpdate()
        {
            CameraRotation();
        }

        private void CameraRotation()
        {
            
        }
    }
}