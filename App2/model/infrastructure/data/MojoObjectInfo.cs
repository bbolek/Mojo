namespace App2.model
{
    public class MojoObject : Mojo
    {
        public void save()
        {
            if (this.mojoStatus == MojoStatus.NEW)
            {
                createTable();
            }
        }

        private void createTable()
        {
            throw new System.NotImplementedException();
        }
    }
}