using UnityEngine;

public class PuzzleAnatomiaControler : MonoBehaviour
{
    [SerializeField] private GameObject[] orgaos;
    private float[] sequencia;

    public bool AdicionarOrgao(string nome)
    {
        if (nome == null)
        {
            return false;
        }
        else if (nome == "coracao")
        {
            orgaos[0].SetActive(true);
            return true;
        }
        else if (nome == "figado")
        {
            orgaos[1].SetActive(true);
            return true;
        }
        else if (nome == "estomago")
        {
            orgaos[2].SetActive(true);
            return true;
        }
        else if (nome == "pulmao")
        {
            orgaos[3].SetActive(true);
            return true;
        }
        else if (nome == "intestino") 
        {
            orgaos[4].SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }
}
