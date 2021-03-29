using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSkill : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            GameObject target = CastRay();
            if(target != null)
            {
                target.transform.parent.GetComponent<UserSkillFunctions>().onClick(target.name);
                GameObject.Find("SkillSpawner").GetComponent<SkillSpawn>().UseSkillAndDestroy(target);
            }
            
        }
    }

    GameObject CastRay() 
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

        if (hit.collider != null) { 
            Debug.Log("HI " + hit.collider.gameObject.name);
            return hit.collider.gameObject;  
        }
        else
        {
            return null;
        }
    }


}
