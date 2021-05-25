//The MIT License(MIT)

//Copyright(c) 2016 Luis Palma

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System.Drawing;

namespace PathFinding.Classes
{
    /// <summary>
    /// Class with de position for drawing a portion of a resolved path for a Grid 
    /// </summary>
    class GridPath
    {
        public Pen pencil;
        public Point start;
        public Point end;
        public const int distance = 10;

        /// <summary>
        /// Create a GridPath with the points of the portion
        /// </summary>
        /// <param name="_start">A Point object for the begin of the path to draw</param>
        /// <param name="_end">A Point object for the end of the path to draw</param>
        public GridPath(Point _start, Point _end)
        {
            start = new Point(_start.X + distance, _start.Y + distance);
            end = new Point(_end.X + distance, _end.Y + distance);
            pencil = new Pen(Color.Beige, 2);
        }
    }
}
