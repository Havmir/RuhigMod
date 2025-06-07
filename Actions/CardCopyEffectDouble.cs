namespace RuhigMod.Actions;

public class CardCopyEffectDouble : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {
        Card? selectedCard = this.selectedCard;
        if (selectedCard == null)
            return;
        Card card = selectedCard.CopyWithNewId();
        c.QueueImmediate( new AAddCard()
        {
            card = card,
            destination = CardDestination.Hand,
            amount = 2
        });
    }
}