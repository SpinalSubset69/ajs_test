namespace AJSExample.Helpers
{
    public static class Extensions
    {
        public static String Base64WithoutHeader(this String args)
        {
            if (args.Contains("base64"))
            {
                return args.Split(",")[1];
            }
            return args;
        }
    }
}