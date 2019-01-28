using System;
using System.Reflection;

namespace GenericSingletons
{
    public static class Singleton<T>
        where T : class
    {
        private static volatile T s_Instance;

        /// <summary>
        /// The dummy object used for locking.
        /// </summary>
        private static object s_LockObj = new object();

        /// <summary>
        /// Type-initializer to prevent type to be marked with beforefieldinit.
        /// </summary>
        /// <remarks>
        /// This simply makes sure that static fields initialization occurs 
        /// when Instance is called the first time and not before.
        /// </remarks>
        static Singleton()
        {
        }

        /// <summary>
        /// Gets the single instance of the class.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_Instance == null)
                        {
                            ConstructorInfo constructor = null;

                            try
                            {
                                // Binding flags exclude public constructors.
                                constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
                            }
                            catch (Exception exception)
                            {
                                throw new Exception(null, exception);
                            }

                            if (constructor == null || constructor.IsAssembly) // Also exclude internal constructors.
                            {
                                throw new Exception(string.Format("A private or protected constructor is missing for '{0}'.", typeof(T).Name));
                            }

                            s_Instance = (T)constructor.Invoke(null);
                        }
                    }
                }

                return s_Instance;
            }
        }
    }
}
