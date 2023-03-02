using UnityEngine;
namespace Labyrinth
{
    [System.Serializable]
    public class GameData
    {
        public int score;
        public int health;
        public float[] pl_pos;
        public float[] pl_rot;
        public string[] bad_pos;
        public string[] good_pos;

        public GameData(int sc, int hp, Vector3 plPos, Quaternion plRot, string[] gPos, string[] bPos)
        {
            pl_pos = new float[] { plPos.x, plPos.y, plPos.z };
            pl_rot = new float[] { plRot.x, plRot.y, plRot.z, plRot.w };
            score = sc;
            health = hp;
            good_pos = gPos;
            bad_pos = bPos;
        }
    }
}

