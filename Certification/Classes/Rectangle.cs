
namespace Certification.Classes
{
    class Rectangle
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Area
        {
            get
            {
                return Height * Width;
            }
        }
    }
}
