using UnityEngine;

/// <summary>
/// This class inherits from TargetObject and represents a PickupObject.
/// </summary>
public class PickupObject : TargetObject
{
    [Header("PickupObject")]

    [Tooltip("New Gameobject (a VFX for example) to spawn when you trigger this PickupObject")]
    public GameObject spawnPrefabOnPickup;

    [Tooltip("Destroy the spawned spawnPrefabOnPickup gameobject after this delay time. Time is in seconds.")]
    public float destroySpawnPrefabDelay = 10;
    
    [Tooltip("Destroy this gameobject after collectDuration seconds")]
    public float collectDuration = 0f;


    bool collected;

    void Start() {
        Register();
    }

    void OnCollect()
    {
        if (collected == false){
            if (CollectSound)
            {
                AudioUtility.CreateSFX(CollectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
            }

            if (spawnPrefabOnPickup)
            {
                var vfx = Instantiate(spawnPrefabOnPickup, CollectVFXSpawnPoint.position, Quaternion.identity);
                Destroy(vfx, destroySpawnPrefabDelay);
            }
                
            Objective.OnUnregisterPickup(this);

            TimeManager.OnAdjustTime(TimeGained);


            //change color
            // Destroy(gameObject, collectDuration);
            GameObject checkpointmesh = transform.GetChild(0).gameObject;
            // checkpointmesh.GetComponent<MeshRenderer>().material.color = Color.clear;

            checkpointmesh.GetComponent<MeshRenderer>().material.color = new Color(10f, 5f, 0.016f, 1f);

        }
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & 1 << other.gameObject.layer) > 0 && other.gameObject.CompareTag("Player"))
        {
            OnCollect();
            collected = true;
        }
    }
}
