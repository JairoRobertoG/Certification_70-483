﻿using System.Dynamic;

namespace Certification.Classes
{
    public class SampleObject : DynamicObject 
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }
}
