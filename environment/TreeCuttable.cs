using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{

    [SerializeField] GameObject PickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;



    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount--;

            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2;
            position.y += spread * Random.value - spread / 2;
            GameObject go = Instantiate(PickUpDrop);
            go.transform.position = position;
        }

        Destroy(gameObject);
    }
}
