using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
	public float moveSpeed = 6.0f;
	public float jumpForce = 300f;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 playerRotation;
	private Vector3 cameraRotation;
	public Camera camera;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();

		//character mouse position (y)
		playerRotation = transform.rotation.eulerAngles;
		cameraRotation = camera.transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(playerRotation.x, cameraRotation.y, playerRotation.z);

		//character moviment (w,a,s,d)
		if(controller.isGrounded){
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;

			//FIXME
			if (Input.GetButtonDown ("Jump"))
				transform.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
		}

		//fucking moviment function
		controller.SimpleMove(moveDirection);
	}
}
