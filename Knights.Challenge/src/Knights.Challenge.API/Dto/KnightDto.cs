namespace Knights.Challenge.DTO
{
    public class KnightDto : Dto
    {
        public bool IsHero { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }

        public List<WeaponDto> Weapons { get; set; }
        public AttributeDto Attributes { get; set; }

        public string KeyAttribute { get; set; }

        public KnightDto() 
        {
            Weapons = new List<WeaponDto>();
            Attributes = new AttributeDto();
        }
    }
}
