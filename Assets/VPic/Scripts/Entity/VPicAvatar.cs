﻿using System.Linq;
using UniGLTF;
using UnityEngine;
using UniVRM10;

namespace la.niri.VPic.Scripts.Entity
{
    public class VPicAvatar
    {

        public Vrm10Instance Instance
        {
            get;
            private set;
        }
        
        public RuntimeGltfInstance ModelData
        {
            get;
            private set;
        }
        
        public Transform Head
        {
            get;
            private set;
        }

        public Transform Neck
        {
            get;
            private set;
        }
        
        public Transform Chest
        {
            get;
            private set;
        }
        
        public VPicAvatar(Vrm10Instance instance)
        {
            Instance = instance;
            ModelData = instance.GetComponent<RuntimeGltfInstance>();
            ModelData.EnableUpdateWhenOffscreen();
          
            var animator = instance.GetComponent<Animator>();
            Head = instance.Runtime.ControlRig.GetBoneTransform(HumanBodyBones.Head);
            Neck = instance.Runtime.ControlRig.GetBoneTransform(HumanBodyBones.Neck);
            Chest = instance.Runtime.ControlRig.GetBoneTransform(HumanBodyBones.Chest);
        }
        
        public void Dispose()
        {
            GameObject.Destroy(ModelData.gameObject);
        }
        
        public static string GetHierarchyPath(GameObject gameObject)
        {
            var path = gameObject.name;
            var parent = gameObject.transform.parent;

            while ( parent != null )
            {
                path = parent.name + "/" + path;
                parent = parent.parent;
            }

            return path;
        }
        
    }
}