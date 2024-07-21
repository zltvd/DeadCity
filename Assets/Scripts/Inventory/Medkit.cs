using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Medkit : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField] public string id;
    [ContextMenu("Generate guid for if")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField] private string promt;
    public BaseForQuests bfq;
    public bool collected = false;
    public bool wasItcollected = false;
    public string UID;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        this.gameObject.GetComponent<ItemContainer>().pichUp(bfq.player);
        wasItcollected = true;
        return true;
    }
    public void LoadData(GameData data)
    {
        data.medkitCollected.TryGetValue(UID, out wasItcollected);
        this.collected = wasItcollected;
        if (collected == true)
        {
           this.gameObject.SetActive(false);
        }
    }
    public void SaveData(GameData data)
    {
        if (data.medkitCollected.ContainsKey(UID))
        {
            data.medkitCollected.Remove(UID);
        }
        data.medkitCollected.Add(UID, wasItcollected);
    }
}