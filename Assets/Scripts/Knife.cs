using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private Wood wood;

    [SerializeField] private ParticleSystem woodFx;

    private ParticleSystem.EmissionModule woodFxEmission;

    private Rigidbody knifeRb;
    private Vector3 movementVector;
    private bool isMoving = false;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        knifeRb = GetComponent<Rigidbody>();

        woodFxEmission = woodFx.emission;

        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()                                    
    {
        isMoving = Input.GetMouseButton(0);

        if (isMoving)
        {
            Debug.Log("Mouse button is pressed.");
            movementVector = new Vector3(Input.GetAxis("Mouse X"), 
                Input.GetAxis("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
            knifeRb.position += movementVector;
        }
         
    }

    private void OnCollisionExit(Collision collision)
    {
        woodFxEmission.enabled = false;

    }

    private void OnCollisionStay (Collision collision)
    {
        Coll coll = collision.collider.GetComponent<Coll>();
        if (coll != null)
        {
            // hit Collider:
            woodFxEmission.enabled = true;
            woodFx.transform.position = collision.contacts[0].point;

            coll.HitCollider(hitDamage);
            wood.Hit(coll.index, hitDamage);

            audioSource.Play();
        }
    }
}
