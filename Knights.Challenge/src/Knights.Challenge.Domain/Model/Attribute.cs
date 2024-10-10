namespace Knights.Challenge.Domain.Model
{
    public class Attribute //: Entity
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }
        
        public Attribute() { }

        public Attribute(int attr)
        {
            Strength = attr;
            Dexterity = attr;
            Constitution = attr;
            Intelligence = attr;
            Wisdom = attr;
            Charisma = attr;
        }

        public Attribute(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma) 
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }
    }
}
