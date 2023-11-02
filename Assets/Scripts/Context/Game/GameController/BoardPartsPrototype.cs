using UnityEngine;

abstract class BoardPartsPrototype : MonoBehaviour
{
    public abstract GameObject Clone(GameObject objToCreate, GameObject parent, Vector3 scale, Vector3 position);
    public abstract void AdjustButtonPosition(GameObject objToAdjust, int index, int rowNumber);
    public abstract void AdjustRowPosition(GameObject objToAdjust, GameObject button, int index, float moveWidth);
}
class StandardPartPrototype : BoardPartsPrototype
{
    private int _rowNumber;
    public override void AdjustButtonPosition(GameObject objToAdjust, int index, int rowNumber)
    {
        _rowNumber = rowNumber;
        var width = objToAdjust.GetComponent<BoxCollider>().size.x;

        objToAdjust.transform.position = new Vector3(
            -objToAdjust.transform.position.x - width / (_rowNumber / 5) + width / (_rowNumber / 10) * index,
            objToAdjust.transform.position.y,
            objToAdjust.transform.position.z);

        objToAdjust.transform.localScale *= 0.9f;
    }

    public override void AdjustRowPosition(GameObject objToAdjust, GameObject button, 
        int index, float moveWidth)
    {
        var width = button.GetComponent<BoxCollider>().size.x;

        objToAdjust.transform.position = new Vector3(
            objToAdjust.transform.position.x,
            objToAdjust.transform.position.y,
            -width * index / (_rowNumber / 10) + moveWidth + width / (_rowNumber / 5));
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