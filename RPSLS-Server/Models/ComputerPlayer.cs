namespace RpslsServer.Models
{
    public class ComputerPlayer : Player
    {
        public override string Name { get => "RPSLS-bot"; set { } }

        public override int Id { get => 0; set { } }

        public override string ToString()
        {
            return $"{Name} (Bot)";
        }
    }
}