using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        RUN,
        FIREFLY,
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXByType(VFXType vfxType, Vector3 position, Transform parent = null, bool permanent = false)
    {
        foreach (VFXManagerSetup i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                item.transform.parent = parent;
                if(!permanent) Destroy(item.gameObject, 3f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}