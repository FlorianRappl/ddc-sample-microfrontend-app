using System;

namespace ddc_sample_app.Shared
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class FragmentAttribute : Attribute
    {
        public string FragmentSlot { get; }

        public FragmentAttribute()
        {

        }

        public FragmentAttribute(string fragmentSlot)
        {
            FragmentSlot = fragmentSlot;
        }
    }
}
