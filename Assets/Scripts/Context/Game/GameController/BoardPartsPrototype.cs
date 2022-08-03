using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BoardPartsPrototype : MonoBehaviour
{
    public abstract GameObject Clone(GameObject objToCreate, GameObject parent, Vector3 scale, Vector3 position);
    public abstract void AdjustButtonPosition(GameObject objToAdjust, int index);
    public abstract void AdjustRowPosition(GameObject objToAdjust, GameObject button, int index, float moveWidth);
}
class StandardPartPrototype : BoardPartsPrototype
{
    public override void AdjustButtonPosition(GameObject objToAdjust, int index)
    {
        var width = objToAdjust.GetComponent<BoxCollider>().size.x;

        objToAdjust.transform.position = new Vector3(
            -objToAdjust.transform.position.x - width / 4 + width / 2 * index,
            objToAdjust.transform.position.y,
            objToAdjust.transform.position.z);

        objToAdjust.transform.localScale *= 0.9f;
    }

    public override void AdjustRowPosition(GameObject objToAdjust, GameObject button, 
        int index, float moveWidth)
    {
        var width = button.GetComponent<BoxCollider>().size.x;

        objToAdjust.transform.position = new Vector3(
            -objToAdjust.transform.position.x,
            objToAdjust.transform.position.y,
            -width * index / 2 + moveWidth + width / 4);
    }

    public override GameObject Clone(GameObject objToCreate, GameObject parent, Vector3 scale, Vector3 position)
    {
        GameObject newObject = Instantiate(objToCreate);
        newObject.transform.SetParent(parent.transform);
        newObject.transform.localScale = scale;
        newObject.transform.localPosition = position;
        return newObject;
    }
}