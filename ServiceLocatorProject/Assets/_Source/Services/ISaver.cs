using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    
    public interface ISaver
    {
        public void SaveScore(string path = null);
    }
    
}
