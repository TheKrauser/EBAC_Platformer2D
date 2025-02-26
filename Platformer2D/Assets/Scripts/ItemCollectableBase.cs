using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [SerializeField] private string compareTag = "Player";

    private AudioSource audioSource;
    public AudioSource AudioSource
    {
        get { return audioSource; }
        set { audioSource = value; }
    }

    private Transform visuals;
    public Transform Visuals
    {
        get { return visuals; }
        set { visuals = value; }
    }

    private Collider2D coll;
    public Collider2D Coll
    {
        get { return coll; }
        set { coll = value; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
    }

    protected virtual void OnCollect()
    {

    }
}
