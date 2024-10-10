namespace Knights.Challenge.Domain.Model
{
    public class Weapon //: Entity
    {
        public string Name { get; private set; }
        public int Mod { get; private set; }
        public string Attr { get; private set; }
        public bool Equiped { get; private set; }

        public Weapon() { }

        public Weapon(string name, int mod, string attr, bool equiped)
        {
            Name = name;
            Mod = mod;
            Attr = attr;
            Equiped = equiped;
        }

    }
}
