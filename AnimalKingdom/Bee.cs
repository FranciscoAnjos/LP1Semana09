namespace AnimalKingdom
{
    public class Bee: Animal
    {
        public override string Sound()
        {
            return base.Sound() + "bzz";
        }
    }
}