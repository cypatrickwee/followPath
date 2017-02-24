using UnityEngine;
using System.Collections;

public class pathAction : MonoBehaviour {

    //let the object to know which path that has the pathEngine script within
    public pathEngine pathToFollow;
    public int currentWayPointID = 0;//int array of element in the list
    public float speed;
    public float rotationSpeed = 1.0f;
    public string pathName;

    Vector3 last_position;
    Vector3 current_position;

    private int indexes;
    private float reachDistance = 0.0f; //distance between the object origin and the point that is tangent to it.
    // Use this for initialization
	void Start () {
        //pathToFollow = GameObject.Find(pathName).GetComponent<pathEngine>(); //used only during object instantiation, notice we can select the path
        last_position = transform.position;
	    
	}
	
	// Update is called once per frame
	void Update () {
        //take a look at below syntax, pathToFollow.path_objs[index].position
        //pathToFollow has access the previous list array in script pathEngine.
        float distance = Vector3.Distance(pathToFollow.path_objs[currentWayPointID].position, transform.position);// return the distance between a and b, 
        //the last arguement in the below syntax is a time variable
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.path_objs[currentWayPointID].position, Time.deltaTime * speed);

        if(distance <= reachDistance)
        {
            currentWayPointID++;
        }
        //below code is to reset back to original position (notice that its not Count-1 as currentWayPointID has already ++)
        if(currentWayPointID == pathToFollow.path_objs.Count)
        {
            currentWayPointID = 0;
        }

    }
}
