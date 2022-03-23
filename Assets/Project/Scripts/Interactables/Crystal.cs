using UnityEngine;

public class Crystal : MonoBehaviour, IInteractable, ISpawnable
{
    public void Interact(GameObject interactor)
    {
        PlayerCrystals playerCrystals = interactor.GetComponent<PlayerCrystals>();
        if(playerCrystals != null)
        {
            playerCrystals.CollectCrystal();    
            Disappear();
        }
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
