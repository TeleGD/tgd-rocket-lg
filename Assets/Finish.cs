using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	float t,tempo,tFin1,tFin2;
	int count,vict;
	bool fini = false;
	bool affFin = false;
	bool affInter = false;
	// Use this for initialization
	void Start () {
		t = 0f;
		tFin1 = 0f;
		tFin2 = 0f;
		count = 1;
		vict = 0;

	}

	// Update is called once per frame
	void Update () {
		if (!fini) {
			t += Time.deltaTime;
		}
	}

	void OnGUI(){
		if (affFin) {
			if(tFin1 < 17)
            {
				GUI.Box(new Rect(100, 100, Screen.width / 2, Screen.height / 8), "Temps du joueur 1 : " + tFin1 + "\nTemps du joueur 2 : " + tFin2 + "\nVictoire du joueur " + vict);
			}
            else { GUI.Box (new Rect (100, 100, Screen.width / 2, Screen.height / 8), "Temps du joueur 1 : " + tFin1 + "\nTemps du joueur 2 : " + tFin2 + "\nVictoire du joueur "+vict);}
			
		} else if (affInter) {
			GUI.Box (new Rect (100, 100, Screen.width / 2, Screen.height / 8), "Au joueur 2 de jouer.");
		}
	}

	void freeze(float delay){
		System.Threading.Thread.Sleep ((int) (delay * 1000));
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag.Equals("Player") && count == 1) {
			fini = true;
			tFin1 = t;
			//print ("Temps de parcours du joueur 1 :" + tFin1);
			col.attachedRigidbody.MovePosition (new Vector3 (90, 0, 0));
			col.attachedRigidbody.angularVelocity = new Vector3 (0, 0, 0);
			col.attachedRigidbody.MoveRotation (Quaternion.Euler (new Vector3 (0, 270, 0)));
			col.attachedRigidbody.velocity = new Vector3 (0, 0, 0);
			count++;
			affInter = true;
			freeze (5);
			t = 0f;
			fini = false;
		}
		else if(col.gameObject.tag.Equals("Player") && count == 2){
			fini = true;
			tFin2 = t;
			//print ("Temps de parcours du joueur 2 :" + tFin2);
			if (tFin1 < tFin2) {
				//print ("Le joueur 1 gagne.");
				vict=1;
			} else if (tFin1 > tFin2) {
				//print ("Le joueur 2 gagne.");
				vict=2;
			}
			affFin = true;
		}

	}
		
}
