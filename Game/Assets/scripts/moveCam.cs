
using UnityEngine;

public class moveCam : MonoBehaviour
{
    
    public GameObject player;

    
    void Update()
    {
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10f);
    }
}
