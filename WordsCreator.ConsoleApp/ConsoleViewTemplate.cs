using System;
public static class ConsoleViewTemplate
{
    public static string Apply(string firstOutputValue, string secondOutputValue )
    {
        return string.Format("{0} + {1} = {2}", firstOutputValue, secondOutputValue, 
        string.Concat(firstOutputValue, secondOutputValue)); 
    }
}