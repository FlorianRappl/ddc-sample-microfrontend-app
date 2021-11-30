using System;
using System.Collections.Generic;

namespace ddc_sample_app.Shared
{
    public class FragmentMap
    {
        private IDictionary<string, ComponentCollection> container = new Dictionary<string, ComponentCollection>();

        public void AddComponent(string name, Type component)
        {
            if (!container.TryGetValue(name, out var components))
            {
                components = new ComponentCollection();
                container.Add(name, components);
            }

            components.Add(component);
        }

        public Type[] GetComponents(string name)
        {
            if (container.ContainsKey(name))
            {
                return container[name].ToArray();
            }

            return null;
        }
    }
}
