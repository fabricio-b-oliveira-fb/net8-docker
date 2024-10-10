namespace Knights.Challenge.Domain.Model
{
    public class Knight : Entity
    {        
        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public DateTime Birthday { get; private set; }

        public List<Weapon> Weapons { get; private set; }
        public Attribute Attributes { get; private set; }

        public string KeyAttribute { get; private set; }
        public bool IsHero { get; private set; }


        //# Calculated Traits
        public int Age { get; private set; }        
        public int QuantityOfWeapons { get; private set; }        
        public double Attack { get; private set; }        
        public double Experience { get; private set; }

        
        //# Age vs Mod values
        //# TODO: move it to a mongo collection
        private List<ModPerAttibuteRange> _attributeRange = new()
        {
            new ModPerAttibuteRange() { Min = 0,  Max = 8,  Mod = -2},
            new ModPerAttibuteRange() { Min = 9,  Max = 10, Mod = -1},
            new ModPerAttibuteRange() { Min = 11, Max = 12, Mod =  0},
            new ModPerAttibuteRange() { Min = 13, Max = 15, Mod =  1},
            new ModPerAttibuteRange() { Min = 16, Max = 18, Mod =  2},
            new ModPerAttibuteRange() { Min = 19, Max = 20, Mod =  3},
            new ModPerAttibuteRange() { Min = 21, Max = 10000, Mod =  5000}, // Heroes live longer...
        };

        public Knight() 
        {
            Weapons = new List<Weapon>();
            Attributes = new Attribute();
        }

        public Knight(string name, string nickname, 
            DateTime birthday, List<Weapon> weapons, Attribute attributes, string keyAttribute)
        {
            Name = name;
            Nickname = nickname;
            Birthday = birthday;
            Weapons = weapons;
            Attributes = attributes;
            KeyAttribute = keyAttribute;            
        }

        public void UpdateNickname(string nickname)
        {
            Nickname = nickname;
        }
        public void SendToTheHallOfHeroes()
        {
            IsHero = true;
        }
        public void SetTraits() 
        {
            GetAge();
            GetQuantityOfWeapons();
            SetAttribute();
            CalculateAttack();  
            CalculateExperience();
        }        

        private void CalculateAttack()
        {
            var keyAttributeValue = GetKeyAttributeValue(Attributes);

            var totalEquippedWeaponMod = Weapons.Where(x => x.Equiped).Select(n => n.Mod).Sum();

            var attack = 10 + keyAttributeValue + totalEquippedWeaponMod;

            Attack = attack;
        }
        private void CalculateExperience()
        {
            var minimumAge = 7;
            var experience = 0D;
            var currentAge = Age;

            if (currentAge < minimumAge) return;

            experience = Math.Floor((currentAge - minimumAge) * Math.Pow(22, 1.45));

            Experience = experience;
        }

        private void GetAge()
        {
            var age = 0;
            
            age = DateTime.Now.Year - Birthday.Year;

            Age = age > 0 ? age : 0;
        }
        private int GetKeyAttributeValue<T>(T entity)
        {
            var value = 0;

            if (entity is null) return value;

            var keyAttributeName = GetKeyAttributeName();

            var properties = entity
                .GetType()
                .GetProperties()
                .Where(x => x.Name.Equals(keyAttributeName));

            if (!properties.Any()) return value;
            
            var prop = properties.FirstOrDefault().GetValue(Attributes, null);

            int.TryParse(prop.ToString(), out value);

            return value;            
        }
        private int GetAttribute()
        {
            var mod = _attributeRange
                .Where(x => Age >= x.Min && Age <= x.Max)
                .Select(n => n.Mod).FirstOrDefault();

            return mod;
        }
        private string GetKeyAttributeName()
        {
            return $"{char.ToUpper(KeyAttribute[0])}{KeyAttribute[1..]}";
        }

        private void SetAttribute()
        {
            var attr = GetAttribute();

            Attributes = new Attribute(attr);
        }
        private void GetQuantityOfWeapons()
        {
            QuantityOfWeapons = Weapons.Count();
        }
    }
}