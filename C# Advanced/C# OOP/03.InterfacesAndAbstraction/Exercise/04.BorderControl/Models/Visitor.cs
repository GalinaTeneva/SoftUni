
namespace BorderControl.Models
{
    using BorderControl.Models.Interfaces;

    public abstract class Visitor : IVisitor
    {
        public string Id { get; private set; }
    }
}
