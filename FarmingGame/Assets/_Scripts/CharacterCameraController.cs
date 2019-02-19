using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraController : MonoBehaviour {

    private Vector3 Offset;
    public GameObject Player;

	void Start ()
    {
        Offset = transform.position - Player.transform.position;
    }
	
	void LateUpdate ()
    {
        transform.position = Player.transform.position + Offset;
    }
}
