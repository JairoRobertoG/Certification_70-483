using Certification.Interfaces;

namespace Certification.Classes
{
    class MoveableOject : ILeft, IRight
    {
        void ILeft.Move() { }
        void IRight.Move() { }
    }
}
