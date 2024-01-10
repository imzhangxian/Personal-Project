using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPShowcase
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject objects;
        [SerializeField] GameObject titleScreen;
        public void StartGame()
        {
            objects.SetActive(true);
            titleScreen.SetActive(false);
        }
    }

}
