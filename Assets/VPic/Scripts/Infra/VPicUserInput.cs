using la.niri.VPic.Scripts.Entity;
using UnityEngine;

namespace la.niri.VPic.Scripts.Infra
{
    public class VPicUserInput : MonoBehaviour
    {

        private VPicAvatar _avatar;

        public void SetAvatar(VPicAvatar avatar)
        {
            _avatar = avatar;
        }
        
        public void Update()
        {
            if (_avatar == null) return;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _avatar.Instance.transform.localPosition -= new Vector3(1,0,0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _avatar.Instance.transform.localPosition -= new Vector3(-1,0,0);
            } else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _avatar.Instance.transform.localRotation *= Quaternion.Euler(0,45,0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _avatar.Instance.transform.localRotation *= Quaternion.Euler(0,-45,0);
            }
        }
    }
}