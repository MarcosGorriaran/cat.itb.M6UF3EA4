

namespace cat.itb.M6UF3EA4.model
{
    public class Count<TId>
    {
        public TId id {  get; set; }
        public int count { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(id)}={id}, {nameof(count)}={count.ToString()}}}";
        }
    }
}
