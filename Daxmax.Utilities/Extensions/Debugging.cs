using System;
using System.Reflection;
namespace Daxmax.Utilities.Extensions
{
    public static class Debugging
    {
        public static string var_dump( object obj)
        {
            var ln = new System.Text.StringBuilder();
            ln.Append(String.Concat("{0,-18} {1}", "Name", "Value"));
            
            ln.Append(@"-------------------------------------   
               ----------------------------");

            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                try
                {
                    ln.Append($"{props[i].Name} -  {props[i].GetValue(obj, null)} ");
                }
                catch (Exception e)
                { }
            }
            return ln.ToString();
        }
    }
}
