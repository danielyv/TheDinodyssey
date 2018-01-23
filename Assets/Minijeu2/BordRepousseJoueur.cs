using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordRepousseJoueur : MonoBehaviour
{


	public float force = 500;
	// adjust the impact force

	void OnTriggerEnter (Collider other)
	{
		Vector3 dir = other.transform.position - transform.position;
		dir.y = 0; // keep the force horizontal if (other.rigidbody){ // use AddForce for rigidbodies: other.rigidbody.AddForce(dir.normalized force); } else { // use a special script for character controllers: // try to get the enemy's script ImpactReceiver: ImpactReceiver script = other.GetComponent< ImpactReceiver>(); // if it has such script, add the impact force: if (script) script.AddImpact(dir.normalized force); } }
	}
}