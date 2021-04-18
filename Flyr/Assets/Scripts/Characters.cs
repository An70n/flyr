using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
        public static Characters characters;
        public static Transform[] charactersTransforms = new Transform[6];
        public static GameObject[] characterList = new GameObject[6];

        void Awake()
        {
            if (characters == null)
            {
                DontDestroyOnLoad(gameObject);
                characters = this;
            }
            else if (characters != this)
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            GetCharactersGameObject();
            GetCharactersTransform();
        }

        void GetCharactersGameObject()
        {
            characterList[0] = GameObject.Find("Player");
            characterList[1] = GameObject.Find("J");
            characterList[2] = GameObject.Find("K");
            characterList[3] = GameObject.Find("R");
            characterList[4] = GameObject.Find("Mom");
            characterList[5] = GameObject.Find("Flyr");
        }

        void GetCharactersTransform()
        {
            for (int i = 0; i > characterList.Length; i++)
            {
                charactersTransforms[i] = characterList[i].transform;
            }
        }
    
}
