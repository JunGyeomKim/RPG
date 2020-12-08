using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Actor
{
	//JoyStick Stick;
	float ClickMaxDist = 1000.0f;
	NavMeshAgent Agent;

	private void Start()
	{
		IS_PLAYER = true;
		//Stick = JoyStick.Instance;
		Agent = SelfComponent<NavMeshAgent>();
	}

	protected override void Update()
	{

		if (UICamera.Raycast(Input.mousePosition) == true)
			return;

		if (Input.GetMouseButtonDown(0)) 

		{

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, ClickMaxDist))
			{
				AI.MoveToDest(hit.point);

			}
		}

		//if(Stick.IsPressed)
		//{
		//	Vector3 movePosition = transform.position;
		//	movePosition += new Vector3(Stick.Axis.x, 0, Stick.Axis.y);

		//	AI.ClearAI();
		//	Agent.Resume();
		//	Agent.SetDestination(movePosition);
		//}
		//else
		//	base.Update();

		base.Update();
	}




}
