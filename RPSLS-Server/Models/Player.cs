using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace RpslsServer.Models
{
    public class Player
    {
        public Gesture Gesture { get; set; }

        public virtual string Name { get; set; } = string.Empty;

        public virtual int Id { get; set; }

        public override string ToString()
        {
            return $"{Name} (Id = {Id})";
        }
    }
}