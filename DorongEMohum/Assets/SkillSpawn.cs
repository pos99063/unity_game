using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawn : MonoBehaviour
{
	[SerializeField]
	private int skillSpawnCount;
	[SerializeField]
	private GameObject[] skillPrefabArray;
	[SerializeField]
	private Transform spawnPoint;
	[SerializeField]
	private Transform userPoint;

	private int currentObjectCount = 0;
	private float skillSpawnTime = 0.0f;
	private float delayedTime = 2.0f;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{	
		//Debug.Log(currentObjectCount + "/" + skillSpawnCount);
		if( currentObjectCount + 1 > skillSpawnCount)
		{
			return;
		}

		skillSpawnTime += Time.deltaTime;

		if ( skillSpawnTime >= 0.5f )
		{
			int prefabIndex = Random.Range(0, skillPrefabArray.Length);

			Vector3 position = spawnPoint.position;
			//Debug.Log(position);
			//Debug.Log(skillPrefabArray + " " + prefabIndex + " " + skillPrefabArray[prefabIndex]);
			GameObject skill = Instantiate(skillPrefabArray[prefabIndex], position, Quaternion.identity);
			Transform Parent = GameObject.Find("UserSkill").GetComponent<Transform>();
			skill.transform.parent  = Parent;

			Vector3 moveDirection = Vector3.right;
			skill.GetComponent<Movement2D>().Setup(moveDirection);
			currentObjectCount++;
			skillSpawnTime = 0.0f; 
		}
	}

	public void UseSkillAndDestroy(GameObject obj)
    {
        Vector3 position = userPoint.position;
        Vector3 moveDirection = Vector3.left;
		obj.transform.localPosition = position;

        obj.GetComponent<Movement2D>().Setup(moveDirection);
        Destroy(obj, delayedTime);
		currentObjectCount--;
    }


}
