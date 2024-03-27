using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    int hp,maxhp,dmg, maxdmg;

    [SerializeField]
    GameObject player; // UHH actually to je uh ten no Enemy ai ale idgaf <333

    void TakeDmg(int dmg_taken){ // Delame dmg enemy <3 random vec se pridava ale uz ve funkci
        System.Random rand = new System.Random();
        hp -= (int)(dmg_taken - rand.Next(0,(int)(dmg_taken/2)));
    }

    int DoDmg(){ // Algorytmus k davani dmge <3
        System.Random r = new System.Random();
        int dmg_G = dmg + r.Next(0,maxdmg);

        return (int)(dmg_G);
    }


    void Update()
    {
        if(hp <= 0){ // Checkovani jestli uz jsme chcipli
            Destroy(player);
        }
    }
}
