using UnityEngine;

public class Brrr : MonoBehaviour
{
    void Start()
    {
        int damage1 = GetDamage(50, false);
        Debug.Log("Обычный удар (базовый 50): " + damage1);

        int damage2 = GetDamage(50, true);
        Debug.Log("Критический удар (базовый 50): " + damage2);

        int damage3 = GetDamage(120, true);
        Debug.Log("Критический удар (базовый 120): " + damage3);
    }

    int GetDamage(int baseDamage, bool isCrit)
    {
        if (isCrit)
        {
            return baseDamage * 2;
        }
        
        return baseDamage;
    }

}
