using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType { DropItem, SummonItem, InstallItem, EquipItem }
public class ItemObject : MonoBehaviour
{
    [SerializeField] private ObjectType type;
    public ObjectType Type => type;
    [SerializeField] private ItemSO itemData;
    public ItemSO ItemData => itemData;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || type == ObjectType.DropItem)
        {
            collision.gameObject.GetComponent<Inventory>().AddItem(ItemData, 1);
            Destroy(gameObject);
        }
        //if (collision.gameObject.CompareTag("Weapon") || type == ObjectType.SummonItem || collision.gameObject.GetComponent<Weapon>().Player.StateMachine.IsAttacking)
        //{
        //    Vector3 vector = new Vector3(collision.transform.position.x + Random.Range(-3,3), collision.transform.position.y + Random.Range(1, 3), collision.transform.position.z + Random.Range(-3, 3));
        //    Instantiate(ItemData.DropPrefab, vector, Quaternion.identity);
        //}
    }
}
