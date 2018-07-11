namespace App2.model
{
    public class BaseObject
    {
        protected MojoStatus mojoStatus;

        protected enum MojoStatus {NEW, MODIFIED, DELETED, NON_MODIFIED}
    }
}