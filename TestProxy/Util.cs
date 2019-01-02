namespace ConsoleExtensions.Proxy.TestHelpers
{
  public static class Util
  {
    public static string[] LineSplit(TestProxy proxy)
    {
      return proxy.ToString().Replace("[key:", "\r[key:").Split('\r');
    }
  }
}