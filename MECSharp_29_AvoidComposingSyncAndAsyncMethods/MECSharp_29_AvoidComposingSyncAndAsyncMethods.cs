namespace MECSharp_29_AvoidComposingSyncAndAsyncMethods
{
    class MECSharp_29_AvoidComposingSyncAndAsyncMethods
    {
        static void Main(string[] args)
        {
            var t = new Pg150_4_DoNotCreateSyncMethodsThatBlockForAsyncWork();
            t.Test();
        }
    }
}
