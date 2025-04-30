using Cinemachine;
using la.niri.VPic.Scripts.Entity;
using UnityEngine;
using VPic.Scripts.Controller;

namespace la.niri.VPic.Scripts.Controller
{
    public class VPicAvatarInitializer : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook freeLook;
        [SerializeField] private CinemachineVirtualCamera virtualCam;
        [SerializeField] private RuntimeAnimatorController  animator;

        public VPicAvatarInitializer()
        {
            
        }

        public void Initialize(VPicAvatar avatar)
        {
            // virtualCam.Follow = avatar.Chest;
            // virtualCam.LookAt = avatar.Head;
            freeLook.Follow = avatar.Instance.transform;
            freeLook.LookAt = avatar.Head;
            avatar.Instance.gameObject.AddComponent<CharacterController>();
            avatar.Instance.gameObject.AddComponent<AdjustCharacterControllerToVrm>();
            avatar.Instance.gameObject.GetComponent<Animator>().runtimeAnimatorController = animator;
            // avatar.Instance.gameObject.AddComponent<Rigidbody>();
        }
    }
}

