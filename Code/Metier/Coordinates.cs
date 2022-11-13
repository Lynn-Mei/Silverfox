using System.Security.Cryptography.X509Certificates;

namespace Metier
{
    public class Coordinates
    {
        private int x;
        private int y;

        public int X { get { return this.x; } set { this.x = value; } }
        public int Y { get { return this.y; } set { this.y = value; } }
        public Coordinates(int x, int y) 
        { 
            this.x = x;
            this.y = y;
        }
    }
}