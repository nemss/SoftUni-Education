namespace _1.EventImplementation
{
    public delegate void NameChangeEventHanler(object sender, NameChangeEventArgs e);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHanler NameChange;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnNameChange(new NameChangeEventArgs(value));
            }
        }

        private void OnNameChange(NameChangeEventArgs e)
        {
            if (NameChange != null)
            {
                NameChange(this, e);
            }
        }
    }
}