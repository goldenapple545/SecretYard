﻿using System;

namespace CodeBase.Data
{
    [Serializable]
    public class Vector3Data
    {
        public Vector3Data() {}

        public Vector3Data(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float x;
        public float y;
        public float z;

        public override string ToString()
        {
            return $"{x} {y} {z}";
        }
    }
}
