namespace Domain;

public class Participation(Participant? participant)
{
    public bool DoesParticipate => participant is not null;
    public Participant Participant => participant ?? throw new InvalidOperationException();
}