using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ClasesVacias
{
    class Obstaculo : ICore
    {
        [Header("Power")]
        int power;
        int powerScale;
        public int probabilidadMin;     //Temporalmente p�blicos para revisar que valores llevan a una buena progresi�n
        public int probabilidadMax;

        public Obstaculo(int poder)
        {
            this.power = poder;
        }

        void Start()
        {
            power = Random.Range(probabilidadMin, probabilidadMax);
            power = ScalePower(powerScale);
        }

        public int ScalePower(int powerScale)
        {
            return powerScale;
        }
    }
}
