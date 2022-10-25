namespace ITJob.Infrastructure.Services
{
    public class KeyValueObject
    {
        public object Key { get; set; }
        public object Value { get; set; }

        public KeyValueObject(object key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
