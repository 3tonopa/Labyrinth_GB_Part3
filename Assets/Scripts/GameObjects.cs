using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace Labyrinth
{
    public class GameObjects : InteractiveObject, IExecute
    {
        GameObject _pl;
        GameObject playerPrefab;
        Player _plSc;
        GameObject[] good;
        GameObject[] bad;
        public GameObject goodPrefab;
        public string[] gObjStoreGood = { };
        public GameObject badPrefab;
        public string[] gObjStoreBad = { };
        public GameObject _exit;
        public GameObject exitPrefab;
        void Awake()
        {
            _pl = GameObject.FindWithTag("Player");
            _plSc = GameObject.FindWithTag("Player").GetComponent<Player>();
            _exit = GameObject.FindWithTag("Exit");

            playerPrefab = Resources.Load<GameObject>("Player");
            exitPrefab = Resources.Load<GameObject>("Exit");
            goodPrefab = Resources.Load<GameObject>("GoodBonus");
            badPrefab = Resources.Load<GameObject>("BadBonus");
        }

        protected override void Interaction()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute()
        {

            try
            {
                _pl = GameObject.FindWithTag("Player");
                _plSc = FindObjectOfType<Player>();
            }
            catch (NullReferenceException)
            {
                Debug.Log("No Player");
            }
        }

        public void SaveFile()
        {
            Create();

            string destination = Application.persistentDataPath + "/save.dat";
            FileStream file;

            if (File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);

            GameData data = new GameData(_plSc._score, _plSc._hp, _pl.transform.position, _pl.transform.rotation, gObjStoreGood, gObjStoreBad);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Gamedata Saved");
        }

        public void LoadFile()

        {
            string destination = Application.persistentDataPath + "/save.dat";
            FileStream file;

            if (File.Exists(destination)) file = File.OpenRead(destination);
            else
            {
                Debug.LogError("File not found");
                return;
            }

            BinaryFormatter bf = new BinaryFormatter();
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            DestroyCurrent();
            Vector3 pPos = Vector3.zero;
            _pl = Instantiate(playerPrefab, pPos, Quaternion.identity);
            _plSc = FindObjectOfType<Player>();
            _plSc._score = data.score;
            _plSc._hp = data.health;

            _pl.transform.position = new Vector3(data.pl_pos[0], data.pl_pos[1], data.pl_pos[2]);
            _pl.transform.rotation = new Quaternion(data.pl_rot[0], data.pl_rot[1], data.pl_rot[2], data.pl_rot[3]);


            foreach (var i in data.good_pos)
            {
                string[] result;
                result = i.Split('x');
                float rX = float.Parse(result[0]);
                float rY = Single.Parse(result[1]);
                float rZ = Single.Parse(result[2]);
                Vector3 pos = new Vector3(rX, rY, rZ);
                Instantiate(goodPrefab, pos, Quaternion.identity);
            }

            foreach (var i in data.bad_pos)
            {
                string[] result;
                result = i.Split('x');
                float rX = float.Parse(result[0]);
                float rY = Single.Parse(result[1]);
                float rZ = Single.Parse(result[2]);
                Vector3 pos = new Vector3(rX, rY, rZ);
                Instantiate(badPrefab, pos, Quaternion.identity);
            }
            Debug.Log("Gamedata Loaded");
            FindObjectOfType<InteractiveObjectController>().Reload();
        }

        public void Create()
        {
            good = GameObject.FindGameObjectsWithTag("Good");
            bad = GameObject.FindGameObjectsWithTag("Bad");

            foreach (var i in good)
            {
                Vector3 coin = i.transform.position;
                float[] vect3;
                vect3 = new float[] { coin.x, coin.y, coin.z };
                string vect_data = $"{vect3[0]}x{vect3[1]}x{vect3[2]}";
                Array.Resize(ref gObjStoreGood, gObjStoreGood.Length + 1);
                gObjStoreGood[gObjStoreGood.Length - 1] = vect_data;
            }
            foreach (var i in bad)
            {
                Vector3 box = i.transform.position;
                float[] vect3;
                vect3 = new float[] { box.x, box.y, box.z };
                string vect_data = $"{vect3[0]}x{vect3[1]}x{vect3[2]}";
                Array.Resize(ref gObjStoreBad, gObjStoreBad.Length + 1);
                gObjStoreBad[gObjStoreBad.Length - 1] = vect_data;
            }
            Debug.Log("Gamedata Created");
        }
        public void DestroyCurrent()
        {
            good = GameObject.FindGameObjectsWithTag("Good");
            for (int i = 0; i < good.Length; i++)
            {
                Destroy(good[i].gameObject);
            }
            bad = GameObject.FindGameObjectsWithTag("Bad");
            for (int i = 0; i < bad.Length; i++)
            {
                Destroy(bad[i].gameObject);
            }
            Destroy(_pl);
        }
    }
}