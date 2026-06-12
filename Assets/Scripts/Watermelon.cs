using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header("Settings")]
    public int points = 10;
    public bool isBomb = false;

    [Header("Effets")]
    public GameObject sliceEffect;
    public GameObject bombEffect;

    [Header("Sons")]
    public AudioClip sliceSound;
    public AudioClip bombSound;

    private bool sliced = false;

    public void Slice()
    {
        if (sliced) return;
        sliced = true;

        if (isBomb)
        {
            if (bombEffect != null)
                Instantiate(bombEffect, transform.position, Quaternion.identity);
            if (bombSound != null)
                AudioSource.PlayClipAtPoint(bombSound, transform.position);
            NinjaGameManager.Instance.LoseLife();
        }
        else
        {
            if (sliceEffect != null)
                Instantiate(sliceEffect, transform.position, Quaternion.identity);
            if (sliceSound != null)
                AudioSource.PlayClipAtPoint(sliceSound, transform.position);
            NinjaGameManager.Instance.AddScore(points);
        }

        Destroy(gameObject);
    }
}