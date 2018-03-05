using UnityEngine;

public class Interacteble : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        
        // Debug.Log("Interacting with " + interactionTransform.name);
    }

     void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {                
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocus (Transform playerTransfor)
    {
        isFocus = true;
        player = playerTransfor;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(interactionTransform.position, radius);
    }
}
