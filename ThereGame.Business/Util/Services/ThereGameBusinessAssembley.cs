namespace ThereGame.Business.Util;

using System.Reflection;


public static class ThereGameBusinessAssembly
{
    public static Assembly GetAssembly()
    {
        return typeof(ThereGameBusinessAssembly).Assembly;
    }
}