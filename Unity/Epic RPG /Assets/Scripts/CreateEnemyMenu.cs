using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemyUnitPrefab;

   [SerializeField]
    private Sprite menuItemSprite;

    [SerializeField]
    private Vector2 initialPosition, itemDimensions;

    [SerializeField]
    private KillEnemy KillEnemyScript;

    void Awake()
    {
        //Find the units menu
        GameObject enemyUnitsMenu =
            GameObject.Find("EnemyUnitsMenu");

        //Calculate the item position
        GameObject[] existingItems =
            GameObject.FindGameObjectsWithTag("TargetEnemyUnit");

        Vector2 nextPosition = new Vector2(
            initialPosition.x + (existingItems.Length * itemDimensions.x), initialPosition.y
            );

        //Instantiate the item as a child of the EnemyUnitMenu,
        //name it according to what it is and place it in the correct position
        GameObject targetEnemyUnit =
            Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform);

        targetEnemyUnit.name = "Target" + gameObject.name;

        targetEnemyUnit.transform.localPosition = nextPosition;

        targetEnemyUnit.transform.localScale = new Vector2(0.7f, 0.7f);

        //when the player clicks the Button, run SelectEnemyTarget for that enemy
        targetEnemyUnit.GetComponent<Button>().onClick.AddListener(
            () => SelectEnemyTarget()
            );
        targetEnemyUnit.GetComponent<Image>().sprite = menuItemSprite;

        //set the menu item in the killEnemy script
        KillEnemyScript.menuItem = targetEnemyUnit;
    }

    public void SelectEnemyTarget()
    {

    }
}
