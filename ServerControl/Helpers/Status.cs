namespace ServerControl
{
    public static class Status
    {
        public static string Connecting => "Connecting to server...";
        public static string Disconnected => "Disconnected from server";
        public static string Connected => "Connected to server";
        public static string Setup => "Setting up system...";
        public static string Ready => "Ready";
        public static string Failed => "Failed";
        public static string HostNotOnline => "Host is currently not online. Please wait a moment or contact the administrator.";
        public static string AuthenticationFailed => "The authentication has failed.";
    }
}
