
namespace Certification.Classes
{
    class ConstructorChaining
    {
        private int _p;

        public ConstructorChaining() : this(3) { }

        public ConstructorChaining(int p)
        {
            this._p = p;
        }
    }
}
