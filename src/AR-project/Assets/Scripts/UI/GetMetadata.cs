using UnityEngine;
using TMPro;

public class GetMetadata : MonoBehaviour
{
    private string objName;
    private string description;
    private string metadatas;
    private float ratio;//implemente

    [SerializeField] private TMP_Text nameContent;
    [SerializeField] private TMP_Text descriptionContent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objName = transform.parent?.name ?? "Objeto não atribuído";
        description = "Descrição: Lorem ipsum dolor sit amet, consectetur " +
        "adipiscing elit. Quisque consequat placerat urna, ac sollicitudin ex"+
        " placerat sit amet. Aenean dapibus mauris vel ipsum consequat";

        nameContent.text = objName;
        descriptionContent.text = description;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
