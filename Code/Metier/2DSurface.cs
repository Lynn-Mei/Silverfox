﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class _2DSurface
    {
        private int width;
        private int height;
        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value; } }
        public _2DSurface(int width, int height) 
        { 
            this.width = width;
            this.height = height;
        }
    }
}
