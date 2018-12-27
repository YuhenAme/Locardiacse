using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹实例
/// </summary>
public class BulletInstance : MonoBehaviour {
    [Header("子弹速度")][Range(0,10.0f)][SerializeField]
    private float shootSpeed = 2.0f;
    
    private GameObject lockEmeny;
    
    private GameObject player;
    public Vector3 moveDir;
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        //Debug.Log(moveDir);
        transform.position += moveDir * shootSpeed * Time.deltaTime;
       
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.name == player.GetComponent<PlayController>().lockedEmeny.name)
        {
            gameObject.transform.parent = GameSystem.BattleSystem.bulletInstances.transform;
            //GameSystem.BattleSystem.bulletInstanceList.Add(gameObject);
            collision.gameObject.GetComponent<FiniteStateMachine>().activeState.GetData().setLife(collision.gameObject.GetComponent<FiniteStateMachine>().activeState.GetData().getLife() - 30);

            GameObject clone = Resources.Load<GameObject>("boom");
            GameObject boomClone = Instantiate(clone, transform.position, transform.rotation);
            Destroy(boomClone, 0.5f);
            //CameraShake.Shake(0.2f,0.1f);
            CameraShake.TheCameraShake.Shake(0.2f, 0.1f);
            gameObject.SetActive(false);

        }
    }
}
