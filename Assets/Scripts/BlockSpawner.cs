using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    
    List<Piece> Spawnables; //replace later when the scriptable object works
    [SerializeField] float xDist; //used to both place blocks and to move the parent
    [SerializeField] Vector3 startingPos;

    int nodeFocusIndex;
    void Start()
    {
        for (int i = 0; i < Spawnables.Count; i++)
        {
            Piece p = Instantiate(Spawnables[i], startingPos + new Vector3(i * xDist, 0, 0), Quaternion.identity, this.transform);
        }
        
    }

    private void GoFirst()
    {
        nodeFocusIndex = 0;
    }

    private IEnumerator GoNext()
    {
        nodeFocusIndex++;

        while(transform.position.x != transform.position.x - nodeFocusIndex * xDist)
        {
            //transform.position = Mathf.SmoothDamp
            yield return null;
        }
    }
    
    void Update()
    {
        
    }
}
