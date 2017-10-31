using System;
using System.Collections.Generic;
using System.Linq;

namespace Certification.Classes
{
    public class Pub
    {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            var exceptions = new List<Exception>();
            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }

        //public event EventHandler OnChange = delegate { };
        //public void Raise()
        //{
        //    OnChange(this, EventArgs.Empty);
        //}

        //private event EventHandler<MyArgs> onChange = delegate { };
        //public event EventHandler<MyArgs> OnChange
        //{
        //    add
        //    {
        //        lock (onChange)
        //        {
        //            onChange += value;
        //        }
        //    }
        //    remove
        //    {
        //        lock (onChange)
        //        {
        //            onChange -= value;
        //        }
        //    }
        //}

        //public void Raise()
        //{
        //    onChange(this, new MyArgs(42));
        //}


        //public Action OnChange { get; set; }

        //public event Action OnChange = delegate { };
        //public void Raise()
        //{
        //    OnChange();
        //}

        //public void Raise()
        //{
        //    if (OnChange != null)
        //    {
        //        OnChange();
        //    }
        //}
    }
}
