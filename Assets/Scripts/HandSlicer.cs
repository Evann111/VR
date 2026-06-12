using UnityEngine;

public class HandSlicer : MonoBehaviour
{
    [Header("Settings")]
    public float sliceSpeed = 1.5f; // Vitesse min pour trancher
    public float sliceRadius = 0.15f; // Rayon de détection

    private Vector3 lastPosition;
    private float currentSpeed;

    void Start() => lastPosition = transform.position;

    void Update()
    {
        // Calculer la vitesse de la main
        currentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;

        // Si la main est assez rapide → détecter les fruits
        if (currentSpeed >= sliceSpeed)
        {
            Debug.Log("Vitesse main : " + currentSpeed);
            DetectSlice();
        }
    }

    void DetectSlice()
    {
        // Cherche tous les fruits dans le rayon autour de la main
        Collider[] hits = Physics.OverlapSphere(
            transform.position, 
            sliceRadius, 
            LayerMask.GetMask("Fruit")
        );

        foreach (Collider hit in hits)
        {
            Fruit fruit = hit.GetComponent<Fruit>();
            if (fruit != null) fruit.Slice();
        }
    }

    // Visualiser le rayon en éditeur
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sliceRadius);
    }
}