using System.Reflection;

namespace GV.CoreUtilities;

public static class GenericMethodInvoker
{
    public static T InvokeGenericMethod<T>(this object obj, string methodName, Type genericArgument)
    {
        Type type = obj.GetType();
        MethodInfo? method = type.GetMethod(methodName);
        if (method != null && method.IsGenericMethod)
        {
            MethodInfo genericMethod = method.MakeGenericMethod(genericArgument);
            return (T)genericMethod.Invoke(obj, null);
        }

        throw new ArgumentException($"Die Methode '{methodName}' konnte nicht gefunden oder ist nicht generisch.");
    }
}