using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public abstract class ExecuteObject : MonoBehaviour, IExecute
    {
        public abstract void Execute();
        
    }
}