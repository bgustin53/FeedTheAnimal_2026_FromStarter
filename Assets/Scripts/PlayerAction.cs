// GameObject: Player
// Description: Handles feeding mechanics by selecting and instantiating food objects with audio feedback upon receiving player input.
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
[SerializeField] private GameObject[] foods;
private AudioSource audioSource;

private void Start()
{
    audioSource = GetComponent<AudioSource>();
}

// Called by: Player Input
public void OnFeedInput(InputAction.CallbackContext ctx)
{
    if (ctx.performed)
    {
        SelectFood(ctx.control.name);
    }
}

private void SelectFood(string keyName)
{
    int index = 0;

    if (keyName == "1" || keyName == "alpha1")
    {
        index = 0;
    }
    else if (keyName == "2" || keyName == "alpha2")
    {
        index = 1;
    }
    else if (keyName == "3" || keyName == "alpha3")
    {
        index = 2;
    }
    else
    {
        return;
    }

    if (index < foods.Length && foods[index] != null)
    {
        InstantiateFood(index);
    }
}

private void InstantiateFood(int index)
{
    GameObject foodInstance = Instantiate(foods[index], transform.position, Quaternion.identity);
    
    Rigidbody foodRb = foodInstance.GetComponent<Rigidbody>();
    if (foodRb != null)
    {
        foodRb.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }

    if (audioSource != null)
    {
        audioSource.Play();
    }
}
}