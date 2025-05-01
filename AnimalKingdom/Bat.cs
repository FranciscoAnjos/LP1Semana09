namespace AnimalKingdom
{
    public class Bat: Animal
    {
        public int NumberOfNipples => 2;
        
        public override string Sound()
        {
            return base.Sound() + "ti ti ti";
        }
    }
}