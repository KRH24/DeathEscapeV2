using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerAI : MonoBehaviour
{
	
		public Transform player;
		private NavMeshAgent navMeshAgent;
    
    
    
		// Start is called before the first frame update
		void Start()
		{
			navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		}

		// Update is called once per frame
		void Update()
		{
			if(player != null){
				navMeshAgent.SetDestination(player.position); 
			}
			else if (!navMeshAgent.isOnNavMesh)
			{
				Debug.LogWarning("NavMeshAgent is not on the NavMesh.");
			}
		}
    }

