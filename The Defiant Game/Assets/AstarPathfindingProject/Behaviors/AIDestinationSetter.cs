using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;

		[SerializeField]
		float agroRange;

		[SerializeField]
		float moveSpeed;

		private Vector2 moveDirection;

		public float stopDistance;
		Rigidbody2D rd;

		private Vector2 start;

		public bool rotate;

		private Animator animator;

		void Start()
			{
				rd = GetComponent<Rigidbody2D>();
				start = transform.position;
			}
		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {

			float distToPlayer = Vector2.Distance(transform.position, target.position);

			if(distToPlayer < agroRange){
				//code to chase player
				ChasePlayer();
			}
			else{
				//stop chesing player
				StopChasing();
			}

			//if (target != null && ai != null) ai.destination = target.position;
		}

		void ChasePlayer(){
			if(Vector2.Distance(transform.position, target.position) > stopDistance){
				if (target != null && ai != null) ai.destination = target.position;
				//Vector2.zero
			}
        }
		void StopChasing(){
			if (target != null && ai != null) ai.destination = start;
			//transform.position = Vector2.MoveTowards(transform.position, start.transform.position, moveSpeed * Time.deltaTime);
        }
	}
	
}
